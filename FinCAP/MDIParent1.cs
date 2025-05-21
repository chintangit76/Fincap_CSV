using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinCAP_CSV
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ledgerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Type t = Type.GetType("FinCAP_CSV.FrmGetGrp_Name");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }

        private void generateTallyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Type t = Type.GetType("FinCAP_CSV.FrmRead_Save_CSV");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }

        private void CheckAndCloseForm()
        {
            //DateTime specifiedDate = new DateTime(2024, 1, 26);

            //if (DateTime.Now > specifiedDate)
            //{
            //    //MessageBox.Show("The specified date has passed. Closing the form.");
            //    //Close();
            //    //Application.Exit();
            //}
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            CheckAndCloseForm();
        }

        private void exitTSMenu_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Application.Exit();
        }

        private void uploadLedgerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type t = Type.GetType("FinCAP.FrmUploadMappingMst");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }

        private void TSM_FixLedger_Click(object sender, EventArgs e)
        {
            Type t = Type.GetType("FinCAP.FrmFixLedger");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }

        private void uploadBankStatementTSMenu_Click(object sender, EventArgs e)
        {
            Type t = Type.GetType("FinCAP.FrmBankStatement");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }

        private void defaultLedgerSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type t = Type.GetType("FinCAP.FrmBank_DefaultLedger");
            Form c = Activator.CreateInstance(t) as Form;
            c.MdiParent = this;
            c.MinimizeBox = false;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
        }
    }
}
