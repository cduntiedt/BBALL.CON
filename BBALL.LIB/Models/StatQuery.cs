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
    }
}
