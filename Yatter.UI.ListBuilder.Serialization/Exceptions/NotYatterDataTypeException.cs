using System;
namespace Yatter.UI.ListBuilder.Serialization.Exceptions
{
    public class NotYatterDataTypeException : Exception
    {
        public string Message { get; private set; }

        public NotYatterDataTypeException(string typeName)
        {
            Message =  $"Not a Yatter.UI.ListBuilder.Serialization.Models.Yatter DataType in {typeName}";
        }
    }
}
