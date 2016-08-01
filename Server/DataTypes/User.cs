using Fps.Library.DataTypes.BaseDataTypes.Attributes;
using Fps.Library.DataTypes.BaseDataTypes.BaseDataType;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace IFK.Server.DataTypes
{
    [UpdateIgnore]
    public class User : BaseDataType
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public string AccessToken { get; set; }

        public long? SquadID { get; set; }
        [ForeignKey("SquadID"), JsonIgnore]
        public virtual Squad Squad { get; set; }


        public User()
        {
            Email = string.Empty;
            Password = string.Empty;
            Points = 0;
            AccessToken = string.Empty;
        }
    }
}
