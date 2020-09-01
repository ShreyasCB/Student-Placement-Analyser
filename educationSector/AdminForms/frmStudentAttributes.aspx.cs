using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace educationSector.AdminForms
{
    public partial class frmStudentAttributes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                {
                    if (!this.IsPostBack)
                    {
                        TextBox_Reg.Text = Request.QueryString["regno"].ToString();
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


        //function to get the student attributes
        private void GetStudentAttributes()
        {
            try
            {
                BusinessLogic obj = new BusinessLogic();
                DataTable tab = new DataTable();

                tab = obj.GetStudentAttributes(Request.QueryString["regno"].ToString());

                if (tab.Rows.Count > 0)
                {
                    btnAttributes.Text = "Update";
                    
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
                    btnAttributes.Text = "Upload Parameters";
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


                tab = obj.Search_Student(Request.QueryString["regno"].ToString());

            }
            catch
            {

            }

        }

        protected void btnAttributes_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                BusinessLogic obj = new BusinessLogic();

                if (btnAttributes.Text == "Upload Parameters")
                {
                    result = obj.InsertAttributes(TextBox_Reg.Text,DropDownListPrevResults.SelectedValue,
                     DropDownListSSLC.SelectedValue, DropDownListPUC.SelectedValue, DropDownListTS.SelectedValue,
                     DropDownListCC.SelectedValue,DropDownListCS.SelectedValue,DropDownListCA.SelectedValue);

                    btnAttributes.Text = "Update";

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Student Parameters Added Successfully!!!')</script>");
                }

                else if (btnAttributes.Text == "Update")
                {
                    result = obj.UpdateAttributes(DropDownListPrevResults.SelectedValue,
                     DropDownListSSLC.SelectedValue, DropDownListPUC.SelectedValue, DropDownListTS.SelectedValue,
                     DropDownListCC.SelectedValue, DropDownListCS.SelectedValue, DropDownListCA.SelectedValue, TextBox_Reg.Text);

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Student Parameters Updated Successfully!!!')</script>");
                    btnAttributes.Text = "Update";
                }

            }
            catch
            {

            }

        }       
       
    }
}