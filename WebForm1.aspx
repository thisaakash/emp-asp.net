<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="cimcom.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <style>
        .form-container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
        }
        .form-container input, .form-container select {
            width: 100%;
            padding: 10px;
            margin: 5px 0 10px 0;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .form-container input[type=submit] {
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
        .form-container input[type=submit]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-container">
        <div>
            <label for="TextBox1">EmpID:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="TextBox2">EmpName:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="TextBox3">EmailID:</label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div>
            
            <table>
                <tr>
                    <td>
                        <label for="male">Gender:</label>
                    </td>
                    <td>
                        <asp:RadioButton ID="male" runat="server" Text="Male" GroupName="gender" />
                    </td>
                    <td>
                        <asp:RadioButton ID="female" runat="server" Text="Female" GroupName="gender" />
                    </td>
                </tr>
            </table>
            
        </div>
        <div>
            <label for="TextBox4">DOJ:</label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" />
            <asp:Button ID="Button4" runat="server" Text="View" OnClick="Button4_Click" />
        </div>
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" Value="Insert" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                    <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="DOJ" HeaderText="DOJ" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="Button5" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("EmpID") %>' />
                            <asp:Button ID="Button6" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("EmpID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
