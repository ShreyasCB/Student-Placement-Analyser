using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;

namespace educationSector.AdminForms
{
    public partial class KNN_IndividualPrediction : System.Web.UI.Page
    {
        static DataTable tabDataset = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

       
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Panel2.Visible = false;

                BLL obj = new BLL();

                tabDataset.Rows.Clear();
                //fetch the training dataset based on course
                tabDataset = obj.GetTrainingDatasetwithRegNo(lblCourse.Text);

                if (tabDataset.Rows.Count > 0)
                {
                    GetDataset();                   
                    KNNAlgorithm();
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
               
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function which contains binning code
        private void binningMethod()
        {
            try
            {
                Panel2.Visible = false;

                BLL obj = new BLL();

                tabDataset.Rows.Clear();
                //fetch the training dataset based on course
                tabDataset = obj.GetTrainingDatasetwithRegNo(lblCourse.Text);

                if (tabDataset.Rows.Count > 0)
                {
                    //code of binning method
                    for (int i = 0; i < tabDataset.Rows.Count; i++)
                    {
                        string s = tabDataset.Rows[i]["PrevSemResults"] + "," + tabDataset.Rows[i]["SSLC"] +
                            "," + tabDataset.Rows[i]["PUC"] + "," + tabDataset.Rows[i]["TS"] +
                            "," + tabDataset.Rows[i]["CC"] + "," + tabDataset.Rows[i]["CS"] +
                            "," + tabDataset.Rows[i]["CA"];

                        string[] parameter = s.Split(',');

                        for (int j = 0; j < parameter.Length; j++)
                        {
                            if (parameter[j].Equals("") || parameter.Equals("?"))
                            {
                                for (int k = 0; k < tabDataset.Rows.Count; k++)
                                {
                                    int id = 0;
                                    Random r = new Random();

                                    for (int x = 1; x <= 2; x++)
                                    {                                        
                                        id = r.Next(9);
                                    }
       
                                    //setting value for ? and null value
                                    string _value = tabDataset.Rows[id][parameter[j]].ToString();
                                }
                            }

                        }
                    }
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
        
        //function which contains KNN algorithm code
        private void KNNAlgorithm()
        {
            BLL obj = new BLL();
            BusinessLogic obj1 = new BusinessLogic();

            ArrayList _Distance = new ArrayList();
            ArrayList _RegNo = new ArrayList();


            string[] attributes = { "PrevSemResults", "SSLC", "PUC", "TS", "CC", "CS", "CA" };


            int [] classify ={DropDownListPrevResults.SelectedIndex, 
                        DropDownListSSLC.SelectedIndex, DropDownListPUC.SelectedIndex, DropDownListTS.SelectedIndex,
                                   DropDownListCC.SelectedIndex, DropDownListCS.SelectedIndex, DropDownListCA.SelectedIndex};

            int m = 5;

            //finding the distance between the objects
            for (int i = 0; i < tabDataset.Rows.Count; i++)
            {
                double _val = 0.0;

                for (int j = 0; j < classify.Length; j++)
                {

                    //start identifying the dropdownlist index

                    if (j == 0)
                    {
                        //Prev Results
                        string _dataTextPrev = DropDownListPrevResults.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemPrevSemResults = new ListItem(_dataTextPrev, tabDataset.Rows[i][j + 3].ToString());
                        int _indexPrevSemResults = DropDownListPrevResults.Items.IndexOf(_itemPrevSemResults);

                        _val += Math.Pow(double.Parse(_indexPrevSemResults.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 1)
                    {
                        //SSLC
                        string _dataTextSSLC = DropDownListSSLC.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemSSLC = new ListItem(_dataTextSSLC, tabDataset.Rows[i][j + 3].ToString());
                        int _indexSSLC = DropDownListSSLC.Items.IndexOf(_itemSSLC);

                        _val += Math.Pow(double.Parse(_indexSSLC.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 2)
                    {
                        //PUC
                        string _dataTextPUC = DropDownListPUC.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemPUC = new ListItem(_dataTextPUC, tabDataset.Rows[i][j + 3].ToString());
                        int _indexPUC = DropDownListPUC.Items.IndexOf(_itemPUC);

                        _val += Math.Pow(double.Parse(_indexPUC.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 3)
                    {
                        //TS
                        string _TSData = DropDownListTS.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemTS = new ListItem(_TSData, tabDataset.Rows[i][j + 3].ToString());
                        int _indexTS = DropDownListTS.Items.IndexOf(_itemTS);

                        _val += Math.Pow(double.Parse(_indexTS.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 4)
                    {
                        //CC
                        string _dataTextCC = DropDownListCC.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemCC = new ListItem(_dataTextCC, tabDataset.Rows[i][j + 3].ToString());
                        int _indexCC = DropDownListCC.Items.IndexOf(_itemCC);

                        _val += Math.Pow(double.Parse(_indexCC.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 5)
                    {
                        //CS
                        string _CSData = DropDownListCS.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemCS = new ListItem(_CSData, tabDataset.Rows[i][j + 3].ToString());
                        int _indexCS = DropDownListCS.Items.IndexOf(_itemCS);

                        _val += Math.Pow(double.Parse(_indexCS.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }

                    if (j == 6)
                    {
                        //CA
                        string _CAData = DropDownListCA.Items.FindByValue(tabDataset.Rows[i][j + 3].ToString()).ToString();

                        ListItem _itemCA = new ListItem(_CAData, tabDataset.Rows[i][j + 3].ToString());
                        int _indexCA = DropDownListCA.Items.IndexOf(_itemCA);

                        _val += Math.Pow(double.Parse(_indexCA.ToString()) - double.Parse(classify[j].ToString()), 2);
                    }                                        

                    //end                                       
                }

                _val = Math.Sqrt(_val);

                _Distance.Add(Math.Round(_val, 1));
                _RegNo.Add(tabDataset.Rows[i]["RegNo"].ToString());
            }

            ArrayList temp = new ArrayList();
            ArrayList arrayRegno = new ArrayList();

            ArrayList arrayExists = new ArrayList();
            int d = 0;

            for (int x = 0; x < _Distance.Count; x++)
            {
                temp.Add(_Distance[x]);
            }

            temp.Sort();

            for (int y = 0; y < m; y++)
            {
                d = 0;

                for (int z = 0; z < _Distance.Count; z++)
                {
                    if (_Distance[z].Equals(temp[y]))
                    {
                        if (d == 0 && !arrayExists.Contains(_RegNo[z]))
                        {
                            arrayRegno.Add(_RegNo[z]);

                            arrayExists.Add(_RegNo[z]);

                            ++d;

                        }
                    }
                }
            }

            if (arrayRegno.Count > 0)
            {
                int cnt;

                ArrayList arrayCnt = new ArrayList();
                ArrayList arrayOutcome = new ArrayList();

                DataTable tabOutcome = new DataTable();
                tabOutcome = obj1.GetDistinctPalcementStatus(lblCourse.Text);

                for (int i = 0; i < tabOutcome.Rows.Count; i++)
                {
                    cnt = 0;

                    for (int j = 0; j < arrayRegno.Count; j++)
                    {
                        DataTable tabStudentResult = new DataTable();
                        tabStudentResult = obj1.Search_Student(arrayRegno[j].ToString());

                        if (tabStudentResult.Rows[0]["PStatus"].ToString().Equals(tabOutcome.Rows[i]["PStatus"].ToString()))
                        {
                            ++cnt;
                        }
                    }

                    arrayCnt.Add(cnt);
                    arrayOutcome.Add(tabOutcome.Rows[i]["PStatus"].ToString());
                }

                ArrayList temp1 = new ArrayList();

                for (int x = 0; x < arrayCnt.Count; x++)
                {
                    temp1.Add(arrayCnt[x]);
                }

                temp1.Sort();
                temp1.Reverse();

                for (int y = 0; y < arrayCnt.Count; y++)
                {
                    if (arrayCnt[y].Equals(temp1[0]))
                    {
                        Panel2.Visible = true;

                        lblOutput.Font.Bold = true;
                        lblOutput.ForeColor = System.Drawing.Color.Green;
                        lblOutput.Text = arrayOutcome[y].ToString();

                        lblName.Text = txtName.Text;
                        lblCName.Text = lblCourse.Text;

                        return;
                    }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BusinessLogic obj = new BusinessLogic();
            DataTable tab = new DataTable();

            tab = obj.Search_Student(TextBox_Reg.Text);

            if (tab.Rows.Count != 0)
            {
                Panel2.Visible = false;
                btnCheck.Enabled = true;

                txtName.Text = tab.Rows[0]["Name"].ToString();
                lblCourse.Text = tab.Rows[0]["CName"].ToString();
                lblSem.Text = tab.Rows[0]["Sem"].ToString();

                GetStudentAttributes();
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                btnCheck.Enabled = false;

                txtName.Text = lblCourse.Text = lblSem.Text = string.Empty;

                DropDownListPrevResults.SelectedIndex = DropDownListPUC.SelectedIndex =
                     DropDownListTS.SelectedIndex = DropDownListSSLC.SelectedIndex = DropDownListCC.SelectedIndex =
                     DropDownListCS.SelectedIndex = DropDownListCA.SelectedIndex = 0;

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Student Doesnt Exists!!!')</script>");
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
           
        
    }
}