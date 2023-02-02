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

        public abstract void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0);

        protected Label DrawChallenge(TableLayoutPanel table, ref int row, int identation)
        {
            Label challenge = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3 + IDENT_PAD * identation, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            table.Controls.Add(challenge, 0, row);

            return challenge;
        }

        protected void DrawNextRow(TableLayoutPanel table, Section section, ref int row, int identation)
        {
            row++;
            DrawDescription(table, ref row, identation);

            if (Response != null)
            {
                Label divider = new Label
                {
                    Text = new string('‾', 1000),
                    Margin = new Padding(3 + IDENT_PAD * identation, 0, 3, 3),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = new Font("Microsoft Sans Serif", 14),
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Top
                };
                table.Controls.Add(divider, 0, row);
                table.SetColumnSpan(divider, 2);
                
                row++;
            }

            DrawSubItems(table, section, ref row, identation);
        }

        private void DrawDescription(TableLayoutPanel table, ref int row, int identation)
        {
            if (Description != null)
            {
                Label description = new Label
                {
                    MaximumSize = new Size(table.Width * 4, 0),
                    AutoSize = true,
                    Text = Description,
                    Margin = new Padding(3 + IDENT_PAD * identation, 0, 3, 3),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = new Font("Microsoft Sans Serif", 11),
                    ForeColor = Color.Gray
                };

                table.Controls.Add(description, 0, row);
                table.SetColumnSpan(description, 2);
                row++;
            }
        }

        private void DrawSubItems(TableLayoutPanel table, Section section, ref int row, int identation)
        {
            if (SubItems != null)
            {
                foreach (var subItem in SubItems)
                    subItem.Draw(table, section, ref row, identation + 1);
            }
        }
    }

    internal class CheckItem : Item
    {
        public bool Optional { get; set; } = false;

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            Label challenge = DrawChallenge(table, ref row, identation);

            if (Optional) challenge.ForeColor= Color.Gray;

            CheckBox response = new CheckBox
            {
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Text = Response,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            challenge.Click += (s, e) => response.Checked = !response.Checked;
            section.AddCheckBox(response, Optional);

            if (Optional) response.ForeColor = Color.Gray;
            table.Controls.Add(response, 1, row);

            DrawNextRow(table, section, ref row, identation);
        }
    }

    internal class Information : Item
    {
        public bool Instruction { get; set; } = false;

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            Label label = DrawChallenge(table, ref row, identation);
            if (Instruction) label.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

            if (Response != null)
            {
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
            }

            DrawNextRow(table, section, ref row, identation);
        }
    }

    internal class Title : Item
    {
        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
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

            DrawNextRow(table, section, ref row, identation);
        }
    }
}
