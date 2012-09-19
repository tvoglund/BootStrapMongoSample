using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class PieResponse
    {
        public string name  { get; set; }
        public decimal y {get; set;}
        public bool sliced {get; set;}
        public bool selected { get; set; }

        public PieResponse()
        {

        }

        public PieResponse(string Name, decimal Y)
        {
            this.Initialize();
            name = Name;
            y = Y;
        }

        public void Initialize()
        {
            sliced = false;
            selected = false;
        }
    }
}
