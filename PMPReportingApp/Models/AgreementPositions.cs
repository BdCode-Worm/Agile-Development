using System;

namespace PMPReportingApp.Models
{
    public class AgreementPositions
    {
        public int? ID { get; set; }
        public int AgreementID { get; set; }
        public int PositionID { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
