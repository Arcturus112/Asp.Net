<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="MasterDU.Content.Webpages.Programs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../CSS/MainCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <section>
        <div class="container" id="u-section">

            <h1>Academic Programs</h1>
            <hr />
            <br />
            <h2>Programs offered</h2>
            <hr />
            <div>
                <div>
                    <div>
                        <h3>Bachelor of Engineering</h3>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">Sr.</th>
                                    <th scope="col">Branch</th>
                                    <th scope="col">Intake</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>
                                        <a title="Courses offered by  Computer Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/CE/Courses">Computer Engineering  
                                        </a>
                                    </td>
                                    <td>180</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>
                                        <a title="Courses offered by  Civil Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/CI/Courses">Civil Engineering  
                                        </a>
                                    </td>
                                    <td>120</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>
                                        <a title="Courses offered by  Electrical Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/EE/Courses">Electrical Engineering  
                                        </a>
                                    </td>
                                    <td>60</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>
                                        <a title="Courses offered by  Mechanical Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/ME/Courses">Mechanical Engineering  
                                        </a>
                                    </td>
                                    <td>120</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <hr />
                <div>
                    <div>
                        <h3>Master of Engineering </h3>
                        <table  class="table table-striped">
                            <thead>
                                <tr>
                                    <th scope="col">Sr.</th>
                                    <th scope="col">Specialization</th>
                                    <th scope="col">Intake</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>
                                        <a title="Courses offered by  Computer Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/CE/Courses">Software Engineering  <small class="g-pt-4 g-color-gray-dark-v5"><span>(Computer Engineering)</span></small>
                                        </a>
                                    </td>
                                    <td>18</td>
                                </tr>
                                <tr>
                                    <th scope="row">2</th>
                                    <td>
                                        <a title="Courses offered by  Civil Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/CI/Courses">Structural Engineering  <small class="g-pt-4 g-color-gray-dark-v5"><span>(Civil Engineering)</span></small>
                                        </a>
                                    </td>
                                    <td>18</td>
                                </tr>
                                <tr>
                                    <th scope="row">3</th>
                                    <td>
                                        <a title="Courses offered by  Electrical Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/EE/Courses">Electrical Engineering  <small class="g-pt-4 g-color-gray-dark-v5"><span>(Electrical Engineering)</span></small>
                                        </a>
                                    </td>
                                    <td>18</td>
                                </tr>
                                <tr>
                                    <th scope="row">4</th>
                                    <td>
                                        <a title="Courses offered by  Mechanical Engineering  - Darshan Institute of Engineering &amp; Technology" href="https://gtu.darshan.ac.in/DIET/ME/Courses">Thermal Engineering  <small class="g-pt-4 g-color-gray-dark-v5"><span>(Mechanical Engineering)</span></small>
                                        </a>
                                    </td>
                                    <td>18</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>


        </div>
    </section>
</asp:Content>
