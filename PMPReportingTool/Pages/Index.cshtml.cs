using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMPReportingTool.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
    public class MasterAgreementDetails
    {
        public MasterAgreementDetails()
        {

        }
        public MasterAgreementDetails(int masterAgreementID, string masterAgreementName, string agreementType, int cycle, string status, DateTime startDate, DateTime endDate, 
            string company, string companyAdress, string createdBy, DateTime createdDate)
        {
            this.MasterAgreementID = masterAgreementID;
            this.MasterAgreementName = masterAgreementName;
            this.AgreementType = agreementType;
            this.Cycle = cycle;
            this.Status = status;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Company = company;
            this.CompanyAdress = companyAdress;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
        }
        public int? MasterAgreementID { get; set; }
        public string MasterAgreementName { get; set; }
        public string AgreementType { get; set; }
        public int Cycle { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Company { get; set; }
        public string CompanyAdress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class DoughnutData
    {

        public DoughnutData()
        {

        }

        public DoughnutData(string xvalue, double yValue, string text)
        {
            this.XValue = xvalue;
            this.YValue = yValue;
            this.Text = text;
        }


        public string XValue { get; set; }
        public double YValue { get; set; }
        public string Text { get; set; }
    }
}
