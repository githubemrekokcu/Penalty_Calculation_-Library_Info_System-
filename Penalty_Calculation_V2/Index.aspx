<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Penalty_Calculation_V2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Library Information Entry Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <meta name="description" content="The description of my page" />
</head>
<body>
    <div class="container">
        <p class="text-center text-uppercase">Library Information Entry Page</p>
        <form id="form1" runat="server">
            <div class="col-50">
                <table class="table table-bordered">
                    <tbody>
                        <tr>
                            <td>
                                <label class="font-weight-bold">Date the book is checked out</label></td>
                            <td>
                                <input id="txt_CheckOutDate" type="text" class="form-control" runat="server" placeholder="dd/MM/YYYY" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="font-weight-bold">Date the book is returned</label></td>
                            <td>
                                <input id="txt_ReturnedDate" type="text" class="form-control" runat="server" placeholder="dd/MM/YYYY" /></td>
                        </tr>
                        <tr>
                            <td>
                                <label class="font-weight-bold">Country selection</label></td>
                            <td>
                                <asp:DropDownList ID="drp_CountryList" runat="server" class="form-control"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:Button ID="btn_Calculate" runat="server" Text="Calculate" CssClass="btn btn-info col-4" OnClick="btn_Calculate_Click" /></td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </form>

    </div>
</body>
</html>
