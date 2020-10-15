using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderCodeSelector
{
    public partial class FrmAuthority : Form
    {
        public FrmAuthority()
        {
            InitializeComponent();
        }    
        private void FrmAuthority_Load(object sender, EventArgs e)
        {

        }
        #region
        private bool isInMove;
        private Point oldPoint;
        void EasyMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isInMove) return;
            Point pt = PointToScreen(e.Location);
            if (pt.X == oldPoint.X || pt.Y == oldPoint.Y) return;
            this.Location = new Point(this.Location.X + pt.X - oldPoint.X, this.Location.Y + pt.Y - oldPoint.Y);
            oldPoint = pt;
        }

        void EasyMove_MouseUp(object sender, MouseEventArgs e)
        {
            isInMove = false;
        }

        void EasyMove_MouseDown(object sender, MouseEventArgs e)
        {
            isInMove = true;
            oldPoint = PointToScreen(e.Location);
        }
        #endregion      
        private void btnAuthorClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAuthory_Click(object sender, EventArgs e)
        {
            if (this.tbAuthorAccountIn.Text == "admin" && this.tbAuthorPwd.Text == "123456")
            { 
                this.DialogResult = DialogResult.OK;
            }
            else
            { 
                this.DialogResult = DialogResult.Cancel; 
            }
            this.Close();
        }
    }
}
