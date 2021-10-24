using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yatter.UI.ListBuilder.ListItems;
using Yatter.UI.ListBuilder.Serialization;
using Yatter.UI.ListBuilder.Serialization.Models;
using Yatter.UI.ListBuilder.Serialization.Exceptions;

using System.Reflection;
using System.Linq;

namespace Yatter.UI.ListBuilder.Serialization
{
    public static class YatterConvert
    {
        private static Assembly ListBuilderAssembly { get; set; }
        private static Assembly SerializationAssembly { get; set; }
        
        public static List<object> DeserializeYatterListJson(string json)
        {
            var list = new List<object>();

            var obj = JsonConvert.DeserializeObject<List<object>>(json);

            foreach (var item in obj)
            {
                var dto = JsonConvert.DeserializeObject<DataTypeDto>(item.ToString());

                string dataType = dto.DataType;


                if(dataType.Substring(0,1).Equals("y")&& dataType.Substring(1, 1).Equals("@"))
                {
                    dataType = dataType.Replace("y@", "Yatter.UI.ListBuilder.ListItems.");
                }

                if (SerializationAssembly == null)
                {
                    SerializationAssembly = Assembly.Load("Yatter.UI.ListBuilder.Serialization");
                }
                if (ListBuilderAssembly == null)
                {
                    ListBuilderAssembly = Assembly.Load("Yatter.UI.ListBuilder");
                }

                Type type = null;

                if (dataType.Contains("Yatter.UI.ListBuilder.Serialization"))
                {
                    type = SerializationAssembly.GetType(dataType);
                }
                else if (dataType.Contains("Yatter.UI.ListBuilder"))
                {
                    type = ListBuilderAssembly.GetType(dataType);
                }

                list.Add(Deserialize(type, dataType, item.ToString()));
            }

            return list;
        }

        private static object Deserialize(Type type, string dataType, string json)
        {
            object result = null;

            try
            {
                var methodInfo = typeof(JsonConvert)
                    .GetMethods()
                    .Where(x => x.Name == "DeserializeObject")
                    .FirstOrDefault(x => x.IsGenericMethod);

                var genericMethodInfo = methodInfo.MakeGenericMethod(type);
                result = genericMethodInfo.Invoke(null, new object[] { json });
                ((IDataType)result).DataType = dataType; // accounts for where original was in the form of an x@ YatterSpace
            }
            catch(Exception ex)
            {
                throw new Exception($"y@tter: EXCEPTION thrown in Yatter.UI.ListBuilder.Serialization: Exception thrown in Deserialize method: {ex.Message} ");
            }

            return result;
        }

        public static Yatter.UI.ListBuilder.Serialization.Models.Yatter DeserializeYatterJson(string json)
        {
            var yatterDataType = "Yatter.UI.ListBuilder.Serialization.Models.Yatter";

            var yatter = new Yatter.UI.ListBuilder.Serialization.Models.Yatter();

            var datatypeDto = JsonConvert.DeserializeObject<DataTypeDto>(json);

            if (datatypeDto.DataType.Substring(0, 1).Equals("a") && datatypeDto.DataType.Substring(1, 1).Equals("@"))
            {
                datatypeDto.DataType = datatypeDto.DataType.Replace("a@", "Yatter.UI.ListBuilder.Serialization.Models.");
            }

            if (datatypeDto == null || !datatypeDto.DataType.ToLower().Equals(yatterDataType.ToLower()))
            {
                throw new NotYatterDataTypeException("Yatter.UI.ListBuilder.Serialization.YatterConvert");
            }

            var itemsJsonDto = JsonConvert.DeserializeObject<ItemsJsonDto>(json);

            if (itemsJsonDto != null)
            {
                var itemsjson = itemsJsonDto.Items;

                var list = DeserializeYatterListJson(JsonConvert.SerializeObject(itemsjson));

                if (list != null)
                {
                    yatter.Items = new System.Collections.ObjectModel.ObservableCollection<object>(list);
                }
            }

            ServiceDictionaryJsonDto obj = JsonConvert.DeserializeObject<ServiceDictionaryJsonDto>(json);

            foreach (var key in obj.ServiceDictionary.Keys)
            {
                Console.WriteLine();
                Console.WriteLine("y@tter:");
                Console.WriteLine($"    {key}, {obj.ServiceDictionary[key]}");
            }

            yatter.ServiceDictionary = obj.ServiceDictionary;

            return yatter;
        }
    }
}

