using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class GeneralResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
