using System;

namespace PMPReportingApp.Models
{
    public class AgreementPosition
    {
        public AgreementPosition()
        {

        }
        public AgreementPosition(int positionID, string positionName, string positionType, string Description, string createdBy, DateTime createdDate)
        {
            this.PositionID = positionID;
            this.PositionName = positionName;
            this.PositionType = positionType;
            this.Description = Description;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
        }
        public int? PositionID { get; set; }
        public string PositionName { get; set; }
        public string PositionType { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
