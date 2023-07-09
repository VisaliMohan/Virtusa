<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="BusinessLoanPortal.Customer" %>


<!DOCTYPE html>
<html>
<head>
    <title>Customer Page</title>
</head>
<body>
    <form runat="server">
        <h2>Customer Profile</h2>
        <label>Full Name:</label>
        <input type="text" id="txtFullName" runat="server" /><br /><br />
        <label>Contact Number:</label>
        <input type="text" id="txtContactNumber" runat="server" /><br /><br />
        <label>Address:</label>
        <textarea id="txtAddress" runat="server"></textarea><br /><br />
        <label>Business Name:</label>
        <input type="text" id="txtBusinessName" runat="server" /><br /><br />
        <label>Business Type:</label>
        <input type="text" id="txtBusinessType" runat="server" /><br /><br />
        <!-- Add more fields for other_profile_fields... if necessary -->
        
        <h2>Document Upload</h2>
        <label>Aadhaar Card:</label>
        <input type="file" id="fileAadhaarCard" runat="server" /><br /><br />
        <label>PAN Card:</label>
        <input type="file" id="filePANCard" runat="server" /><br /><br />
        <label>Pay Slips:</label>
        <input type="file" id="filePaySlips" runat="server" /><br /><br />
        <label>Bank Statements:</label>
        <input type="file" id="fileBankStatements" runat="server" /><br /><br />
        <!-- Add more fields for other document proofs if necessary -->
        
        <h2>Loan Application</h2>
        <label>Loan Amount:</label>
        <input type="text" id="txtLoanAmount" runat="server" /><br /><br />
        <label>Purpose:</label>
        <input type="text" id="txtLoanPurpose" runat="server" /><br /><br />
        <label>Repayment Term:</label>
        <input type="text" id="txtRepaymentTerm" runat="server" /><br /><br />
        <!-- Add more fields for other_application_fields... if necessary -->
        
        <h2>Review</h2>
        <label>Review:</label>
        <textarea id="txtReview" runat="server"></textarea><br /><br />
        <label>Rating:</label>
        <input type="text" id="txtRating" runat="server" /><br /><br />
        
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" />
    </form>
</body>
</html>
