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
                if (value < -1 || value >= Items.Count) return; // new index out of range
                if (selectedIndex > -1)
                    Items.ElementAt(selectedIndex).Select(false); // remove old select

                if (value > -1 && (value < Items.Count - 1 || Information))
                    Items.ElementAt(value).Select(true);    // select new index,
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
            foreach (Item item in Items)
            {
                if (item is CheckItem checkItem)
                {
                    checkItem.ResponseCheck.Checked = check;
                }
            }
        }

        public Label GetSelectedChallenge(int offset = 0)
        {
            int index = SelectedIndex + offset;
            if (index < 0)
                return Items.First.Value.ChallengeLabel;
            else if (index < Items.Count)
                return Items.ElementAt(index).ChallengeLabel;
            else
                return Items.Last.Value.ChallengeLabel;
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
