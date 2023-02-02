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
        public List<Item> Items { get; set; }

        // UI
        public List<CheckBox> CheckItems { get; set; }
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

            if (!optional)
            {
                MandatorySize++;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            }
        }

        public void SetChecked(bool check)
        {
            foreach (CheckBox checkBox in CheckItems)
                checkBox.Checked = check;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked)
            {
                MadatoryCheckedCount++;
                if (MadatoryCheckedCount == MandatorySize)
                    Page.Text = Name + "✓";
            }
            else
            {
                if (MadatoryCheckedCount == MandatorySize)
                    Page.Text = Name;
                MadatoryCheckedCount--;
            }

            Form.UpdateCount();
        }
    }
}
