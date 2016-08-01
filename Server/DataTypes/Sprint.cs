using Fps.Library.DataTypes.BaseDataTypes.Attributes;
using Fps.Library.DataTypes.BaseDataTypes.BaseDataType;
using IFK.Server.DataTypes.Issues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IFK.Server.DataTypes
{
    public class Sprint : BaseDataType
    {
        public virtual DateTime Term { get; set; } 
        [NotMapped, UpdateIgnore]
        public virtual List<Issue> Issues { get; set; } 

        public Sprint()
        {
            Issues = new List<Issue>();
            Term = DateTime.UtcNow;
        }
    }
}
