<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentEnrollmentForm.aspx.cs" Inherits="studentEnrollmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <h3 align="center"> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> </h3>
    <form id="form1" runat="server">
    <div>
        <h1 align="center">Login If Already Registered</h1>
        <table>
            <tr>
                <td>*</td>
                <td>Student Name</td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudentNameLogin" />
                </td>
                <td>
                   <asp:RequiredFieldValidator ID="rfvNameLogin" runat="server" BackColor="White" ControlToValidate="txtStudentNameLogin" Display="Dynamic" ErrorMessage="Enter The Student Name" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>*</td>
                <td>Password</td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPasswordLogin" />
                </td>
                <td>
                   <asp:RequiredFieldValidator ID="rfvPasswordLogin" runat="server" BackColor="White" ControlToValidate="txtPasswordLogin" Display="Dynamic" ErrorMessage="Enter The Correct The Password" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revPasswordLogin" runat="server" ControlToValidate="txtPasswordLogin" Display="Dynamic" ErrorMessage="Password Should Be Minimum 8 Charcter(one digit,one special char.)" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&amp;])[A-Za-z\d@$!%*?&amp;]{8,}$" ValidationGroup="Login"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnSaveLogin" Text="Login" OnClick="btnSaveLogin_Click" ValidationGroup="Login" style="height: 26px" />
                </td>

            </tr>
        </table>
        <h1 align="center">Student Enrollment Form</h1><br />
       
        &nbsp;<table>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="vsEnrollmentForm" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="Red" HeaderText="Solve Following Error(s)" ValidationGroup="EnrollmentLogin" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>*</td>
                <td>Student Name</td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudentName" />
                </td>
                <td>
                   <asp:RequiredFieldValidator ID="rvfName" runat="server" BackColor="White" ControlToValidate="txtStudentName" Display="Dynamic" ErrorMessage="Enter The Name" ForeColor="Red" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>*</td>
                <td>Enrollment No</td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEnrollmentNo" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEnrollmentNo" runat="server" ErrorMessage="Enter The EnrollmentNumber" ControlToValidate="txtEnrollmentNo" Display="None" ForeColor="Red" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revEnrollmentNo" runat="server" Display="Dynamic" ErrorMessage="Enter Valid Enrollment Number(12 digit)" ForeColor="Red" ValidationExpression="^[0-9]{2}054[0-9]{7}$" ControlToValidate="txtEnrollmentNo"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Institute</td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="ddlOfInstitute" runat="server">
                        <asp:ListItem Value="-1" Text="Select The Institute"></asp:ListItem>
                        <asp:ListItem Value="DIET" Text="Darshan Institute Of Engineering & Technology"></asp:ListItem>
                        <asp:ListItem Value="DIETDS" Text="Darshan Institute Of Engineering & Technology in Diploma Studies"></asp:ListItem>
                        <asp:ListItem Value="SOE" Text="School Of Engineering - Darshan University"></asp:ListItem>
                        
                    </asp:DropDownList>                 
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ControlToValidate="ddlOfInstitute" Display="None" ErrorMessage="Select Any Institute" ForeColor="Red" InitialValue="-1" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>*</td>
                <td>Department</td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="ddlOfDepartment" runat="server">
                        <asp:ListItem Value="-1" Text="Select The Department"></asp:ListItem>
                        <asp:ListItem Value="CE" Text="Computer Engineering"></asp:ListItem>
                        <asp:ListItem Value="ME" Text="Mechanical Engineering"></asp:ListItem>
                        <asp:ListItem Value="EE" Text="Electrical Engineering"></asp:ListItem>
                        <asp:ListItem Value="CI" Text="Civil Engineering"></asp:ListItem>

                    </asp:DropDownList>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlOfDepartment" Display="None" ErrorMessage="Select Any Department" ForeColor="Red" InitialValue="-1" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td>Date Of Birth</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="None" ErrorMessage="Enter The Valid Date(MM/DD/YY)" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="EnrollmentLogin"></asp:CompareValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td></td>
                <td>Semester</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtSemester" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RangeValidator ID="rvSemester" runat="server" ControlToValidate="txtSemester" Display="None" ErrorMessage="Semester Should Be 1 To 8" ForeColor="Red" MaximumValue="8" MinimumValue="1" Type="Integer" ValidationGroup="EnrollmentLogin"></asp:RangeValidator>
                 </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">Email</td>
                <td class="auto-style1">:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="None" ErrorMessage="Enter The Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="EnrollmentLogin"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style1">
                    </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Mobile Number</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Enter The Mobile Number" ForeColor="Red" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Enter The Mobile Number Shoulde Be (10 Digit)" ForeColor="Red" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$" ValidationGroup="EnrollmentLogin"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>*</td>
                <td>Password</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Enter The Correct Password" ForeColor="Red" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Password Should Be Minimum 8 Charcter(one digit,one special char.)" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&amp;])[A-Za-z\d@$!%*?&amp;]{8,}$" ValidationGroup="EnrollmentLogin"></asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td>*</td>
                <td>Retype Password</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtRetypePassword" TextMode="Password" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword" Display="None" ErrorMessage="Enter The Valid Password " ForeColor="Red" EnableViewState="False" ValidationGroup="EnrollmentLogin"></asp:RequiredFieldValidator>
                 </td>
                <td>
                    <asp:CompareValidator ID="cvRetypePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword" Display="None" ErrorMessage="Enter The Same As Password" ForeColor="Red" ValidationGroup="EnrollmentLogin"></asp:CompareValidator>
                 </td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="chkTermsCondition" runat="server" Text="Agree To Terms &amp; Condition" ValidationGroup="EnrollmentLogin" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EnrollmentLogin" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
