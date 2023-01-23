using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMPReportingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PMPReportingApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<MasterAgreementDetails> agreement = new List<MasterAgreementDetails>();
        List<MasterAgreement> agreements = new List<MasterAgreement>();
        List<AgreementDetails> agreementDetails = new List<AgreementDetails>();
        List<AgreementReviews> reviews = new List<AgreementReviews>();  
        List<AgreementOffers> offers = new List<AgreementOffers>();
        List<AgreementOffers> providerOffers = new List<AgreementOffers>();




        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await FetchMasterAgreementsDataFromAPIAsync();
            await FetchMasterAgreementDetailsDataFromAPIAsync();
            await FetchOffersDataFromAPIAsync();
            await FetchFeedbackScoreDataFromAPIAsync();
            await FetchOffersofProvidersFromAPIAsync();

            agreements = FetchMasterAgreementsDataFromAPIAsync().Result;
            agreementDetails = FetchMasterAgreementDetailsDataFromAPIAsync().Result;
            offers = FetchOffersDataFromAPIAsync().Result;
            providerOffers = FetchOffersofProvidersFromAPIAsync().Result;
            reviews = FetchFeedbackScoreDataFromAPIAsync().Result;

            List<MasterAgreementDetails> agreement = GetMasterAgreementList();
            ViewBag.MasterAgreementCount = agreements.Count();

            ViewBag.ClosedAgreements = (from data in agreements
                                       where data.status == "closed"
                                       select data).ToList().Count();
            ViewBag.OpenAgreements = (from data in agreements
                                      where data.status != "closed"
                                      select data).ToList().Count();

            List <AgreementPosition> positions = new List<AgreementPosition>
            {
                new AgreementPosition(1, "Team Lead", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(2, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(3, "Senior Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(4, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(5, "Project manager", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(6, "Team Lead", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(7, "Project manager", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(8, "Project manager", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(9, "Team Lead", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(10, "Senior Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(11, "Senior Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(12, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(13, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(14, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(15, "Software Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(16, "QA Engineer", "Development", "Development", "", DateTime.Now),
                new AgreementPosition(17, "QA Engineer", "Development", "Development", "", DateTime.Now)
            };

            List<DoughnutData> chartData = new List<DoughnutData>();

            foreach (var position in agreementDetails.GroupBy(info => info.name)
                        .Select(group => new {
                            name = group.Key,
                            Count = group.Count(),
                            percentage = (int)Math.Round((double)(100 * group.Count()) / agreementDetails.Count())
                        })
                        .OrderBy(x => x.name))
            {
                Console.WriteLine("{0} {1}", position.name, position.Count, position.percentage);
                chartData.Add(new DoughnutData { xValue = position.name, yValue = position.Count, text = position.percentage.ToString()+"%" });
            }


            //foreach (var provider in providerOffers.GroupBy(info => info.provider_name)
            //            .Select(group => new {
            //                name = group.Key,
            //                Count = group.Count(),

            //            })
            //            .OrderBy(x => x.name))
            //{
            //    Console.WriteLine("{0} {1}", position.name, position.Count, position.percentage);
            //    chartData.Add(new DoughnutData { xValue = position.name, yValue = position.Count, text = position.percentage.ToString() + "%" });
            //}


            ////var query = from ttb2 in reviews
            ////            join ttab in providerOffers on ttb2.Provider_Name equals ttab.provider_name
            ////            join pt in offers on ttb2.Provider_Name equals pt.provider_name
            ////            select new {
            ////                provider = pt.provider_name,
            ////                //agreement = pt.agreementsid,
            ////                //provider_status = pt.status, 
            ////                //actual_status = ttab.status, 
            ////                reviews = ttb2.raiting
            ////                            };

            var query1 = from ttb2 in offers
                        join ttab in agreementDetails on ttb2.positionid equals ttab._id
                        select new
                        {
                            postion_name = ttab.name,
                            provider = ttb2.provider_name,
                            rates = ttb2.rate
                        };


            ViewBag.RateList = query1.ToList();


            List<ChartData> chartData1 = new List<ChartData>();
            var query2 = from ttb2 in agreements
                         join ttab in offers on ttb2._id equals ttab.agreementsid
                         where ttab.status == "accept"
                         select new
                         {
                             project = ttb2.name,
                             total_cost = (Convert.ToDateTime(ttb2.endTime) - Convert.ToDateTime(ttb2.startTime)).TotalDays * Convert.ToInt32(ttab.rate)
                         };
          

            foreach (var q in query2)
            {
                chartData1.Add(new ChartData { xValue = q.project, yValue = q.total_cost});
            }

            ViewBag.dataSource1 = chartData1.ToList();

            // (EndDate - StartDate).TotalDays

            List<ServiceScoreData> scores = new List<ServiceScoreData>();
            List<ServiceScoreData> profilesOffered = new List<ServiceScoreData>();

            foreach (var review in reviews.GroupBy(info => info.Provider_Name)
                        .Select(group => new
                        {
                            name = group.Key,
                            Count = group.Count(),
                            review = (group.Sum(s => Convert.ToInt32(s.raiting)) / group.Count())
                        })
                        .OrderBy(x => x.name))
            {
                Console.WriteLine("{0} {1}", review.name, review.Count, review.review);
                if (review.name == "D")
                {
                    scores.Add(new ServiceScoreData
                    {
                        provider = review.name,
                        score = review.review,
                        projects = review.Count,
                        profilesOffered = 3
                    });
                }
                else
                {
                    scores.Add(new ServiceScoreData
                    {
                        provider = review.name,
                        score = review.review,
                        projects = review.Count,
                        profilesOffered = 1
                    });
                }
            }

            ViewBag.ServiceScore = scores;

            foreach (var offer in offers.GroupBy(info => info.provider_name)
                        .Select(group => new
                        {
                            name = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.name))
            {
                Console.WriteLine("{0} {1}", offer.name, offer.Count);
                //scores.Add(new ServiceScoreData { provider = review.name, score = review.review, projects = review.Count });
            }


            //var query2 = from ttb2 in scores
            //             join ttab in providerOffers on ttb2.provider equals ttab.provider_name
            //             select new
            //             {
            //                 provider = ttb2.provider,
            //                 score = ttb2.,
            //                 reviews = ttb2.raiting
            //             };

            //ViewBag.ServiceScore = query2.ToList();


            //var query3 = from ttb2 in reviews
            //             select new
            //             {
            //                 provider = ttb2.Provider_Name,
            //                 count = 1,
            //                 reviews = ttb2.raiting
            //             };

            //var rates = reviews
            //   .GroupBy(g => g.Provider_Name, r => r.raiting)
            //   .Select(g => new
            //   {
            //       UserId = g.Key,
            //       Rating = r.Average()
            //   })




            ViewBag.dataSource = chartData;

            List<Provider> providers = new List<Provider>
            {
                new Provider(1, "Alaska Software Inc.","Software",15,3,2,4.2,"",DateTime.Now),
                new Provider(1, "MetaComp GmbH","Software",20,6,3,4.8,"",DateTime.Now),
                new Provider(1, "AcumenCog pvt ltd.","Software",18,4,1,3.3,"",DateTime.Now),
                new Provider(1, "iTester Inc.","Software",10,1,3,4.0,"",DateTime.Now),
                new Provider(1, "Apps Germany GmbH","Software",22,6,4,3.2,"",DateTime.Now),
                new Provider(1, "ComfNet Solutions GmbH","Software",11,2,1,3.5,"",DateTime.Now),
                new Provider(1, "Zucchetti Germany GmbH","Software",13,3,2,4.7,"",DateTime.Now),
                new Provider(1, "OneStream Software ltd.","Software",10,1,1,3.8,"",DateTime.Now)
            };

            ViewBag.Providers = providers;

            return View();
        }

        private async Task<List<AgreementOffers>> FetchOffersofProvidersFromAPIAsync()
        {
            List<AgreementOffers> providerOffered = new List<AgreementOffers>();

            var providers = new Dictionary<string, string>(){
                            {"A", "Provider-A"},
                            {"B", "Provider-B"},
                            {"C", "Provider-C"},
                            {"D", "Provider-D"}
                        };


            try
            {
                foreach (var datas in providers)
                {
                    List<AgreementOffers> offered= new List<AgreementOffers>();

                    string baseUrl = "http://ec2-3-127-137-126.eu-central-1.compute.amazonaws.com/users/offers?provider=" + datas.Key + "";

                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                        {
                            using (HttpContent content = res.Content)
                            {
                                var data = await content.ReadAsStringAsync();
                                if (data != null)
                                {
                                    offered = JsonConvert.DeserializeObject<List<AgreementOffers>>(data);
                                }
                                else
                                {
                                    //Console.WriteLine("NO Data----------");
                                }
                            }
                        }
                    }

                    providerOffered.AddRange(offered);
                }
            }

            catch (Exception exception)
            {
                return null;
            }
            providerOffers = providerOffered;

            return providerOffers;
        }

        private async Task<List<AgreementReviews>> FetchFeedbackScoreDataFromAPIAsync()
        {
            string baseUrl = "https://provider-management-platform-server.onrender.com/reviews";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                reviews = JsonConvert.DeserializeObject<List<AgreementReviews>>(data);
                            }
                            else
                            {
                                //Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }

                return reviews;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private async Task<List<AgreementOffers>> FetchOffersDataFromAPIAsync()
        {
            string baseUrl = "https://provider-management-platform-server.onrender.com/selectedProfile";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                offers = JsonConvert.DeserializeObject<List<AgreementOffers>>(data);
                            }
                            else
                            {
                                //Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }

                return offers;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        private async Task<List<MasterAgreement>> FetchMasterAgreementsDataFromAPIAsync()
        {
            string baseUrl = "https://provider-management-platform-server.onrender.com/agreements";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                agreements = JsonConvert.DeserializeObject<List<MasterAgreement>>(data);
                            }
                            else
                            {
                                //Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }

                return agreements;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        private async Task<List<AgreementDetails>> FetchMasterAgreementDetailsDataFromAPIAsync()
        {
            string baseUrl = "https://provider-management-platform-server.onrender.com/agreementsdetails";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                agreementDetails = JsonConvert.DeserializeObject<List<AgreementDetails>>(data);
                            }
                            else
                            {
                                //Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }

                return agreementDetails;
            }
            catch (Exception exception)
            {
                return null;
            }
        }


        public IActionResult MasterAgreements()
        {
            agreements = FetchMasterAgreementsDataFromAPIAsync().Result;
            ViewBag.MasterAgreements = agreements;
            return View();
        }

        private static List<MasterAgreementDetails> GetMasterAgreementList()
        {
            List<MasterAgreementDetails> agreement = new List<MasterAgreementDetails>();
            if (agreement.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 5; i++)
                {
                    agreement.Add(new MasterAgreementDetails(code + 1, "Web Development Team", "Team", 1, "Published", new DateTime(2022, 12, 12), new DateTime(2023, 12, 31), "Frankfurt University of Applied Sciences", "Franfurt Am Main", "Kirchgasse 6", new DateTime(2022, 12, 21)));
                    agreement.Add(new MasterAgreementDetails(code + 1, "Software Development Team", "Team", 1, "Published", new DateTime(2022, 12, 20), new DateTime(2023, 07, 10), "Mobile hubs limited", "Hamburg", "Kuntola", new DateTime(2022, 12, 21)));
                    agreement.Add(new MasterAgreementDetails(code + 1, "Web Development Team2", "Single", 1, "Published", new DateTime(2022, 12, 05), new DateTime(2023, 02, 21), "Simplexhub limited", "Berlin", "Mehedi Hasan", new DateTime(2022, 12, 21)));
                    agreement.Add(new MasterAgreementDetails(code + 1, "Web Development Team3", "Team", 1, "Published", new DateTime(2022, 12, 05), new DateTime(2023, 04, 25), "Acer Malaysia", "Malaysia", "Rizwan", new DateTime(2022, 12, 21)));
                    agreement.Add(new MasterAgreementDetails(code + 1, "Web Development Team4", "Team", 2, "Published", new DateTime(2022, 12, 01), new DateTime(2023, 12, 20), "Deloitte", "Franfurt Am Main", "Kirchgasse 6", new DateTime(2022, 12, 21)));
                    code += 5;
                }
            }

            return agreement;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class DoughnutData
    {
        public string xValue;
        public double yValue;
        public string text;
    }
    public class BarChartData
    {
        public string x;
        public double y;
    }

    public class ServiceScoreData
    {
        public string provider;
        public double score;
        public int projects;
        public int profilesOffered;
    }

    public class ChartData
    {
        public string xValue;
        public double yValue;
    }
}
