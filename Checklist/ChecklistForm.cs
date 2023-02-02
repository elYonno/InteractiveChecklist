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
            {
                createItem(table, item, ref row);
            }

            page.Controls.Add(table);

            page.AutoScroll = false;
            page.HorizontalScroll.Enabled = false;
            page.HorizontalScroll.Visible = false;
            page.HorizontalScroll.Maximum = 0;
            page.AutoScroll = true;

            sectionsControl.TabPages.Add(page);
        }

        private void createItem(TableLayoutPanel table, Item item, ref int row)
        {
            Label challenge = new Label
            {
                AutoSize = true,
                Text = item.Challenge,
                Margin = new Padding(3, 3, 3, 3),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            table.Controls.Add(challenge, 0, row);

            Control response;
            if (item.CheckItem)
            {
                response = new CheckBox
                {
                    AutoSize = true,
                    CheckAlign = ContentAlignment.MiddleRight,
                    Text = item.Response,
                    Margin = new Padding(3, 3, 3, 3),
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Font = new Font("Microsoft Sans Serif", 14)
                };
            }
            else
            {
                response = new Label
                {
                    AutoSize = true,
                    Text = item.Response,
                    Margin = new Padding(3, 3, 3, 3),
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Font = new Font("Microsoft Sans Serif", 14)
                };
            }
            table.Controls.Add(response, 1, row);

            row++;
        }
    }
}
