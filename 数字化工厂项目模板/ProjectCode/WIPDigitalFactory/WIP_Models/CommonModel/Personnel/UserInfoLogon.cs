using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WIP_Models
{
    [DataContract]
    public class UserInfoLogon
    {

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public string PassWord { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Group { get; set; }

        public override string ToString()
        {
            return string.Format("name: {0,-5}E-mail: {1, -5}Group: {2,-5}",  Name, Email, Group);
        }
    }
}
