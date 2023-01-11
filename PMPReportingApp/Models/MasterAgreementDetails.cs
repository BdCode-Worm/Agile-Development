using System;

namespace PMPReportingApp.Models
{
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
}
