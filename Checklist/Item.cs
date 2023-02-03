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
        public Label ChallengeLabel { get; protected set; }
        public string Response { get; set; }
        public string Description { get; set; }
        public List<Item> SubItems { get; set; }

        public abstract void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0);

        protected void DrawChallenge(TableLayoutPanel table, ref int row, int identation)
        {
            ChallengeLabel = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3 + IDENT_PAD * identation, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            table.Controls.Add(ChallengeLabel, 0, row);
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
        /// <summary>
        /// If true, challenge and response label will be gray
        /// </summary>
        public bool Optional { get; set; } = false;
        public CheckBox ResponseCheck { get; private set; }

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            DrawChallenge(table, ref row, identation);

            if (Optional) ChallengeLabel.ForeColor= Color.Gray;

            ResponseCheck = new CheckBox
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

            ChallengeLabel.Click += (s, e) => ResponseCheck.Checked = !ResponseCheck.Checked;
            section.AddCheckBox(ResponseCheck, Optional);

            if (Optional) ResponseCheck.ForeColor = Color.Gray;
            table.Controls.Add(ResponseCheck, 1, row);

            DrawNextRow(table, section, ref row, identation);
        }
    }

    internal class Information : Item
    {
        /// <summary>
        /// If true, challenge label will be bold
        /// </summary>
        public bool Instruction { get; set; } = false;

        public Information() { }

        public Information(string info) => Challenge = info;

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            DrawChallenge(table, ref row, identation);
            if (Instruction) ChallengeLabel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

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
        public Title() { }

        public Title(string title) => Challenge = title;

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            ChallengeLabel = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            table.Controls.Add(ChallengeLabel, 0, row);
            table.SetColumnSpan(ChallengeLabel, 2);

            DrawNextRow(table, section, ref row, identation);
        }
    }
}
