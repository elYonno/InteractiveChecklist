using System.Windows.Forms;
using System.Drawing;
using static System.Collections.Specialized.BitVector32;
using System.Configuration;

namespace Checklist
{
    public partial class ChecklistForm : Form
    {
        private ChecklistSettings settings = new ChecklistSettings();
        public ChecklistSettings Settings {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
                ApplyNewSettings();
            }
        }

        private readonly Checklist checklist;
        public bool TabletMode { get; private set; }
        private Section selectedSection;

        /// <summary>
        /// Populate the form with the whole checklist depending on the aircraft type.
        /// Will read from the Json deserializer in ChecklistReader.
        /// </summary>
        /// <param name="type">Type of aircraft</param>
        /// <param name="tabletMode">If true, better suited for touchscreen use.</param>
        public ChecklistForm(AircraftType type = AircraftType.Boeing738, bool tabletMode = true)
        {
            InitializeComponent();

            checklist = ChecklistReader.ReadChecklist(type);

            TabletMode = tabletMode;
            pnlTouchScreen.Visible = tabletMode;

            // set title
            Text = checklist.Name;

            // create sections
            sectionsControl.TabPages.Clear();

            foreach (Section section in checklist.Sections)
            {
                CreateSection(section);
            }

            OnSectionChange();
        }

        /// <summary>
        /// Adds a tab page to the TabControl named that section.
        /// </summary>
        /// <param name="section">Section to be populated.</param>
        private void CreateSection(Section section)
        {
            section.GenerateUnravelledItems();

            TabPage page = new TabPage(section.Name)
            {
                AutoScroll = false
            };

            // only allow vertical scroll
            page.HorizontalScroll.Enabled = false;
            page.HorizontalScroll.Visible = false;
            page.HorizontalScroll.Maximum = 0;
            page.VerticalScroll.Enabled = !TabletMode;
            page.VerticalScroll.Visible = !TabletMode;
            page.AutoScroll = true;

            section.Page = page;
            section.Form = this;

            sectionsControl.TabPages.Add(page);
        }

        public void UpdateCount()
        {
            int count = selectedSection.MadatoryCheckedCount;
            int size = selectedSection.MandatorySize;

            lblCount.Text = count + "/" + size;

            progressCount.Maximum = size;
            progressCount.Value = count;
        }

        /// <summary>
        /// Populate selected section if it has not been drawn.
        /// </summary>
        private void DrawSelectedSection()
        {
            if (!selectedSection.Drawn)
            {
                // add extra items
                selectedSection.Items.AddFirst(new Title(selectedSection.Name));

                Information info = null;
                if (!selectedSection.Information)
                {
                    info = new Information($"{selectedSection.Name} checklist complete.");
                    selectedSection.Items.AddLast(info);
                }

                // use creted tab page
                TabPage page = selectedSection.Page;
                TableLayoutPanel table = new TableLayoutPanel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Dock = DockStyle.Top
                };

                // draw all items
                int row = 0;
                foreach (Item item in selectedSection.Items)
                    item.Draw(table, selectedSection, ref row);

                // connect checklist complete message
                if (info != null)
                    selectedSection.SectionDoneLabel = info.ChallengeLabel;

                // populate tab page
                page.Controls.Add(table);
                selectedSection.Drawn = true;

                UpdateCount();
            }
        }

        private void OnSectionChange()
        {
            if (selectedSection != null) selectedSection.SelectedIndex = -1;     // reset index
            selectedSection = checklist.Sections[sectionsControl.SelectedIndex];

            // hide count when in an information section
            lblCount.Visible = !selectedSection.Information;
            progressCount.Visible = !selectedSection.Information;
            separatorCount.Visible = !selectedSection.Information;
            btnComplete.Visible = !selectedSection.Information;
            btnResetCurrent.Visible = !selectedSection.Information;

            UpdateCount();
            DrawSelectedSection();

            selectedSection.SelectedIndex = 0;
        }

        private void ApplyNewSettings()
        {
            pnlTouchScreen.Dock = (DockStyle)(3 + Settings.Align);

            Item.FONT_SIZE = Settings.FontSize;
            foreach (Section section in checklist.Sections)
                section.UpdateFontSize();
        }

        private void BtnPrevCheck_Click(object sender, System.EventArgs e)
        {
            int index = sectionsControl.SelectedIndex;
            index--;
            if (index >= 0)
                sectionsControl.SelectedIndex = index;
        }

        private void BtnNextChecklist_Click(object sender, System.EventArgs e)
        {
            int index = sectionsControl.SelectedIndex;
            index++;
            if (index < sectionsControl.TabCount)
                sectionsControl.SelectedIndex = index;
        }

        private void SectionsControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OnSectionChange();
        }

        private void BtnComplete_Click(object sender, System.EventArgs e)
        {
            selectedSection.SetChecked(true);
            BtnNextChecklist_Click(sender, e);
        }        

        private void BtnResetAll_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Reset checklist?",
                                                  "Reset",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (Section section in checklist.Sections)
                    section.SetChecked(false);
                sectionsControl.SelectedIndex = 0;
            }
        }

        private void BtnResetCurrent_Click(object sender, System.EventArgs e)
        {
            selectedSection.SetChecked(false);
        }

        private void BtnDown_Click(object sender, System.EventArgs e)
        {
            selectedSection.SelectedIndex++;
            selectedSection.Page.ScrollControlIntoView(selectedSection.GetSelectedChallenge(2));
        }

        private void BtnUp_Click(object sender, System.EventArgs e)
        {
            selectedSection.SelectedIndex--;
            selectedSection.Page.ScrollControlIntoView(selectedSection.GetSelectedChallenge(-2));
        }

        private void BtnSelect_Click(object sender, System.EventArgs e)
        {
            selectedSection.ToggleSelection();
            BtnDown_Click(sender, e);
        }

        public void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    BtnUp_Click(sender, e);
                    break;
                case Keys.Down:
                    BtnDown_Click(sender, e);
                    break;
                case Keys.Enter:    // same as space
                case Keys.Space:
                    BtnSelect_Click(sender, e);
                    break;
            }
        }

        private void BtnSettings_Click(object sender, System.EventArgs e)
        {
            UserSettings settings = new UserSettings(this);
            settings.Show();
        }

    }

    public class ChecklistSettings
    {
        public enum ControlAlign
        {
            Left,
            Right
        }

        public int FontSize { get; set; }
        public ControlAlign Align { get; set; }

        public ChecklistSettings(int fontSize = 14, ControlAlign align = ControlAlign.Left)
        {
            FontSize = fontSize;
            Align = align;
        }
    }
}
