<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MailingList_REAL._Default" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    Username: <asp:TextBox id="TextBoxName" runat="server" />
            
        <asp:GridView ID="productGridView" Runat="server" 
          DataSourceID="productsDataSource"
            DataKeyNames="userId" AutoGenerateColumns="False" 
             BorderWidth="1px" BackColor="#DEBA84" 
             CellPadding="3" CellSpacing="2" BorderStyle="None" 
             BorderColor="#DEBA84" HorizontalAlign="Right">

            <FooterStyle ForeColor="#8C4510" 
              BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#8C4510" 
              HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" 
              BackColor="#A55129"></HeaderStyle>
             
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ID" 
                  InsertVisible="False" DataField="userId"
                    SortExpression="userId">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Name" 
                 DataField="Name" 
                 SortExpression="Name"></asp:BoundField>
                <asp:BoundField HeaderText="Email" 
                 DataField="Email" 
                 SortExpression="Email"></asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
             BackColor="#738A9C"></SelectedRowStyle>
            <RowStyle ForeColor="#8C4510" 
               BackColor="#FFF7E7"></RowStyle>
        </asp:GridView>

    <br />
    Email: <asp:TextBox id="TextBoxEmail" runat="server" />
    <br />

    <asp:Button id="b1" Text="Add User" onClick="Button1_Click" runat="server" />
    
    <h3>Mailing reciptients:</h3>    

    <asp:SqlDataSource ID="productsDataSource" 
             Runat="server" 
             SelectCommand="SELECT * FROM [Table]"
         ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
         DataSourceMode="DataReader">
        </asp:SqlDataSource>

    <asp:GridView ID="GridView2" Runat="server" 
          DataSourceID="productsDataSource"
            DataKeyNames="userId" AutoGenerateColumns="False" 
             BorderWidth="1px" BackColor="#DEBA84" 
             CellPadding="3" CellSpacing="2" BorderStyle="None" 
             BorderColor="#DEBA84">

            <FooterStyle ForeColor="#8C4510" 
              BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#8C4510" 
              HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" 
              BackColor="#A55129"></HeaderStyle>
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ID" 
                  InsertVisible="False" DataField="userId"
                    SortExpression="userId">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Name" 
                 DataField="Name" 
                 SortExpression="Name"></asp:BoundField>
                <asp:BoundField HeaderText="Email" 
                 DataField="Email" 
                 SortExpression="Email"></asp:BoundField>
                <asp:buttonfield buttontype="Button" 
                 commandname="Select"
                 headertext="Add Recepient" 
                 text="Select"/>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
             BackColor="#738A9C"></SelectedRowStyle>
            <RowStyle ForeColor="#8C4510" 
               BackColor="#FFF7E7"></RowStyle>
        </asp:GridView>
        
        <h3>Inhoud</h3>
        <asp:TextBox ID="TextBox1" TextMode="multiline" runat="server" CssClass="textbox" />
        <br />
        <br />
        <asp:button id="mailTest" Text="MAILTEST" onClick="mailTest_Click" runat="server"/>

</asp:Content>
