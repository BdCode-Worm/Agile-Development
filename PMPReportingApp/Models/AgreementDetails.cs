using System;
using System.Threading;

namespace PMPReportingApp.Models
{
    public class AgreementDetails
    {
        static int nextId = 0;
        public int DetailsId { get; private set; }

        AgreementDetails()
        {
            DetailsId = Interlocked.Increment(ref nextId);
        }
        public string _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string agreementsId { get; set; }
    }
}
