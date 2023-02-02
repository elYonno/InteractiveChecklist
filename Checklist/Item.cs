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
        public static readonly int IDENT_PAD = 30;

        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Type { get; set; }
        public string Challenge { get; set; }
        public string Response { get; set; }
        public string Description { get; set; }
        public List<Item> SubItems { get; set; }

        public abstract void Draw(TableLayoutPanel table, ref int row, int identation = 0);

        protected void DrawChallenge(TableLayoutPanel table, ref int row, int identation)
        {
            Label challenge = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3 + IDENT_PAD * identation, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleLeft
            };

            table.Controls.Add(challenge, 0, row);
        }

        protected void DrawNextRow(TableLayoutPanel table, ref int row, int identation)
        {
            row++;
            DrawDescription(table, ref row, identation);
            DrawSubItems(table, ref row, identation);
        }

        private void DrawDescription(TableLayoutPanel table, ref int row, int identation)
        {
            if (Description != null)
            {
                RichTextBox description = new RichTextBox
                {
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    Enabled = false,
                    Text = Description,
                    Margin = new Padding(3 + IDENT_PAD * identation, 3, 3, 3),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = new Font("Microsoft Sans Serif", 11),
                    ForeColor = Color.Gray
                };

                table.Controls.Add(description, 0, row);
                table.SetColumnSpan(description, 2);
                row++;
            }
        }

        private void DrawSubItems(TableLayoutPanel table, ref int row, int identation)
        {
            if (SubItems != null)
            {
                foreach (var subItem in SubItems)
                    subItem.Draw(table, ref row, identation + 1);
            }
        }
    }

    internal class CheckItem : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row, int identation = 0)
        {
            DrawChallenge(table, ref row, identation);

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

            DrawNextRow(table, ref row, identation);
        }
    }

    internal class Information : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row, int identation = 0)
        {
            DrawChallenge(table, ref row, identation);

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

            DrawNextRow(table, ref row, identation);
        }
    }

    internal class Title : Item
    {
        public override void Draw(TableLayoutPanel table, ref int row, int identation = 0)
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

            DrawNextRow(table, ref row, identation);
        }
    }
}
