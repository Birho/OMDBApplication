<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OMDBApplication.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OMDB</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFiletype" runat="server" Text="Select file type to use"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonJSON" runat="server" Checked="True" GroupName="FileType" Text="JSON" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonXML" runat="server" GroupName="FileType" Text="XML" />
            <br />
            <br />
            <asp:Label ID="LabelIDorString" runat="server" Text="Select ID for known movie or movie name"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonName" runat="server" Checked="True" GroupName="NameorID" OnCheckedChanged="RadioButtonName_CheckedChanged" Text="Name" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonID" runat="server" GroupName="NameorID" OnCheckedChanged="RadioButtonID_CheckedChanged" Text="ID (select known movie from list)" />
            <br />
            <br />
            <asp:ListBox ID="ListBoxMovie" runat="server" BackColor="Silver" Enabled="False" OnSelectedIndexChanged="ListBoxMovie_SelectedIndexChanged" Width="300px"></asp:ListBox>
            <br />
            <br />
            <asp:TextBox ID="TextBoxInput" runat="server" Width="298px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelInput" runat="server" Text="Search input"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Buttonfind" runat="server" OnClick="Buttonfind_Click" Text="Find Movie" />
            <br />
            <br />
            <asp:Label ID="LabelMessages" runat="server" Text="Message"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
            <br />
            <br />
            <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/MyFiles/SmileyHalo.png" />
        </div>
    </form>
</body>
</html>
