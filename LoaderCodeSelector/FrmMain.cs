using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoaderCodeSelectorModels;
using LoaderCodeSelectorBLL;

namespace LoaderCodeSelector
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            foreach(Control item in this.pnlMain.Controls)
            {
                if(item is Button)
                {
                    if(((Button)item).Name != "btnCombSerNum")
                    {
                        ((Button)item).Click += new System.EventHandler(this.btnMain_Click);
                    }
                }
            }          
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region
        private bool JudgeMainCbNotNull(Panel panel)
        {
            byte flag = 0;
            foreach (Control item in panel.Controls)
            {
                if (item is ComboBox)
                {
                    if (item.Text == string.Empty)
                    {
                        flag = 1;
                        break;
                    }                   
                }
            }
            if (flag == 1)
            {
                MessageBox.Show("请输入完整配置！");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CollectMainConfig(Panel panel)
        {      
            Program.strUIIn.Clear();
            foreach (Control item in panel.Controls)
            {
                if (item is ComboBox)
                {
                    if(((ComboBox)item).Name != "tbMainInItem")
                    {
                        if (Program.strUIIn.Count == 0)
                        { 
                            Program.strUIIn.Add(item.Text); 
                        }
                        else
                        { 
                            if (item.Text != Program.strUIIn[Program.strUIIn.Count - 1])
                            {
                                Program.strUIIn.Add(item.Text);
                            }
                        }                      
                    }
                }
            }
            return true;
        }
        #endregion
        private void btnMainOutCode_Click(object sender, EventArgs e)
        {
            LoaderCode reCodeLoaderCode =null;
            LoaderCode reConfigLoaderCode=null;
            LoaderCode newLoaderCode=null;
            this.tbMainOutCode.Text = String.Empty;
            this.tbMainOutReConfig.Text = String.Empty;
            SelectorManager selectorManager = new SelectorManager();

            if (true == JudgeMainCbNotNull(this.pnlMain))
            {              
                CollectMainConfig(this.pnlMain);
                if(Program.strUIOptionIn.Count>0)
                {
                    Program.strUIIn = Program.strUIIn.Concat(Program.strUIOptionIn).ToList<string>();
                }
                newLoaderCode = selectorManager.CreateLoaderCode(Program.strUIIn,out reCodeLoaderCode,out reConfigLoaderCode);
                if (reConfigLoaderCode != null)
                {
                    this.tbMainOutReConfig.Text = reConfigLoaderCode.wholeCode + "\r\n" + reConfigLoaderCode.wholeConfigration;
                    MessageBox.Show("配置输入重复！");
                }
                else
                {
                    this.tbMainOutCode.Text = newLoaderCode.wholeCode + "\r\n" + newLoaderCode.wholeConfigration;
                }
            }

        }
        private void btnMainClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 弹出可选配置页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCombSerNum_Click(object sender, EventArgs e)
        {           
            Program.optionModelFlag = 0;
           
            FrmOptinal frmOption = new FrmOptinal();
            DialogResult result = frmOption.ShowDialog();             
        }
        /// <summary>
        /// 弹出授权界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItemAuthory_Click(object sender, EventArgs e)
        {
            if (this.tbMainInItem.Enabled == true)
            {
                MessageBox.Show("已授权！");
                return;
            }
            FrmAuthority frmAuthority = new FrmAuthority();
            DialogResult result = frmAuthority.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                foreach (Control item in this.pnlMain.Controls)
                {
                    if (item is Button)
                    {
                        ((Button)item).Enabled = true;
                    }
                }
                this.tbMainInItem.Enabled = true;
                MessageBox.Show("授权成功！");
            }
            else
            {
                MessageBox.Show("授权失败！");                
            }
        }
        private void btnMain_Click(object sender, EventArgs e)
        {
            Button tempBtn = (Button)sender;
            string tempBtnName= tempBtn.Name;
            if(this.tbMainInItem.Text == String.Empty)
            {
                MessageBox.Show("输入框不能为空！");
                return;
            }
            else
            {
               DialogResult result = MessageBox.Show("是否确定增加条项？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
               if (result == DialogResult.Cancel)
                   return;
            }
            #region
            switch(tempBtnName)
            {
                case "btnMain1":
                    this.cbMain1.Items.Add(this.tbMainInItem.Text);                   
                    break;
                case "btnMain2":
                    this.cbMain2.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain3":
                    this.cbMain3.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain4":
                    this.cbMain4.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain5":
                    this.cbMain5.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain6":
                    this.cbMain6.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain7":
                    this.cbMain7.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain8":
                    this.cbMain8.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain9":
                    this.cbMain9.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain10":
                    this.cbMain10.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain11":
                    this.cbMain11.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain12":
                    this.cbMain12.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain13":
                    this.cbMain13.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain14":
                    this.cbMain14.Items.Add(this.tbMainInItem.Text);
                    break;
                case "btnMain15":
                    this.cbMain15.Items.Add(this.tbMainInItem.Text);
                    break;
                default:
                    break;
            }
            #endregion
            this.tbMainInItem.Text = String.Empty;
        }
    }
}
