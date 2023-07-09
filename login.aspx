<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BusinessLoanPortal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous" />
    <title>Login</title>
  </head>

<body>
    <form id="form1" runat="server">
        <section>
      <div class="container mt-5 pt-5">
        <div class="row">
          <div class="col-10 col-sm-7 col-md-6 m-auto">
            <div class="card border-0 shadow">
              <div class="card-body">
                  <div class="text-center" style="color:#0066B6">
                  <h4>Business Loan Portal</h4></div>
                  <asp:Label ID="label1" Text="" runat="server"></asp:Label>
                  <asp:TextBox ID="txtusername" runat="server" class="form-control my-4 py-2" placeholder="Username"/>
                  <asp:TextBox ID="txtpassword" runat="server" class="form-control my-4 py-2" TextMode="Password" placeholder="Password" /> 
                  <div class="text-center mt-3">
                      <asp:CheckBox ID="chkAdminLogin" runat="server" Text="Login as admin" CssClass ="align-content-md-end"/><br /><br />
                      <asp:Button ID="LoginBtn" Text="Login" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                  </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    </form>
</body>
</html>


