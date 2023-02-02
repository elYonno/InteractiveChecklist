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
    public partial class Main : Form
    {
        private ChecklistForm checklist;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void openChecklist(object sender, EventArgs e)
        {
            try
            {
                if (checklist != null)
                {
                    checklist.Close();
                    checklist = null;
                }

                if (sender is Button)
                {
                    Button btn = (Button)sender;
                    int tag = int.Parse(btn.Tag.ToString());

                    if (Enum.IsDefined(typeof(AircraftType), tag))
                    {
                        checklist = new ChecklistForm((AircraftType) tag);
                        checklist.Show();
                    }
                    else
                        throw new Exception("Unkown checklist.");
                }
                else
                    throw new Exception("Unknown event sender.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
