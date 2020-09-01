using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace educationSector.AdminForms
{
    public partial class frmDataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)

                    LoadCourses();

                Dataset();
            }
            catch
            {

            }
        }

        //function to load courses
        private void LoadCourses()
        {
            BusinessLogic obj = new BusinessLogic();
            DataTable tab = new DataTable();

            tab = obj.View_Courses();

            if (tab.Rows.Count > 0)
            {
                DropDownList_Course.Items.Clear();
                DropDownList_Course.DataSource = tab;
                DropDownList_Course.DataTextField = "Cname";
                DropDownList_Course.DataValueField = "Cname";

                DropDownList_Course.DataBind();

                DropDownList_Course.Items.Insert(0, "- Select -");
            }

        }             
        
       /* protected void btnDataset_Click(object sender, EventArgs e)
        {
            Dataset();
        } */

        private void Dataset()
        {
            try
            {

                BLL obj = new BLL();
                DataTable tabOldStudents = new DataTable();

                if (DropDownList_Course.SelectedIndex > 0)
                {
                    tabOldStudents = obj.GetTrainingDatasetwithRegNo(DropDownList_Course.SelectedItem.Text);
                }
                else
                {
                    tabOldStudents = obj.GetAllTrainingDataset();
                }

                if (tabOldStudents.Rows.Count > 2)
                {
                    lblDataset.Font.Bold = true;
                    lblDataset.Font.Size = 14;
                    lblDataset.ForeColor = System.Drawing.Color.Green;
                    lblDataset.Text = "Training Data Set Found!!!";

                    // binding form data with dynamic table
                    string featuress = "PrevSemResults,SSLC,PUC,TS,CC,CS,CA";

                    string[] s = featuress.Split(',');
                    int featureCnt = s.Length;

                    tableDataset.Rows.Clear();

                    tableDataset.BorderStyle = BorderStyle.Double;
                    tableDataset.GridLines = GridLines.Both;
                    tableDataset.BorderColor = System.Drawing.Color.SteelBlue;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    //TableCell cellC = new TableCell();
                    //cellC.Text = "<b>CourseName</b>";
                    //mainrow.Controls.Add(cellC);

                    //TableCell cellSem = new TableCell();
                    //cellSem.Text = "<b>Sem</b>";
                    //mainrow.Controls.Add(cellSem);

                    TableCell cellRegNo = new TableCell();
                    cellRegNo.BackColor = System.Drawing.Color.Red;
                    cellRegNo.Text = "<b>RegNo</b>";
                    mainrow.Controls.Add(cellRegNo);

                    for (int j = 0; j < s.Length; j++)
                    {
                        TableCell cell1 = new TableCell();
                        cell1.Text = "<b>" + s[j] + "</b>";
                        mainrow.Controls.Add(cell1);
                    }

                    tableDataset.Controls.Add(mainrow);

                    for (int cnt = 0; cnt < tabOldStudents.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();

                        //TableCell cellCName = new TableCell();
                        //cellCName.Text = DropDownList_Course.SelectedItem.Text;
                        //row.Controls.Add(cellCName);

                        //TableCell cellSemester = new TableCell();
                        //cellSemester.Text = DropDownList_Sem.SelectedItem.Text;
                        //row.Controls.Add(cellSemester);

                        TableCell cellStudentRegNo = new TableCell();
                        cellStudentRegNo.Text = tabOldStudents.Rows[cnt]["RegNo"].ToString();
                        row.Controls.Add(cellStudentRegNo);

                        TableCell cellHrs = new TableCell();
                        cellHrs.Width = 150;

                        //getting the student constraints (text information)
                       
                        TableCell cellPRev = new TableCell();
                        cellPRev.Width = 150;

                        //Prev Results
                        //string dataTextPrev = DropDownListPrevResults.Items.FindByValue(tabOldStudents.Rows[cnt]["PrevSemResults"].ToString()).ToString();
                        cellPRev.Text = tabOldStudents.Rows[cnt]["PrevSemResults"].ToString();
                        row.Controls.Add(cellPRev);

                        TableCell cellSSLC = new TableCell();
                        cellSSLC.Width = 150;

                        //SSLC
                        //string dataTextSSLC = DropDownListSSLC.Items.FindByValue(tabOldStudents.Rows[cnt]["SSLC"].ToString()).ToString();
                        cellSSLC.Text = tabOldStudents.Rows[cnt]["SSLC"].ToString();
                        row.Controls.Add(cellSSLC);

                        TableCell cellPUC = new TableCell();
                        cellPUC.Width = 150;

                        //PUC
                        //string dataTextPUC = DropDownListPUC.Items.FindByValue(tabOldStudents.Rows[cnt]["PUC"].ToString()).ToString();
                        cellPUC.Text = tabOldStudents.Rows[cnt]["PUC"].ToString();
                        row.Controls.Add(cellPUC);

                        TableCell cellTS = new TableCell();
                        cellTS.Width = 150;

                        //IHS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellTS.Text = tabOldStudents.Rows[cnt]["TS"].ToString();
                        row.Controls.Add(cellTS);

                        TableCell cellCC = new TableCell();
                        cellCC.Width = 150;

                        //IHS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCC.Text = tabOldStudents.Rows[cnt]["CC"].ToString();
                        row.Controls.Add(cellCC);

                        TableCell cellCS = new TableCell();
                        cellCS.Width = 150;

                        //IHS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCS.Text = tabOldStudents.Rows[cnt]["CS"].ToString();
                        row.Controls.Add(cellTS);


                        TableCell cellCA = new TableCell();
                        cellCA.Width = 150;

                        //IHS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCA.Text = tabOldStudents.Rows[cnt]["CA"].ToString();
                        row.Controls.Add(cellCA);


                        tableDataset.Controls.Add(row);
                    }
                }
                else
                {
                    lblDataset.Font.Bold = true;
                    lblDataset.Font.Size = 24;
                    lblDataset.ForeColor = System.Drawing.Color.Red;
                    lblDataset.Text = "Training Dataset Not Found!!!";
                }

            }
            catch
            {

            }
        }                       
      
    }
}