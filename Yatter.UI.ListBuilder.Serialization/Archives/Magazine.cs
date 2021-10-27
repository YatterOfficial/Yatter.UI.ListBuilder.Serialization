using System;
using System.Collections.Generic;

namespace Yatter.UI.ListBuilder.Serialization.Archives
{
    public class Magazine
    {
        public Magazine()
        {
            DataType = GetType().ToString();
            PathRoot = default(string);
        }

        public string DataType { get; set; }
        public Dictionary<string, string> YatterSpaces = new Dictionary<string, string>();

        public string PathRoot { get; set; }
        public List<Document> Documents = new List<Document>();
    }
}

