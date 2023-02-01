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
    public enum Checklist
    {
        Boeing738,
        AirbusA32NX,
        AnalogKingair
    }

    public partial class Main : Form
    {
        private Form checklist;

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

                    switch (int.Parse(btn.Tag.ToString()))
                    {
                        case (int)Checklist.Boeing738:
                            checklist = new Checklist738();
                            break;
                        default:
                            throw new Exception("Unkown checklist");
                    }

                    checklist.Show();
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
