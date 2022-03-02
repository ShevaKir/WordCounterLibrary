<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WordCounterWebUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Top Words  Density"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox1" runat="server" Height="89px" Width="646px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="1 Word" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="2 Words" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="3 Words" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Count word: "></asp:Label>
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="TOP"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
