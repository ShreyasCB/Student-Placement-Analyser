using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace educationSector
{
    public partial class frmStudentHome : System.Web.UI.Page
    {
        static DataTable tabDataset = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                {
                    if (!IsPostBack)
                    {
                        Panel2.Visible = false;

                        TextBox_Reg.Text = Session["RegNo"].ToString();
                        GetStudentDetails();
                        GetStudentAttributes();
                    }
                }
                else
                {
                    Response.Redirect("~/GuestForms/Index.aspx");
                }
            }
            catch
            {

            }
        }

        //function to get student details
        private void GetStudentDetails()
        {
            try
            {
                BusinessLogic obj = new BusinessLogic();
                DataTable tab = new DataTable();
                
                tab = obj.Search_Student(Session["RegNo"].ToString());
                
                lblCourse.Text = tab.Rows[0]["Cname"].ToString();
                lblSem.Text = tab.Rows[0]["Sem"].ToString();
            }
            catch
            {

            }
        }

        //function to get the student attributes
        private void GetStudentAttributes()
        {
            try
            {
                BusinessLogic obj = new BusinessLogic();
                DataTable tab = new DataTable();

                tab = obj.GetStudentAttributes(TextBox_Reg.Text);

                if (tab.Rows.Count > 0)
                {
                    //Prev Results
                    string dataTextPrev = DropDownListPrevResults.Items.FindByValue(tab.Rows[0]["PrevSemResults"].ToString()).ToString();

                    ListItem itemPrevSemResults = new ListItem(dataTextPrev, tab.Rows[0]["PrevSemResults"].ToString());
                    int indexPrevSemResults = DropDownListPrevResults.Items.IndexOf(itemPrevSemResults);

                    if (indexPrevSemResults != -1)
                    {
                        DropDownListPrevResults.SelectedIndex = indexPrevSemResults;
                    }

                    //SSLC
                    string dataTextSSLC = DropDownListSSLC.Items.FindByValue(tab.Rows[0]["SSLC"].ToString()).ToString();

                    ListItem itemSSLC = new ListItem(dataTextSSLC, tab.Rows[0]["SSLC"].ToString());
                    int indexSSLC = DropDownListSSLC.Items.IndexOf(itemSSLC);

                    if (indexSSLC != -1)
                    {
                        DropDownListSSLC.SelectedIndex = indexSSLC;
                    }

                    //PUC
                    string dataTextPUC = DropDownListPUC.Items.FindByValue(tab.Rows[0]["PUC"].ToString()).ToString();

                    ListItem itemPUC = new ListItem(dataTextPUC, tab.Rows[0]["PUC"].ToString());
                    int indexPUC = DropDownListPUC.Items.IndexOf(itemPUC);

                    if (indexPUC != -1)
                    {
                        DropDownListPUC.SelectedIndex = indexPUC;
                    }


                    //TS
                    string dataTS = DropDownListTS.Items.FindByValue(tab.Rows[0]["TS"].ToString()).ToString();

                    ListItem itemTS = new ListItem(dataTS, tab.Rows[0]["TS"].ToString());
                    int indexTS = DropDownListTS.Items.IndexOf(itemTS);

                    if (indexTS != -1)
                    {
                        DropDownListTS.SelectedIndex = indexTS;
                    }

                    //CC
                    string dataCC = DropDownListCC.Items.FindByValue(tab.Rows[0]["CC"].ToString()).ToString();

                    ListItem itemCC = new ListItem(dataCC, tab.Rows[0]["CC"].ToString());
                    int indexCC = DropDownListCC.Items.IndexOf(itemCC);

                    if (indexCC != -1)
                    {
                        DropDownListCC.SelectedIndex = indexCC;
                    }

                    //CS
                    string dataCS = DropDownListCS.Items.FindByValue(tab.Rows[0]["CS"].ToString()).ToString();

                    ListItem itemCS = new ListItem(dataCS, tab.Rows[0]["CS"].ToString());
                    int indexCS = DropDownListCS.Items.IndexOf(itemCS);

                    if (indexCS != -1)
                    {
                        DropDownListCS.SelectedIndex = indexCS;
                    }

                    //CA
                    string dataCA = DropDownListCA.Items.FindByValue(tab.Rows[0]["CA"].ToString()).ToString();

                    ListItem itemCA = new ListItem(dataCA, tab.Rows[0]["CA"].ToString());
                    int indexCA = DropDownListCA.Items.IndexOf(itemCA);

                    if (indexCA != -1)
                    {
                        DropDownListCA.SelectedIndex = indexCA;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Student Parameters Not Updated!!!')</script>");
                }
            }
            catch
            {

            }
        }
        


        protected void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Panel2.Visible = false;

                BLL obj = new BLL();

                tabDataset.Rows.Clear();
                tabDataset = obj.GetTrainingDatasetwithRegNo(lblCourse.Text);

                if (tabDataset.Rows.Count > 0)
                {
                    GetDataset();

                    NaiveBayesAlgorithm();
                }
                else
                {
                    lblDataset.ForeColor = System.Drawing.Color.Red;
                    lblDataset.Text = "Training Dataset Not Found!!!";
                }
            }
            catch
            {

            }

        }

        private void GetDataset()
        {
            BLL obj = new BLL();
            DataTable tabOldStudents = new DataTable();

            tabOldStudents = obj.GetTrainingDatasetwithRegNo(lblCourse.Text);

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

                    //TS
                    //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                    cellTS.Text = tabOldStudents.Rows[cnt]["TS"].ToString();
                    row.Controls.Add(cellTS);

                    TableCell cellCC = new TableCell();
                    cellCC.Width = 150;

                    //TS
                    //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                    cellCC.Text = tabOldStudents.Rows[cnt]["CC"].ToString();
                    row.Controls.Add(cellCC);

                    TableCell cellCS = new TableCell();
                    cellCS.Width = 150;

                    //TS
                    //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                    cellCS.Text = tabOldStudents.Rows[cnt]["CS"].ToString();
                    row.Controls.Add(cellCS);

                    TableCell cellCA = new TableCell();
                    cellCA.Width = 150;

                    //TS
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

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function which contains the navie bayesian steps
        private void NaiveBayesAlgorithm()
        {
            try
            {               
                ArrayList s = new ArrayList();
                s = GetSubject(lblCourse.Text);

                int m = 7;
                double p = 0.25;


                string[] attributes = { "PrevSemResults", "SSLC", "PUC", "TS", "CC", "CS", "CA" };

                string[] classify ={DropDownListPrevResults.SelectedValue, 
                        DropDownListSSLC.SelectedValue, DropDownListPUC.SelectedValue, DropDownListTS.SelectedValue,
                                   DropDownListCC.SelectedValue, DropDownListCS.SelectedValue, DropDownListCA.SelectedValue};

                for (int i = 0; i < s.Count; i++)
                {
                    mul.Clear();

                    for (int j = 0; j < attributes.Length; j++)
                    {
                        n = 0;
                        nc = 0;

                        for (int d = 0; d < tabDataset.Rows.Count; d++)
                        {
                            if (tabDataset.Rows[d][j + 3].ToString().Equals(classify[j]))
                            {
                                ++n;

                                if (tabDataset.Rows[d][m + 3].ToString().Equals(s[i]))

                                    ++nc;
                            }
                        }

                        double x = m * p;
                        double y = n + m;
                        double z = nc + x;

                        pi = z / y;
                        mul.Add(Math.Abs(pi));
                    }

                    double mulres = 1.0;

                    for (int z = 0; z < mul.Count; z++)
                    {
                        mulres *= double.Parse(mul[z].ToString());

                    }

                    result = mulres * p;
                    output.Add(Math.Abs(result));

                }

                DisplayOutput(s);
            }
            catch
            {

            }

        }

        //function to display the output
        private void DisplayOutput(ArrayList s)
        {
            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    Panel2.Visible = true;

                    lblOutput.Font.Bold = true;
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = s[y].ToString();

                    DataTable tabStud = new DataTable();
                    BusinessLogic obj = new BusinessLogic();
                    
                    tabStud = obj.Search_Student(Session["RegNo"].ToString());
                   
                  
                    lblName.Text = tabStud.Rows[0]["Name"].ToString();
                    lblCName.Text = tabStud.Rows[0]["Cname"].ToString();

                    return;
                }
            }


        }

        //function to get the subjects(course names/subject names)
        public ArrayList GetSubject(string courseName)
        {
            ArrayList sub = new ArrayList();
            DataTable tab = new DataTable();
            BusinessLogic obj = new BusinessLogic();

            tab = obj.GetDistinctPalcementStatus(courseName);

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    string subeject = tab.Rows[i]["PStatus"].ToString();

                    if (subeject.Equals(""))
                    {

                    }
                    else
                    {
                        sub.Add(tab.Rows[i]["PStatus"].ToString());
                    }
                }
            }

            return sub;
        }

    }
}