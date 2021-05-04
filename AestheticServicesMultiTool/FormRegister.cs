using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace AestheticServicesMultiTool
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            this.btn_Register.Enter += new System.EventHandler(Lib.UIEvent.ctrl_Enter);
            this.btn_Register.Leave += new System.EventHandler(Lib.UIEvent.ctrl_Leave);
            this.cb_acceptToS.Enter += new System.EventHandler(Lib.UIEvent.ctrl_Enter);
            this.cb_acceptToS.Leave += new System.EventHandler(Lib.UIEvent.ctrl_Leave);
            this.btn_Register.Enter += new System.EventHandler(Lib.UIEvent.ctrl_Enter);
            this.btn_Register.Leave += new System.EventHandler(Lib.UIEvent.ctrl_Leave);
            this.tb_Password_confirm.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Password_confirm.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.tb_Password.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Password.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.tb_Username.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Username.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.tb_Register_key.Enter += new System.EventHandler(Lib.UIEvent.tb_Enter);
            this.tb_Register_key.Leave += new System.EventHandler(Lib.UIEvent.tb_Leave);
            this.panel_grab.MouseDown += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseDown);
            this.panel_grab.MouseMove += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseMove);
            this.panel_grab.MouseUp += new System.Windows.Forms.MouseEventHandler(Lib.UIEvent.panel_grab_MouseUp);
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_acceptToS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                (sender as CheckBox).Checked = !(sender as CheckBox).Checked;
        }
    }
}
