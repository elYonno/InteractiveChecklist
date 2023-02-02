using System.Windows.Forms;
using System.Drawing;

namespace Checklist
{
    public partial class ChecklistForm : Form
    {
        private Checklist checklist;

        public ChecklistForm(AircraftType type = AircraftType.Boeing738)
        {
            InitializeComponent();
            checklist = ChecklistReader.readChecklist(type);

            // set title
            Text = checklist.Name;

            // create sections
            sectionsControl.TabPages.Clear();

            foreach (Section section in checklist.Sections)
            {
                createSection(section);
            }
        }

        private void createSection(Section section)
        {
            TabPage page = new TabPage(section.Name);

            TableLayoutPanel table = new TableLayoutPanel();
            table.AutoSize = true;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            table.Dock = DockStyle.Top;

            int row = 0;
            foreach (Item item in section.Items)
                item.Draw(table, ref row);

            page.Controls.Add(table);

            page.AutoScroll = false;
            page.HorizontalScroll.Enabled = false;
            page.HorizontalScroll.Visible = false;
            page.HorizontalScroll.Maximum = 0;
            page.AutoScroll = true;

            sectionsControl.TabPages.Add(page);
        }
    }
}
