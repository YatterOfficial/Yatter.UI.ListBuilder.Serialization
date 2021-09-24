using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public class Yatter : IYatter
    {
        [JsonIgnore]
        private string _dataType;

        public string DataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                _dataType = value;
            }
        }

        public Dictionary<string, string> YatterSpaces { get; set; }
        public Dictionary<string, string> ServiceDictionary { get; set; }
        public List<Object> Items { get; set; }

        public Yatter()
        {
            _dataType = GetType().ToString();
        }
    }
}
