using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;

namespace Models
{
    [DataContract]
    public class Exercise
    {        
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string date { get; set; }
        
        [DataMember]
        public int setNumber { get; set; }
        
        [DataMember]
        public string weight { get; set; }
        
        [DataMember]
        public int repetitions { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string CreatePassword { get; set; }
    }
}
