using System;
using Core.Models.Base;

namespace Core.Models
{
    public class AssaySourceModel : BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public SourceModel Source { get; set; }
        public UserModel User { get; set; }
        public AssayResourceModel[] AssayResourceModels { get; set; }
    }

    public class AssayResourceModel
    {
        public ResourceModel ResourceModel { get; set; }
        public double Value { get; set; }
    }
}