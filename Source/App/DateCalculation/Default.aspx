<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="DateCalculation.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Date Calculator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Calculate duration between two dates</h1>
    <asp:ValidationSummary ID="validationSummary" runat="server" />
    
    <table>
    <tr>
    <td colspan="3">Enter start date</td>
    </tr>
    <tr>
    <td>Year:<asp:TextBox ID="txtStartYear" runat="server" /><asp:RangeValidator ID="rvStartYear" runat="server" ControlToValidate="txtStartYear" MaximumValue="4000" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write year from 1 to 4000 in the Box."/></td>
    <td>Month:<asp:TextBox ID="txtStartMonth" runat="server" /><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtStartMonth" MaximumValue="12" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write month from 1 to 12 in the Box."/></td>
    <td>Day:<asp:TextBox ID="txtStartDay" runat="server" /><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtStartDay" MaximumValue="31" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write day from 1 to 31 in the Box."/></td>
    </tr>
    <tr>
    <td colspan="3">Enter end date</td>
    </tr>
    <tr>
    <td>Year:<asp:TextBox ID="txtEndYear" runat="server" /><asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtEndYear" MaximumValue="4000" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write year from 1 to 4000 in the Box."/></td>
    <td>Month:<asp:TextBox ID="txtEndMonth" runat="server" /><asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtEndMonth" MaximumValue="12" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write month from 1 to 12 in the Box."/></td>
    <td>Day:<asp:TextBox ID="txtEndDay" runat="server" /><asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtEndDay" MaximumValue="31" MinimumValue="1" EnableClientScript="true"  Text="*" ErrorMessage="Please write day from 1 to 31 in the Box."/></td>
    </tr>
    </table><br />
    <asp:Panel ID="pnlResult" runat="server" Visible="false"> 
    It is <asp:Label id="lblResult" runat="server" /> days from the start date to the end date.
    </asp:Panel>
    <br />
    <asp:Button ID="btnClear" Text="Clear" runat="server" onclick="ClearButtonClick"/>
    <asp:Button ID="btnCalculate" Text="Calculate" runat="server" 
            onclick="CalculateButtonClick" />
    
    
    </div>
    </form>
</body>
</html>
