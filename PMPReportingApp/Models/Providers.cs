using System;

namespace PMPReportingApp.Models
{
    public class Provider
    {
        public Provider()
        {

        }
        public Provider(int providerID, string providerName, string company, int totalBid, int completedProject, int ongoingProject, double score, string createdby, DateTime createdDate)
        {
            this.ProviderID = providerID;
            this.ProviderName = providerName;
            this.Company = company;
            this.TotalBid = totalBid;
            this.CompletedProject = completedProject;
            this.OngoingProject = ongoingProject;
            this.ServiceScore = score;
            this.CreatedBy = createdby;
            this.CreatedDate = createdDate;
        }
        public int? ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Company { get; set; }
        public int TotalBid { get; set; }
        public int CompletedProject { get; set; }
        public int OngoingProject { get; set; }
        public double ServiceScore { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
