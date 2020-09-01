<%@ Page Title="" Language="C#" MasterPageFile="~/GuestForms/MainMasterpage.Master" AutoEventWireup="true" CodeBehind="frmGallery.aspx.cs" Inherits="educationSector.frmGallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelGallery" runat="server">
    <div class="article">
      <h2><span>COLLEGE</span> GALLERY</h2>

     <br />


        <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;<asp:Image ID="Image1" runat="server" Height="150px" 
                        ImageUrl="~/images/Ait.jpeg" Width="200px" />

                </td>
                <td>
                    &nbsp;
                    <asp:Image ID="Image2" runat="server" Height="150px" 
                        ImageUrl="~/images/Ait_Administration.jpg" Width="200px" />
                </td>
                <td>
                    &nbsp;
                    <asp:Image ID="Image3" runat="server" Height="150px" 
                        ImageUrl="~/images/Ait_hrd.jpg" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Image ID="Image4" runat="server" Height="150px" 
                        ImageUrl="~/images/Ait_stu.jpg" Width="200px" />
                </td>
                <td>
                    &nbsp;
                    <asp:Image ID="Image5" runat="server" Height="150px" 
                        ImageUrl="~/images/educational1.jpg" Width="200px" />
                </td>
                <td>
                    &nbsp;
                    <asp:Image ID="Image6" runat="server" Height="150px" 
                        ImageUrl="~/images/education5.png" Width="200px" />
                </td>
            </tr>
        </table>

     <br />
     

 </div>

   </asp:Panel>
</asp:Content>
