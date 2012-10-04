using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class FlexigridObject
    {
        public string total { get; set; }
        public string page { get; set; }
        public List<Exercise> rows { get; set; }
    }
}
