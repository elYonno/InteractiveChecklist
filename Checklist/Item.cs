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
    public enum ItemType
    {
        [EnumMember(Value = "CheckItem")]
        CheckItem,
        [EnumMember(Value = "Title")]
        Title,
        [EnumMember(Value = "Information")]
        Information
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

        protected void DrawNextRow(TableLayoutPanel table, ref int row)
        {
            row++;
            DrawDescription(table, ref row);
            DrawSubItems(table, ref row);
        }

        private void DrawDescription(TableLayoutPanel table, ref int row)
        {
            if (Description != null)
            {
                RichTextBox description = new RichTextBox
                {
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    Enabled = false,
                    Text = Description,
                    Margin = new Padding(3, 3, 3, 3),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = new Font("Microsoft Sans Serif", 11),
                    ForeColor = Color.Gray
                };

                table.Controls.Add(description, 0, row);
                table.SetColumnSpan(description, 2);
                row++;
            }
        }

        private void DrawSubItems(TableLayoutPanel table, ref int row)
        {

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

            DrawNextRow(table, ref row);
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

            DrawNextRow(table, ref row);
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

            DrawNextRow(table, ref row);
        }
    }
}
