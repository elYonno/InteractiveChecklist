using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checklist
{
    internal enum ItemType
    {
        [EnumMember(Value = "CheckItem")]
        CheckItem,
        [EnumMember(Value = "Title")]
        Title,
        [EnumMember(Value = "Information")]
        Information
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

            ItemType type = (ItemType) Enum.Parse(typeof(ItemType), (string)j["Type"]);
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

    internal abstract class Item
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Type { get; set; }
        public string Challenge { get; set; }
        public string Response { get; set; }
        public string Description { get; set; }
        public List<Item> SubItems { get; set; }

        public abstract void Draw(TableLayoutPanel table, ref int row);

        protected void DrawChallenge(TableLayoutPanel table, ref int row)
        {
            Label challenge = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleLeft
            };

            table.Controls.Add(challenge, 0, row);
        }
    }

    internal class CheckItem : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row)
        {
            DrawChallenge(table, ref row);

            Control response = new CheckBox
            {
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Text = Response,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign= ContentAlignment.MiddleRight
            };
            table.Controls.Add(response, 1, row);

            row++;
        }
    }

    internal class Information : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row)
        {
            DrawChallenge(table, ref row);

            Control response = new Label
            {
                AutoSize = true,
                Text = Response,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleRight
            };
            table.Controls.Add(response, 1, row);

            row++;
        }
    }

    internal class Title : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row)
        {
            Control title = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            table.Controls.Add(title, 0, row);
            table.SetColumnSpan(title, 2);

            row++;
        }
    }
}
