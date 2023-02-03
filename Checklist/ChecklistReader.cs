using Checklist.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Checklist
{
    public enum AircraftType
    {
        Boeing738,
        AirbusA32NX,
        AnalogKingAir
    }

    internal class ChecklistReader
    {
        public static string GetResource(AircraftType type)
        {
            string resourceName;

            switch (type)
            {
                case AircraftType.Boeing738:
                    resourceName = Resources.B737_json;
                    break;
                case AircraftType.AirbusA32NX:
                    return "";
                case AircraftType.AnalogKingAir:
                    return "";
                default:
                    return "";
            }

            return resourceName;
        }

        public static Checklist ReadChecklist(AircraftType type)
        {
            string resource = GetResource(type);

            Checklist checklist = JsonConvert.DeserializeObject<Checklist>(resource,
                new ItemConverter());

            return checklist;
        }
    }

    /// <summary>
    /// Converts class Item into their respective subclass.
    /// If able to update to .NET 7, use the new Json convert implementation.
    /// </summary>
    public class ItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Item).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            JObject j = JObject.Load(reader);

            ItemType type = (ItemType)Enum.Parse(typeof(ItemType), (string)j["Type"]);
            Item item;

            switch (type)
            {
                case ItemType.CheckItem:
                    item = new CheckItem();
                    break;
                case ItemType.Title:
                    item = new Title();
                    break;
                case ItemType.Information:
                    item = new Information();
                    break;
                default:
                    throw new ArgumentException();
            }

            serializer.Populate(j.CreateReader(), item);
            return item;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
