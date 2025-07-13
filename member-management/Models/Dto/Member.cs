using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member_management.Models.Dto
{
    public class Member
    {
        public int ID { get; set; }
        public string PROFILE_IMG { get; set; }
        public string NAME { get; set; }
        public string MAIL { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string DEPARTMENT { get; set; }
        public string RANK { get; set; }
        public string COLLEGE { get; set; }
        public DateTime BIRTH { get; set; }
    }
}
