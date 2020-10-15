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
using System.Runtime.CompilerServices;

namespace LoaderCodeSelector
{
    public partial class FrmOptinal : Form
    {
        public FrmOptinal()
        {
            InitializeComponent();
        }
        private byte strModelClearFlag = 0;
        private void FrmOptinal_Load(object sender, EventArgs e)
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
        private void btnOptionClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CollectOptionChbConfig(Panel panel)
        {            
            foreach (Control item in panel.Controls)
            {
                if(item is CheckBox)
                {
                    if(((CheckBox)item).Checked == true)
                    {
                        if (Program.strUIOptionIn.Count == 0)
                        {
                            Program.strUIOptionIn.Add(item.Text);
                        }
                        else
                        {
                            if (item.Text != Program.strUIOptionIn[Program.strUIOptionIn.Count - 1])
                            {
                                Program.strUIOptionIn.Add(item.Text);
                            }
                        }
                    }
                }
            }
            return true;
        }
        private bool CollectOptionRbConfig(Panel panel)
        {            
            foreach (Control item in panel.Controls)
            {
                if (item is RadioButton)
                {
                    if (((RadioButton)item).Checked == true)
                    {
                        if (Program.strUIOptionIn.Count == 0)
                        {
                            Program.strUIOptionIn.Add(item.Text);
                        }
                        else
                        {
                            if (item.Text != Program.strUIOptionIn[Program.strUIOptionIn.Count - 1])
                            {
                                Program.strUIOptionIn.Add(item.Text);
                            }
                        }
                    }
                }
            }
            return true;
        }
        private bool CollectOptionCbConfig(Panel panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is ComboBox)
                {
                    if (((ComboBox)item).Enabled == true)
                    {
                        if (item.Name != "cbOptionModel")
                        {
                            if (item.Text != String.Empty)
                            {
                                if (Program.strUIOptionIn.Count == 0)
                                {
                                    Program.strUIOptionIn.Add(item.Text);
                                }
                                else
                                {
                                    if (item.Text != Program.strUIOptionIn[Program.strUIOptionIn.Count - 1])
                                    {
                                        Program.strUIOptionIn.Add(item.Text);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }       
        private void btnOptionDetemin_Click(object sender, EventArgs e)
        {
            if (Program.optionModelFlag == 0)
            {
                Program.strUIOptionIn.Clear();
                CollectOptionChbConfig(this.pnlOption1);
                CollectOptionRbConfig(this.pnlOption2);
                CollectOptionRbConfig(this.pnlOption3);
                CollectOptionRbConfig(this.pnlOption4);
                CollectOptionRbConfig(this.pnlOption5);
                CollectOptionRbConfig(this.pnlOption6);
                CollectOptionCbConfig(this.pnlOption7);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnStartInModel_Click(object sender, EventArgs e)
        {
            if (strModelClearFlag == 0)
            {
                strModelClearFlag = 1;
                Program.strUIOptionIn.Clear();
                Program.optionModelFlag = 1;
                this.tbOptionItemIn.Enabled = true;
                this.btnOptionAddItem.Enabled = true;

                this.pnlOption1.Enabled = false;
                this.pnlOption2.Enabled = false;
                this.pnlOption3.Enabled = false;
                this.pnlOption4.Enabled = false;
                this.pnlOption5.Enabled = false;
                this.pnlOption6.Enabled = false;
                this.pnlOption7.Enabled = false;
            }
        }       
        private void btnOptionAddItem_Click(object sender, EventArgs e)
        {
            if(this.tbOptionItemIn.Text.Length != 0)
            {                
                if (Program.strUIOptionIn.Count == 0)
                {
                    Program.strUIOptionIn.Add(this.tbOptionItemIn.Text);
                }
                else
                {
                    if (this.tbOptionItemIn.Text != Program.strUIOptionIn[Program.strUIOptionIn.Count - 1])
                    {
                        Program.strUIOptionIn.Add(this.tbOptionItemIn.Text);
                    }
                }               
                this.tbOptionItemIn.Text = String.Empty;
            }
        }

        private void cbOptionModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            Table2Data table2Data = null;
            SelectorManager selectorManager = new SelectorManager();
            table2Data = selectorManager.LoadeTable2Data((string)this.cbOptionModel.Text);

            List<List<string>> listStr = new List<List<string>>(){
                table2Data.strOneCol,  table2Data.strTwoCol, table2Data.strThreeCol, table2Data.strFourCol,
                table2Data.strFiveCol, table2Data.strSixCol, table2Data.strSevenCol, table2Data.strEightCol,
            };
            //加载之前清空项
            foreach (Control item in this.pnlOption7.Controls)
            {
                if (item is ComboBox)
                {
                    if (((ComboBox)item).Name != "cbOptionModel")
                    {
                        ((ComboBox)item).Items.Clear();
                    }
                }
            }
            //加载对应车型配置
            foreach (Control item in this.pnlOption7.Controls)
            {
                if(item is ComboBox)
                {
                    if(((ComboBox)item).Name != "cbOptionModel")
                    {
                        if (listStr[i] == null)
                            continue;
                        foreach(string item2 in listStr[i])
                        {
                            ((ComboBox)item).Items.Add(item2);
                        }
                        i++;
                    }                  
                }         
            }
        }
    }
}
