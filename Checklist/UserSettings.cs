using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checklist
{
    public partial class UserSettings : Form
    {
        ChecklistForm form;

        public UserSettings(ChecklistForm form)
        {
            InitializeComponent();
            this.form = form;

            LblTabletControlAlign.Enabled = form.TabletMode;
            BoxAlign.Enabled = form.TabletMode;
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            NumFontSize.Value = form.Settings.FontSize;
            BoxAlign.SelectedIndex = (int) form.Settings.Align;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            form.Settings = new ChecklistSettings((int)NumFontSize.Value,
                                                  (ChecklistSettings.ControlAlign)BoxAlign.SelectedIndex);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
