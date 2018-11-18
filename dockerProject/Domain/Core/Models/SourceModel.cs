using Core.Models.Base;

namespace Core.Models
{
    public class SourceModel : BaseModel
    {
        public object GeoLocation { get; set; }
        public ResourceModel[] Resources { get; set; }
        //public StatisticModel[] Statistic { get; set; }
    }
}