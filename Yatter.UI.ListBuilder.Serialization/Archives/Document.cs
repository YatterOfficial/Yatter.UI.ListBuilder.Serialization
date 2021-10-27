using System;
namespace Yatter.UI.ListBuilder.Serialization.Archives
{
    public class Document
    {
        public string DataType { get; set; }

        public string Path { get; set; }
        public string Base64Content { get; set; }

        public Document()
        {
            DataType = GetType().ToString();
        }
    }
}

