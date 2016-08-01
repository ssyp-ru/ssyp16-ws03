using Fps.Library.DataTypes.BaseDataTypes.Attributes;
using Fps.Library.DataTypes.BaseDataTypes.BaseDataType;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace IFK.Server.DataTypes.Issues
{
    public class Issue : BaseDataType
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long UserID { get; set; }
        [ForeignKey("UserID"), JsonIgnore, UpdateIgnore]
        public virtual User User { get; set; }
        public virtual Priority Priority { get; set; }
        public long Cost { get; set; }
        public Status Status { get; set; }

        [UpdateIgnore]
        public long SquadID { get; set; }
        [ForeignKey("SquadID"), JsonIgnore, UpdateIgnore]
        public virtual Squad Squad { get; set; }

        public Issue()
        {
            Name = string.Empty;
            Description = string.Empty;
            User = null;
            Priority = default(Priority);
            Cost = 0;
            Status = default(Status);
        }
    }
}