using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checklist
{
    internal class Checklist
    {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
    }

    internal class Section
    {
        public string Name { get; set; }
        public bool Information { get; set; }
        public LinkedList<Item> Items { get; set; }
        /// <summary>
        /// All items and sub items in one list
        /// </summary>
        public LinkedList<Item> UnravelledItems { get; set; }

        // UI
        public bool Drawn { get; set; } = false;
        private Label sectionDoneLabel;
        public Label SectionDoneLabel
        {
            get { return sectionDoneLabel; }
            set
            {
                sectionDoneLabel = value;
                sectionDoneLabel.Visible = false;
            }
        }

        private int selectedIndex = -1;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value < -1 || value >= UnravelledItems.Count) return; // new index out of range
                if (selectedIndex > -1)
                    UnravelledItems.ElementAt(selectedIndex).Select(false); // remove old select

                if (value > -1 && (value < UnravelledItems.Count || Information))
                    UnravelledItems.ElementAt(value).Select(true);    // select new index,
                                                                      // excluding checklist complete

                selectedIndex = value;
            }
        }

        public TabPage Page { get; set; }
        public ChecklistForm Form { get; set; }
        public int MandatorySize { get; private set; }
        public int MadatoryCheckedCount { get; private set; } = 0;

        public void AddCheckBox(CheckBox checkBox, bool optional)
        {
            // only mandatory check items
            if (!optional)
            {
                MandatorySize++;
                checkBox.CheckedChanged += Mandatory_Checked_Changed;
            }
        }

        public void SetChecked(bool check)
        {
            foreach (Item item in UnravelledItems)
                item.Check(check);
        }

        public Label GetSelectedChallenge(int offset = 0)
        {
            if (UnravelledItems == null) GenerateUnravelledItems();

            int index = SelectedIndex + offset;
            if (index < 0)
                return UnravelledItems.First.Value.ChallengeLabel;
            else if (index < UnravelledItems.Count)
                return UnravelledItems.ElementAt(index).ChallengeLabel;
            else
                return UnravelledItems.Last.Value.GetLowestLabel();
        }

        public void GenerateUnravelledItems()
        {
            UnravelledItems = new LinkedList<Item>();

            foreach (Item item in Items)
            {
                UnravelledItems.AddLast(item);
                if (item.SubItems != null)
                {
                    foreach (Item subitem in item.SubItems)
                        UnravelledItems.AddLast(subitem);
                }
            }
        }

        public void ToggleSelection()
        {
            if (SelectedIndex != -1)
            {
                Item item = UnravelledItems.ElementAt(SelectedIndex);

                if (item is CheckItem checkItem)
                    checkItem.Toggle();
            }
        }

        public void UpdateFontSize()
        {
            // update title
            Items.First.Value.UpdateFontSize();

            // update items
            foreach (Item item in UnravelledItems)
                item.UpdateFontSize();

            // update section done
            SectionDoneLabel.Font = new System.Drawing.Font(SectionDoneLabel.Font.FontFamily,
                                                            Item.FONT_SIZE);
        }

        private void Mandatory_Checked_Changed(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked)
            {
                MadatoryCheckedCount++;
                if (MadatoryCheckedCount == MandatorySize)
                {
                    Page.Text = Name + "✓";
                    SectionDoneLabel.Visible = true;
                    Page.ScrollControlIntoView(SectionDoneLabel);
                }
            }
            else
            {
                if (MadatoryCheckedCount == MandatorySize)
                {
                    Page.Text = Name;
                    SectionDoneLabel.Visible = false;
                }

                MadatoryCheckedCount--;
            }

            Form.UpdateCount();
        }
    }
}
