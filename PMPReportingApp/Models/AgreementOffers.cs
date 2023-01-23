using System;
using System.Threading;

namespace PMPReportingApp.Models
{
    public class AgreementOffers
    {
        //static int nextId = 0;
        //public int DetailsId { get; private set; }

        //AgreementDetails()
        //{
        //    DetailsId = Interlocked.Increment(ref nextId);
        //}
        public object document { get; set; }
        public string _id { get; set; }
        public string employeeid { get; set; }
        public string positionid { get; set; }
        public string agreementsid { get; set; }
        public string employee_name { get; set; }
        public string provider_name { get; set; }
        public string contactperson { get; set; }
        public string externalperson { get; set; }
        public string rate { get; set; }
        public string notes { get; set; }
        public string dateuntil { get; set; }
       // public string document { get; set; }
        public string status { get; set; }
    }
}
