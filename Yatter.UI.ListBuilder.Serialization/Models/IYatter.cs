using System;
using System.Collections.Generic;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public interface IYatter
    {
        string DataType { get; }
        Dictionary<string, string> YatterSpace { get; set; }
        Dictionary<string, string> ServiceDictionary { get; set; }
        List<Object> Items { get; set; }
    }
}

