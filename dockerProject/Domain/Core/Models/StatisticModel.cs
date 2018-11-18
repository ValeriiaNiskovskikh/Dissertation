using System;
using Core.Models.Base;

namespace Core.Models
{
    public class StatisticModel : BaseModel
    {
        public ResourceModel Resource { get; set; }
        public SourceModel Source { get; set; }
        public UserModel User { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Value { get; set; }
        
    }
}