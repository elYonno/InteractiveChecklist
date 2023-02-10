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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
        public static int FONT_SIZE = 14;

        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Type { get; set; }
        public string Challenge { get; set; }
        public Label ChallengeLabel { get; protected set; }
        public string Response { get; set; }
        public string Description { get; set; }
        public Label DescriptionLabel { get; protected set; }
        public List<Item> SubItems { get; set; }
        public bool Selected { get; private set; }

        public Label GetLowestLabel()
        {
            // if desc not null return it, or return challenge
            return DescriptionLabel ?? ChallengeLabel;
        }

        public abstract void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0);

        public virtual void Select(bool select)
        {
            Selected = select;
        }

        public virtual void UpdateFontSize()
        {
            if (ChallengeLabel != null)
                ChallengeLabel.Font = new Font(ChallengeLabel.Font.FontFamily, FONT_SIZE);

            if (DescriptionLabel != null)
                DescriptionLabel.Font = new Font(ChallengeLabel.Font.FontFamily, FONT_SIZE);

        }

        public virtual void Check(bool check)
        {
            // do nothing
        }

        protected void DrawChallenge(TableLayoutPanel table, ref int row, int identation)
        {
            if (Challenge == null) throw new ArgumentException();

            ChallengeLabel = new Label
            {
                AutoSize = true,
                Text = Challenge,
                Margin = new Padding(3 + IDENT_PAD * identation, 3, 0, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", FONT_SIZE),
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
                    Font = new Font("Microsoft Sans Serif", FONT_SIZE),
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
                DescriptionLabel = new Label
                {
                    MaximumSize = new Size(table.Width * 4, 0),
                    AutoSize = true,
                    Text = Description,
                    Margin = new Padding(3 + IDENT_PAD * identation, 0, 3, 3),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = new Font("Microsoft Sans Serif", 11),
                    ForeColor = Color.Gray
                };

                table.Controls.Add(DescriptionLabel, 0, row);
                table.SetColumnSpan(DescriptionLabel, 2);
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
                Margin = new Padding(0, 3, 3, 3),
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", FONT_SIZE),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            ChallengeLabel.Click += (s, e) => ResponseCheck.Checked = !ResponseCheck.Checked;
            section.AddCheckBox(ResponseCheck, Optional);

            if (Optional) ResponseCheck.ForeColor = Color.Gray;
            table.Controls.Add(ResponseCheck, 1, row);

            DrawNextRow(table, section, ref row, identation);
        }

        public override void Select(bool select)
        {
            base.Select(select);

            if (select)
            {
                ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                               FONT_SIZE,
                                               FontStyle.Bold | FontStyle.Italic);
                ChallengeLabel.BackColor = Color.LightBlue;

                ResponseCheck.Font = new Font("Microsoft Sans Serif",
                                              FONT_SIZE,
                                              FontStyle.Bold | FontStyle.Italic);
                ResponseCheck.BackColor = Color.LightBlue;
            }
            else
            {
                ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                               FONT_SIZE);
                ChallengeLabel.BackColor = Color.Transparent;

                ResponseCheck.Font = new Font("Microsoft Sans Serif",
                                              FONT_SIZE);
                ResponseCheck.BackColor = Color.Transparent;
            }
        }

        public override void UpdateFontSize()
        {
            base.UpdateFontSize();

            if (ResponseCheck != null)
            {
                ResponseCheck.Font = new Font(ResponseCheck.Font.FontFamily, FONT_SIZE);
                Select(Selected);
            }
        }

        public void Toggle()
        {
            ResponseCheck.Checked = !ResponseCheck.Checked;
        }

        public override void Check(bool check)
        {
            if (ResponseCheck != null)
            {
                ResponseCheck.Checked = check;
            }
        }
    }

    internal class Information : Item
    {
        /// <summary>
        /// If true, challenge label will be bold
        /// </summary>
        public bool Instruction { get; set; } = false;
        public Label ResponseLabel { get; private set; }

        public Information() { }

        public Information(string info) => Challenge = info;

        public override void Draw(TableLayoutPanel table, Section section, ref int row, int identation = 0)
        {
            DrawChallenge(table, ref row, identation);
            if (Instruction) ChallengeLabel.Font = new Font("Microsoft Sans Serif", FONT_SIZE, FontStyle.Bold);

            if (Response != null)
            {
                ResponseLabel = new Label
                {
                    AutoSize = true,
                    Text = Response,
                    Margin = new Padding(3, 3, 3, 3),
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Font = new Font("Microsoft Sans Serif", FONT_SIZE),
                    TextAlign = ContentAlignment.MiddleRight
                };
                table.Controls.Add(ResponseLabel, 1, row);
            }

            DrawNextRow(table, section, ref row, identation);
        }

        public override void Select(bool select)
        {
            base.Select(select);

            if (select)
            {
                ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                               FONT_SIZE,
                                               FontStyle.Bold | FontStyle.Italic);

                if (Response != null)
                    ResponseLabel.Font = new Font("Microsoft Sans Serif",
                                                  FONT_SIZE,
                                                  FontStyle.Bold | FontStyle.Italic);
            }
            else
            {
                if (Instruction)
                    ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                                   FONT_SIZE,
                                                   FontStyle.Bold);
                else
                    ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                                   FONT_SIZE);
                if (Response != null)
                    ResponseLabel.Font = new Font("Microsoft Sans Serif",
                                                  FONT_SIZE);
            }
        }

        public override void UpdateFontSize()
        {
            base.UpdateFontSize();

            if (ResponseLabel != null)
                ResponseLabel.Font = new Font(ResponseLabel.Font.FontFamily, FONT_SIZE);
            
            if (ChallengeLabel != null)
                Select(Selected);
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
                Font = new Font("Microsoft Sans Serif", FONT_SIZE + 2, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            table.Controls.Add(ChallengeLabel, 0, row);
            table.SetColumnSpan(ChallengeLabel, 2);

            DrawNextRow(table, section, ref row, identation);
        }

        public override void Select(bool select)
        {
            base.Select(select);

            if (select)
            {
                ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                               FONT_SIZE + 2,
                                               FontStyle.Bold | FontStyle.Italic);
            }
            else
            {
                ChallengeLabel.Font = new Font("Microsoft Sans Serif",
                                               FONT_SIZE + 2,
                                               FontStyle.Bold);
            }
        }

        public override void UpdateFontSize()
        {
            if (ChallengeLabel != null)
            {
                ChallengeLabel.Font = new Font(ChallengeLabel.Font.FontFamily, FONT_SIZE + 2);
                Select(Selected);
            }
        }
    }
}
