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
        public List<CheckBox> CheckItems { get; set; }
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
        public TabPage Page { get; set; }
        public ChecklistForm Form { get; set; }
        public int MandatorySize { get; private set; }
        public int MadatoryCheckedCount { get; private set; } = 0;

        public Section()
        {
            CheckItems = new List<CheckBox>();
        }

        public void AddCheckBox(CheckBox checkBox, bool optional)
        {
            CheckItems.Add(checkBox);

            // only mandatory check items
            if (!optional)
            {
                MandatorySize++;
                checkBox.CheckedChanged += Mandatory_Checked_Changed;
            }
        }

        public void SetChecked(bool check)
        {
            foreach (CheckBox checkBox in CheckItems)
                checkBox.Checked = check;
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
