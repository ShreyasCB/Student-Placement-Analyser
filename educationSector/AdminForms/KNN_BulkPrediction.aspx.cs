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
    public partial class KNN_BulkPrediction : System.Web.UI.Page
    {
        static ArrayList _arrayRegNo = new ArrayList();
        static string _currentStud = null;
        static DataTable tabDataset = new DataTable();
        static ArrayList _arrayName = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)

                    LoadCourses();
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
               
        //current students (testing dataset)
        protected void ButtonView_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                DataTable tabTrainingSet = new DataTable();

                tabTrainingSet = obj.GetTestingDataset(DropDownList_Course.SelectedItem.Text);

                if (tabTrainingSet.Rows.Count > 0)
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.Font.Size = 14;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Testing Dataset Found!!!";

                    panelImport.Visible = true;

                    // binding form data with dynamic table
                    string featuress = "PrevSemResults,SSLC,PUC,TS,CC,CS,CA";

                    string[] s = featuress.Split(',');
                    int featureCnt = s.Length;

                    tableTraining.Rows.Clear();

                    tableTraining.BorderStyle = BorderStyle.Double;
                    tableTraining.GridLines = GridLines.Both;
                    tableTraining.BorderColor = System.Drawing.Color.SteelBlue;

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

                    TableCell cellC = new TableCell();
                    cellC.Text = "<b>Name</b>";
                    mainrow.Controls.Add(cellC);

                    for (int j = 0; j < s.Length; j++)
                    {
                        TableCell cell1 = new TableCell();
                        cell1.Text = "<b>" + s[j] + "</b>";
                        mainrow.Controls.Add(cell1);
                    }

                    TableCell cellR = new TableCell();
                    cellR.BackColor = System.Drawing.Color.Green;
                    cellR.Text = "<b>Res</b>";
                    mainrow.Controls.Add(cellR);

                    tableTraining.Controls.Add(mainrow);

                    for (int cnt = 0; cnt < tabTrainingSet.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();

                        //TableCell cellCName = new TableCell();
                        //cellCName.Text = DropDownList_Course.SelectedItem.Text;
                        //row.Controls.Add(cellCName);

                        //TableCell cellSemester = new TableCell();
                        //cellSemester.Text = DropDownList_Sem.SelectedItem.Text;
                        //row.Controls.Add(cellSemester);

                        TableCell cellStudentRegNo = new TableCell();
                        cellStudentRegNo.Text = tabTrainingSet.Rows[cnt]["RegNo"].ToString();
                        row.Controls.Add(cellStudentRegNo);

                        TableCell cellName = new TableCell();
                        cellName.Text = tabTrainingSet.Rows[cnt]["Name"].ToString();
                        row.Controls.Add(cellName);


                        //getting the student constraints (text information)

                        TableCell cellPRev = new TableCell();
                        cellPRev.Width = 150;

                        //Prev Results
                        //string dataTextPrev = DropDownListPrevResults.Items.FindByValue(tabOldStudents.Rows[cnt]["PrevSemResults"].ToString()).ToString();
                        cellPRev.Text = tabTrainingSet.Rows[cnt]["PrevSemResults"].ToString();
                        row.Controls.Add(cellPRev);

                        TableCell cellSSLC = new TableCell();
                        cellSSLC.Width = 150;

                        //SSLC
                        //string dataTextSSLC = DropDownListSSLC.Items.FindByValue(tabOldStudents.Rows[cnt]["SSLC"].ToString()).ToString();
                        cellSSLC.Text = tabTrainingSet.Rows[cnt]["SSLC"].ToString();
                        row.Controls.Add(cellSSLC);

                        TableCell cellPUC = new TableCell();
                        cellPUC.Width = 150;

                        //PUC
                        //string dataTextPUC = DropDownListPUC.Items.FindByValue(tabOldStudents.Rows[cnt]["PUC"].ToString()).ToString();
                        cellPUC.Text = tabTrainingSet.Rows[cnt]["PUC"].ToString();
                        row.Controls.Add(cellPUC);

                        TableCell cellTS = new TableCell();
                        cellTS.Width = 150;

                        //TS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellTS.Text = tabTrainingSet.Rows[cnt]["TS"].ToString();
                        row.Controls.Add(cellTS);

                        TableCell cellCC = new TableCell();
                        cellCC.Width = 150;

                        //TS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCC.Text = tabTrainingSet.Rows[cnt]["CC"].ToString();
                        row.Controls.Add(cellCC);

                        TableCell cellCS = new TableCell();
                        cellCS.Width = 150;

                        //TS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCS.Text = tabTrainingSet.Rows[cnt]["CS"].ToString();
                        row.Controls.Add(cellCS);

                        TableCell cellCA = new TableCell();
                        cellCA.Width = 150;

                        //TS
                        //string dataIHS = DropDownListIHS.Items.FindByValue(tabOldStudents.Rows[cnt]["IHS"].ToString()).ToString();
                        cellCA.Text = tabTrainingSet.Rows[cnt]["CA"].ToString();
                        row.Controls.Add(cellCA);

                        TableCell cellResult = new TableCell();

                        cellResult.Text = "?";
                        row.Controls.Add(cellResult);


                        tableTraining.Controls.Add(row);

                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Testing Dataset Not Found!!!";

                    panelImport.Visible = false;
                }
            }
            catch
            {

            }
        }

        //training dataset
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                Panel1.Visible = true;

                ButtonView_Click(sender, e);

                GetDataset();
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                //lblError.Text = ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Input not in a Correct Format!!!')</script>");
            }

        }

        private void GetDataset()
        {
            BLL obj = new BLL();
            DataTable tabOldStudents = new DataTable();

            tabOldStudents = obj.GetTrainingDatasetwithRegNo(DropDownList_Course.SelectedItem.Text);

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
                    cellTS.Text = tabOldStudents.Rows[cnt]["CA"].ToString();
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

        string _timeKNN = null;

        //predict placement status        
        protected void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonView_Click(sender, e);
                Panel1.Visible = false;

                //btnView_Click(sender, e);

                BLL obj = new BLL();
                BusinessLogic db = new BusinessLogic();

                DataTable tabTesting = new DataTable();
                tabTesting = obj.GetTestingDataset(DropDownList_Course.SelectedItem.Text);

                if (tabTesting.Rows.Count > 0)
                {
                    _arrayRegNo.Clear();
                    _arrayResult.Clear();
                    _arrayName.Clear();

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int _cnt = 0; _cnt < tabTesting.Rows.Count; _cnt++)
                    {
                        _currentStud = null;

                        tabDataset.Rows.Clear();
                        tabDataset = obj.GetTrainingDatasetwithRegNo(DropDownList_Course.SelectedItem.Text);

                        _currentStud = tabTesting.Rows[_cnt]["Regno"].ToString();

                        if (tabDataset.Rows.Count > 0)
                        {
                            Panel5.Visible = true;

                            _arrayRegNo.Add(tabTesting.Rows[_cnt]["Regno"].ToString());
                            _arrayName.Add(tabTesting.Rows[_cnt]["Name"].ToString());

                            KNN();

                        }
                        else
                        {
                            Panel5.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Training Dataset Not Found!!!')</script>");
                        }
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeKNN = elapsedMs.ToString();

                    Session["KNN_Time"] = null;
                    Session["KNN_Time"] = _timeKNN;

                    Results();
                    ResultAnaly();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Testing Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }

        private void Results()
        {
            if (_arrayRegNo.Count > 0 && _arrayResult.Count > 0)
            {
                tablePrediction.Rows.Clear();

                tablePrediction.BorderStyle = BorderStyle.Double;
                tablePrediction.GridLines = GridLines.Both;
                tablePrediction.BorderColor = System.Drawing.Color.SteelBlue;

                TableRow mainrow = new TableRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cellC = new TableCell();
                cellC.Text = "<b>RegNo</b>";
                mainrow.Controls.Add(cellC);

                TableCell cellCname = new TableCell();
                cellCname.Text = "<b>Name</b>";
                mainrow.Controls.Add(cellCname);

                TableCell cellB = new TableCell();
                cellB.Text = "<b>Placements</b>";
                mainrow.Controls.Add(cellB);

                tablePrediction.Controls.Add(mainrow);

                for (int cnt = 0; cnt < _arrayResult.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellRegno = new TableCell();
                    cellRegno.Width = 250;
                    cellRegno.Text = _arrayRegNo[cnt].ToString();
                    row.Controls.Add(cellRegno);

                    TableCell cellName = new TableCell();
                    cellName.Width = 250;
                    cellName.Text = _arrayName[cnt].ToString();
                    row.Controls.Add(cellName);

                    TableCell cellStatus = new TableCell();
                    cellStatus.Width = 250;
                    cellStatus.Text = _arrayResult[cnt].ToString();
                    row.Controls.Add(cellStatus);

                    tablePrediction.Controls.Add(row);
                }
            }
        }

        double _outcomeCntNB = 0;

        private void ResultAnaly()
        {
            BLL obj = new BLL();
            DataTable tabActual = new DataTable();
            tabActual = obj.GetActualData(DropDownList_Course.SelectedItem.Text);

            if (tabActual.Rows.Count > 0)
            {
                for (int i = 0; i < tabActual.Rows.Count; i++)
                {
                    if (tabActual.Rows[i]["PStatus"].ToString().Equals(_arrayResult[i].ToString()))
                    {
                        ++_outcomeCntNB;
                    }
                }
                Session["KNN_Result"] = null;
                Session["KNN_Result"] = _outcomeCntNB;


                tableResults.Rows.Clear();

                tableResults.BorderStyle = BorderStyle.Double;
                tableResults.GridLines = GridLines.Both;
                tableResults.BorderColor = System.Drawing.Color.SteelBlue;

                TableRow mainrow = new TableRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cellC = new TableCell();
                cellC.Text = "<b>KNN</b>";
                mainrow.Controls.Add(cellC);

                TableCell cellB = new TableCell();
                cellB.Text = "<b>Constraint</b>";
                mainrow.Controls.Add(cellB);

                tableResults.Controls.Add(mainrow);

                //1st row
                TableRow row1 = new TableRow();

                TableCell cellAcc = new TableCell();
                cellAcc.Text = "<b>Accuracy</b>";
                row1.Controls.Add(cellAcc);

                TableCell cellAccNB = new TableCell();
                //cal
                double _percentageNB = (_outcomeCntNB / tabActual.Rows.Count) * 100;
                cellAccNB.Text = _percentageNB.ToString() + "%";
                row1.Controls.Add(cellAccNB);

                tableResults.Controls.Add(row1);

                //2nd row           
                TableRow row2 = new TableRow();

                TableCell cellTime = new TableCell();
                cellTime.Text = "<b>Time (milli secs)</b>";
                row2.Controls.Add(cellTime);

                TableCell cellTimeNB = new TableCell();
                cellTimeNB.Text = _timeKNN;
                row2.Controls.Add(cellTimeNB);

                tableResults.Controls.Add(row2);

                //3rd row           
                TableRow row3 = new TableRow();

                TableCell cellCorrect = new TableCell();
                cellCorrect.Text = "<b>Correctly Classified</b>";
                row3.Controls.Add(cellCorrect);

                TableCell cellCorrectNB = new TableCell();
                cellCorrectNB.Text = _percentageNB.ToString() + "%";
                row3.Controls.Add(cellCorrectNB);

                tableResults.Controls.Add(row3);

                //4th row           
                TableRow row4 = new TableRow();

                TableCell cellInCorrect = new TableCell();
                cellInCorrect.Text = "<b>InCorrectly Classified</b>";
                row4.Controls.Add(cellInCorrect);

                TableCell cellInCorrectNB = new TableCell();
                cellInCorrectNB.Text = (100 - _percentageNB).ToString() + "%";
                row4.Controls.Add(cellInCorrectNB);

                tableResults.Controls.Add(row4);
            }
        }

        #region -- KNN ----

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

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

        static ArrayList _arrayResult = new ArrayList();

        private void KNN()
        {
            BLL obj = new BLL();
            BusinessLogic obj1 = new BusinessLogic();

            ArrayList _Distance = new ArrayList();
            ArrayList _RegNo = new ArrayList();


            string[] attributes = { "PrevSemResults", "SSLC", "PUC", "TS", "CC", "CS", "CA" };

            DataTable tabStud = new DataTable();
            tabStud = obj1.GetStudentAttributes(_currentStud);

            //start identifying the dropdownlist index                       
           
            //Prev Results
            string dataTextPrev = DropDownListPrevResults.Items.FindByValue(tabStud.Rows[0]["PrevSemResults"].ToString()).ToString();

            ListItem itemPrevSemResults = new ListItem(dataTextPrev, tabStud.Rows[0]["PrevSemResults"].ToString());
            int indexPrevSemResults = DropDownListPrevResults.Items.IndexOf(itemPrevSemResults);

            //SSLC
            string dataTextSSLC = DropDownListSSLC.Items.FindByValue(tabStud.Rows[0]["SSLC"].ToString()).ToString();

            ListItem itemSSLC = new ListItem(dataTextSSLC, tabStud.Rows[0]["SSLC"].ToString());
            int indexSSLC = DropDownListSSLC.Items.IndexOf(itemSSLC);
                       
            //PUC
            string dataTextPUC = DropDownListPUC.Items.FindByValue(tabStud.Rows[0]["PUC"].ToString()).ToString();

            ListItem itemPUC = new ListItem(dataTextPUC, tabStud.Rows[0]["PUC"].ToString());
            int indexPUC = DropDownListPUC.Items.IndexOf(itemPUC);
              
            //TS
            string dataTS = DropDownListTS.Items.FindByValue(tabStud.Rows[0]["TS"].ToString()).ToString();

            ListItem itemTS = new ListItem(dataTS, tabStud.Rows[0]["TS"].ToString());
            int indexTS = DropDownListTS.Items.IndexOf(itemTS);

            //CC
            string dataCC = DropDownListCC.Items.FindByValue(tabStud.Rows[0]["CC"].ToString()).ToString();

            ListItem itemCC = new ListItem(dataCC, tabStud.Rows[0]["CC"].ToString());
            int indexCC = DropDownListCC.Items.IndexOf(itemCC);


            //CS
            string dataCS = DropDownListCS.Items.FindByValue(tabStud.Rows[0]["CS"].ToString()).ToString();

            ListItem itemCS = new ListItem(dataCS, tabStud.Rows[0]["CS"].ToString());
            int indexCS = DropDownListCS.Items.IndexOf(itemCS);


            //CA
            string dataCA = DropDownListCA.Items.FindByValue(tabStud.Rows[0]["CA"].ToString()).ToString();

            ListItem itemCA = new ListItem(dataCA, tabStud.Rows[0]["CA"].ToString());
            int indexCA = DropDownListCA.Items.IndexOf(itemCA);
                 
                 
            //end

            int[] classify = { indexPrevSemResults, indexSSLC,  indexPUC, indexTS };
                                    
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
                tabOutcome = obj1.GetDistinctPalcementStatus(DropDownList_Course.SelectedItem.Text);

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

                        _arrayResult.Add(arrayOutcome[y].ToString());

                        return;
                    }
                }
            }
        }

     
        #endregion

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("_CompareAlgorithms.aspx?courseName={0}", DropDownList_Course.SelectedItem.Text));
        }


    }
}