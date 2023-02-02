using Checklist.Properties;
using Newtonsoft.Json;
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
        AnalogKingair
    }

    internal class ChecklistReader
    {
        public static string getResource(AircraftType type)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName;

            switch (type)
            {
                case AircraftType.Boeing738:
                    resourceName = Resources.B737_json;
                    break;
                case AircraftType.AirbusA32NX:
                    return "";
                case AircraftType.AnalogKingair:
                    return "";
                default:
                    return "";
            }

            return resourceName;
        }

        public static Checklist readChecklist(AircraftType type)
        {
            string resource = getResource(type);
            Debug.WriteLine(resource);

            Checklist checklist = JsonConvert.DeserializeObject<Checklist>(resource);

            return checklist;
        }
    }
}
