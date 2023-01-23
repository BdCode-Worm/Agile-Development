using System;
using System.Threading;

namespace PMPReportingApp.Models
{
    public class AgreementReviews
    {
        //static int nextId = 0;
        //public int DetailsId { get; private set; }

        //AgreementDetails()
        //{
        //    DetailsId = Interlocked.Increment(ref nextId);
        //}
        public string _id { get; set; }
        public string Provider_Name { get; set; }
        public string raiting { get; set; }
        public string descriptions { get; set; }
        public string argeementsID { get; set; }
    }
}
