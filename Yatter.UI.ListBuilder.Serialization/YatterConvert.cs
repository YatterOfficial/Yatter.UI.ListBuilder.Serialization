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

                string dataType = dto.DataType;

                if(dataType.Substring(0,1).Equals("y")&& dataType.Substring(1, 1).Equals("@"))
                {
                    dataType = dataType.Replace("y@", "Yatter.UI.ListBuilder.ListItems.");
                }

                if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.Label"))
                {
                    var tmp = JsonConvert.DeserializeObject<Label>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.Label";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.H1"))
                {
                    var tmp = JsonConvert.DeserializeObject<H1>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.H1";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.H2"))
                {
                    var tmp = JsonConvert.DeserializeObject<H2>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.H2";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.H3"))
                {
                    var tmp = JsonConvert.DeserializeObject<H3>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.H3";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.H4"))
                {
                    var tmp = JsonConvert.DeserializeObject<H4>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.H4";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.H5"))
                {
                    var tmp = JsonConvert.DeserializeObject<H5>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.H5";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.IconTitle"))
                {
                    var tmp = JsonConvert.DeserializeObject<IconTitle>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.IconTitle";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.Base64Image"))
                {
                    var tmp = JsonConvert.DeserializeObject<Base64Image>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.Base64Image";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.Entry"))
                {
                    var tmp = JsonConvert.DeserializeObject<Entry>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.Entry";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.TextPanel"))
                {
                    var tmp = JsonConvert.DeserializeObject<TextPanel>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.TextPanel";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.WebPage"))
                {
                    var tmp = JsonConvert.DeserializeObject<WebPage>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.WebPage";
                    list.Add(tmp);
                }
                else if (dataType.Equals("Yatter.UI.ListBuilder.ListItems.YouTubeVideo"))
                {
                    var tmp = JsonConvert.DeserializeObject<YouTubeVideo>(item.ToString());
                    tmp.DataType = "Yatter.UI.ListBuilder.ListItems.YouTubeVideo";
                    list.Add(tmp);
                }

            }

            return list;
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

