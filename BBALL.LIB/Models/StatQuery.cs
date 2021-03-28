using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Models
{
    public class StatQuery
    {
        public string Collection { get; set; }
        public JArray Parameters { get; set; }
        public int CallCount { get; set; }
        public bool Parse { get; set; }
        public int Timeout { get; set; }
    }
}
