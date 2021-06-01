using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkiAPI.Models
{
    public class Translation
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Translation { get; set; }
    }
}
