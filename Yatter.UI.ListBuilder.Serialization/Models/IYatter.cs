using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public interface IYatter
    {
        string DataType { get; set; }
        Dictionary<string, string> YatterSpaces { get; set; }
        Dictionary<string, string> ServiceDictionary { get; set; }
        ObservableCollection<Object> Items { get; set; }
    }
}

