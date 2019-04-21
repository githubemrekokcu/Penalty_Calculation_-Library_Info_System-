<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Penalty_Calculation_V2.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Library Information Result Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <p class="text-center text-uppercase">Library Information Result Page</p>
        <form id="form1" runat="server">
            <div class="col-50">
                <table class="table table-bordered">
                    <tbody>
                        <tr>
                            <td>
                                <label>Calculated Business Days</label></td>
                            <td>
                                <label class="font-weight-bold" runat="server" id="lbl_BusinessDay">Not Read Data :(</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Penalty Informations</label></td>
                            <td>
                                 <label class="font-weight-bold" runat="server" id="lbl_PenaltyDayPrice">Not Read Data :(</label></td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </form>

    </div>
</body>
</html>