using System.Windows.Forms;
using System.Drawing;

namespace Checklist
{
    public partial class ChecklistForm : Form
    {
        private Checklist checklist;

        /// <summary>
        /// Populate the form with the whole checklist depending on the aircraft type.
        /// Will read from the Json deserializer in ChecklistReader.
        /// </summary>
        /// <param name="type">Type of aircraft</param>
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

        /// <summary>
        /// Adds a tab page to the TabControl and populate it with the items from that section.
        /// </summary>
        /// <param name="section">Section to be populated.</param>
        private void createSection(Section section)
        {
            TabPage page = new TabPage(section.Name);

            TableLayoutPanel table = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top
            };

            int row = 0;
            foreach (Item item in section.Items)
                item.Draw(table, ref row);

            foreach (RowStyle style in table.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }

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
