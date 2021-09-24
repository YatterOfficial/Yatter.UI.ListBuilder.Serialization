using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yatter.UI.ListBuilder.ListItems;
using Yatter.UI.ListBuilder.Serialization;
using Yatter.UI.ListBuilder.Serialization.Models;
using Yatter.UI.ListBuilder.Serialization.Exceptions;

using System.Reflection;

namespace Yatter.UI.ListBuilder.Serialization
{
    public static class YatterConvert
    {
        public static List<object> DeserializeYatterListJson(string json)
        {
            var list = new List<object>();

            var obj = JsonConvert.DeserializeObject<List<object>>(json);

            foreach (var item in obj)
            {
                var dto = JsonConvert.DeserializeObject<DataTypeDto>(item.ToString());

                var dataType = dto.DataType;

                Console.WriteLine(dataType);

                if (dataType.Equals("Label"))
                {
                    var tmp = JsonConvert.DeserializeObject<Label>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("H1"))
                {
                    var tmp = JsonConvert.DeserializeObject<H1>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("H2"))
                {
                    var tmp = JsonConvert.DeserializeObject<H2>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("H3"))
                {
                    var tmp = JsonConvert.DeserializeObject<H3>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("H4"))
                {
                    var tmp = JsonConvert.DeserializeObject<H4>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("H5"))
                {
                    var tmp = JsonConvert.DeserializeObject<H5>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("Base64Image"))
                {
                    var tmp = JsonConvert.DeserializeObject<Base64Image>(item.ToString());
                    list.Add(tmp);
                }
                else if (dataType.Equals("Entry"))
                {
                    var tmp = JsonConvert.DeserializeObject<Entry>(item.ToString());
                    list.Add(tmp);
                }

            }

            return list;
        }

        public static Yatter.UI.ListBuilder.Serialization.Models.Yatter DeserializeYatterJson(string json)
        {
            var response = new Yatter.UI.ListBuilder.Serialization.Models.Yatter();

            var datatypeDto = JsonConvert.DeserializeObject<DataTypeDto>(json);

            if (datatypeDto == null || !datatypeDto.DataType.ToLower().Equals("yatter"))
            {
                throw new NotYatterDataTypeException("HarryHotdog.UI.ListBuilder.Serialization.YatterConvert");
            }

            var itemsJsonDto = JsonConvert.DeserializeObject<ItemsJsonDto>(json);

            if (itemsJsonDto != null)
            {
                var itemsjson = itemsJsonDto.ItemsJson;

                var list = DeserializeYatterListJson(itemsjson);

                if (list != null)
                {
                    response.Items = list;
                }
            }

            var serviceDictionaryJsonDto = JsonConvert.DeserializeObject<ServiceDictionaryJsonDto>(json);

            if (serviceDictionaryJsonDto != null)
            {
                var serviceDictionaryJson = serviceDictionaryJsonDto.ServiceDictionaryJson;

                Dictionary<string, string> serviceDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(serviceDictionaryJson);

                if (serviceDictionary != null)
                {
                    response.ServiceDictionary = serviceDictionary;
                }
            }

            return response;
        }
    }
}

