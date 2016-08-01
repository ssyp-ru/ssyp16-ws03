using Fps.Library.DataTypes.BaseDataTypes.Attributes;
using Fps.Library.DataTypes.BaseDataTypes.BaseDataType;
using IFK.Server.DataTypes.Issues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IFK.Server.DataTypes
{
    public class Squad : BaseDataType
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [UpdateIgnore]
        public virtual List<User> Composition { get; set; }
        [UpdateIgnore]
        public virtual List<Issue> Issues { get; set; }
        [NotMapped]
        public IEnumerable<Issue> SprintIssues
        {
            get
            {
                return Issues.Where(issue => Status.Backlog != issue.Status && Status.Closed != issue.Status);
            }
        }
        public virtual Sprint Sprint { get; set; }
        //public virtual List<Notification> Notifications { get; set; } 

        public Squad()
        {
            Key = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Composition = new List<User>();
            Issues = new List<Issue>();
            Sprint = null;
            //Notifications = new List<Notification>();
        }
    }
}
