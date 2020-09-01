<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="KNN_IndividualPrediction.aspx.cs" Inherits="educationSector.AdminForms.KNN_IndividualPrediction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAboutus" runat="server">
  <div class="article">
      <h2><span>ENTER</span> STUDENT PARAMETERS (KNN)</h2>

   <br />
    <TABLE id="Table2" style="BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; WIDTH: 600px; BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 488px; BACKGROUND-COLOR: white"
							cellSpacing="1" cellPadding="1" width="418" bgColor="#0" border="0">
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: white; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #006699"
									align="center" class="style3">
                                    <asp:Label ID="Label1" runat="server" BackColor="Transparent" Width="168px">&nbsp;&nbsp;&nbsp;&nbsp; 
                                   </asp:Label>
                                </TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 12px; WIDTH: 109px; COLOR: white; FONT-FAMILY: Verdana; HEIGHT: 17px; BACKGROUND-COLOR: #006699"
									align="left"><strong class=" ">
                                        <asp:Label ID="Label3" runat="server" Width="150px">Student Parameters</asp:Label>
                                    </strong></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" class="style3">
									<TABLE id="Table4" style="WIDTH: 175px; HEIGHT: 534px" cellSpacing="0" 
                                        cellPadding="0" border="0">
										<TR>
											<TD style="HEIGHT: 260px" align="center" bgcolor="beige" valign="bottom">
												<p>
                                                    <asp:Image ID="Image2" runat="server" Height="500px" 
                                                        ImageUrl="~/images/education5.png" Width="200px" />
                                                </p>
                                            </TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" align="left">
									<TABLE id="Table3" style="FONT-SIZE: 12px; COLOR: black; FONT-FAMILY: Verdana" cellSpacing="2"
										cellPadding="3" border="0">
										<TR>
											<TD class="style5">Register No</TD>
											<TD class="style4"><asp:textbox id="TextBox_Reg" runat="server" CssClass="txtBox"></asp:textbox></TD>
											<TD>
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                                    ErrorMessage="Regno?" ControlToValidate="TextBox_Reg" ForeColor="#FF3300" 
                                                    ToolTip="Regno?" ValidationGroup="attributes"></asp:RequiredFieldValidator></TD>
										</TR>
									    <tr>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td align="left" class="style4">
                                                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                                                    Text="Search" ValidationGroup="a" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                Name</td>
                                            <td align="left" class="style4">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="txtBox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                    ControlToValidate="txtName" ErrorMessage="Name?" ForeColor="#FF3300" 
                                                    ToolTip="Regno?" ValidationGroup="attributes"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                Course</td>
                                            <td align="left" class="style4">
                                                <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Sem</td>
                                            <td align="left" class="style4">
                                                <asp:Label ID="lblSem" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td align="left" class="style4">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                PrevSemResults</td>
                                            <td align="left" class="style4">
                                                <asp:DropDownList ID="DropDownListPrevResults" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem Value="89%-100%">S</asp:ListItem>
                                                    <asp:ListItem Value="74%-89%">A</asp:ListItem>
                                                    <asp:ListItem Value="59%-74%">B</asp:ListItem>
                                                    <asp:ListItem Value="49%-59%">C</asp:ListItem>
                                                    <asp:ListItem Value="44%-49%">D</asp:ListItem>
                                                    <asp:ListItem Value="40%-44%">E</asp:ListItem>
                                                    <asp:ListItem Value="&lt;40%">F</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator17" runat="server" 
                                                    ControlToValidate="DropDownListPrevResults" ErrorMessage="Previous Results?" 
                                                    ForeColor="#FF3300" Operator="NotEqual" ToolTip="Previous Results?" 
                                                    ValidationGroup="attributes" ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                SSLC</td>
                                            <td align="left" class="style4">
                                                <asp:DropDownList ID="DropDownListSSLC" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                   <asp:ListItem Value="85%-100%">Distinction</asp:ListItem>
                                                    <asp:ListItem Value="60%-85%">FirstClass</asp:ListItem>
                                                    <asp:ListItem Value="45%-60%">SecondClass</asp:ListItem>
                                                    <asp:ListItem Value="35%-45%">ThirdClass</asp:ListItem>
                                                    <asp:ListItem Value="&lt;35%">Fail</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator18" runat="server" 
                                                    ControlToValidate="DropDownListSSLC" ErrorMessage="SSLC?" 
                                                    ForeColor="#FF3300" Operator="NotEqual" ToolTip="SSLC?" 
                                                    ValidationGroup="attributes" ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                PUC</td>
                                            <td align="left" class="style4">
                                                <asp:DropDownList ID="DropDownListPUC" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem Value="85%-100%">Distinction</asp:ListItem>
                                                    <asp:ListItem Value="60%-85%">FirstClass</asp:ListItem>
                                                    <asp:ListItem Value="45%-60%">SecondClass</asp:ListItem>
                                                    <asp:ListItem Value="35%-45%">ThirdClass</asp:ListItem>
                                                    <asp:ListItem Value="&lt;35%">Fail</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator19" runat="server" 
                                                    ControlToValidate="DropDownListPUC" ErrorMessage="PUC?" ForeColor="#FF3300" 
                                                    Operator="NotEqual" ToolTip="PUC?" ValidationGroup="attributes" 
                                                    ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style7">
                                                Technical Skills</td>
                                            <td align="left" class="style8">
                                                <asp:DropDownList ID="DropDownListTS" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>C</asp:ListItem>
                                                    <asp:ListItem>C++</asp:ListItem>
                                                    <asp:ListItem>JAVA</asp:ListItem>
                                                    <asp:ListItem>ASP.NET</asp:ListItem>
                                                    <asp:ListItem>PYTHON</asp:ListItem>
                                                    <asp:ListItem>PHP</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style9">
                                                <asp:CompareValidator ID="CompareValidator26" runat="server" 
                                                    ControlToValidate="DropDownListTS" ErrorMessage="TS?" ForeColor="#FF3300" 
                                                    Operator="NotEqual" ToolTip="Technical Skills?" ValidationGroup="attributes" 
                                                    ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                Certified Course</td>
                                            <td align="left" class="style4">
                                                <asp:DropDownList ID="DropDownListCC" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator27" runat="server" 
                                                    ControlToValidate="DropDownListCC" ErrorMessage="CC?" ForeColor="#FF3300" 
                                                    Operator="NotEqual" ToolTip="Certified Courses" ValidationGroup="attributes" 
                                                    ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                Communication Skillss</td>
                                            <td align="left" class="style4">
                                                <asp:DropDownList ID="DropDownListCS" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Best</asp:ListItem>
                                                    <asp:ListItem>Better</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Poor</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator29" runat="server" 
                                                    ControlToValidate="DropDownListCS" ErrorMessage="CS?" ForeColor="#FF3300" 
                                                    Operator="NotEqual" ToolTip="Communication Skills?" 
                                                    ValidationGroup="attributes" ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Conference Attended</td>
                                            <td align="left" class="style1">
                                                <asp:DropDownList ID="DropDownListCA" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style1">
                                                <asp:CompareValidator ID="CompareValidator28" runat="server" 
                                                    ControlToValidate="DropDownListCA" ErrorMessage="CA?" ForeColor="#FF3300" 
                                                    Operator="NotEqual" ToolTip="Conference Attended?" ValidationGroup="attributes" 
                                                    ValueToCompare="Select"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td align="left" class="style4">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td align="left" class="style4">
                                                <asp:Button ID="btnCheck" runat="server" Enabled="False" Height="50px" 
                                                    onclick="btnCheck_Click" Text="Placement Prediction (KNN)" />
                                                &nbsp;&nbsp;&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
									    <tr>
                                            <td class="style5">
                                                &nbsp;</td>
                                            <td align="left" class="style4">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>

    <br />


    <asp:Panel ID="Panel1" runat="server" Visible="False">
    <h2><span>TRAINING</span> DATASET</h2>
     <table style="width: 98%;" style="BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; WIDTH: 600px; BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 188px; BACKGROUND-COLOR: white"
							cellSpacing="1" cellPadding="1" width="418" bgColor="#0" border="0">
        <tr>
            <td valign="top">
                <asp:Label ID="lblDataset" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Table ID="tableDataset" runat="server">
                </asp:Table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Panel>

    <br />
   
      <asp:Panel ID="Panel2" runat="server" Visible="False">
        <h2>PLACEMENT PREDICTION (KNN)</h2>
          <table style="width: 35%;" style="BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; WIDTH: 400px; BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 188px; BACKGROUND-COLOR: white"
							cellSpacing="1" cellPadding="1" width="418" bgColor="#0" border="0">
              <tr>
                  <td>
                      <b>Student Name</b></td>
                  <td>
                      <asp:Label ID="lblName" runat="server"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <b>Course Name</b></td>
                  <td>
                      <asp:Label ID="lblCName" runat="server"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <b>Placement Prediction</b></td>
                  <td>
                      <asp:Label ID="lblOutput" runat="server"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
          </table>
      </asp:Panel>


   <br />
   </div>
   </asp:Panel>


</asp:Content>
