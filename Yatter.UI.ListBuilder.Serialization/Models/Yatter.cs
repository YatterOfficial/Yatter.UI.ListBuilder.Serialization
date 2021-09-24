using System;
using System.Collections.Generic;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public class Yatter : IYatter
    {
        public string DataType => "Yatter";
        public Dictionary<string,string> YatterSpace { get; set; }
        public Dictionary<string,string> ServiceDictionary { get; set; }
        public List<Object> Items { get; set; }
    }
}
