z<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyperLink.aspx.cs" Inherits="Project2.hyperLink" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title><link href="hyperlink.css" rel="stylesheet" /><link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" /></head><body><form id="form1" runat="server">
        <div>
            <div class="DImage">
                <asp:Image ID="imgDarshan" runat="server" ImageUrl="https://darshan.ac.in/Content/media/DU-logo.svg" AlternateText="Darshan University" ToolTip="Darshan University" />
            </div>
            <h1 class="Header">Darshan University</h1>

            <nav class="navbar navbar-expand-lg fixed-top navbar-dark bg-dark">
                <div class="container-fluid">
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li>
                                <asp:HyperLink ID="hlHomePage" class="nav-link active" runat="server" NavigateUrl="https://darshan.ac.in/" Target="_blank">Home</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlAboutUniversity" class="nav-link active" runat="server" NavigateUrl="#About_University">About University</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlCourses" class="nav-link active" runat="server" NavigateUrl="#Courses_Run_By_University">Courses Run By University</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlDepartments" class="nav-link active" runat="server" NavigateUrl="#Departments">Departments</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlStaff" class="nav-link active" runat="server" NavigateUrl="#Staff_Members">Staff Members</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlNews" class="nav-link active" runat="server" NavigateUrl="#News">News</asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hlContact" class="nav-link active" runat="server" NavigateUrl="#Contact">Contact</asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="container">
                <hr />
                <h2><a name="About_University"></a>
                    About University
                </h2>
                <hr />
                <p style="box-sizing: border-box; margin-top: 0px; margin-bottom: 1rem; text-align: justify; font-size: 14px; font-size: x-large">
                    Darshan University (DU), is a prominent organization offering a broad slate of academic programs and professional courses for undergraduate, graduate and postgraduate programs in Engineering, Science &amp; 
                    Technology. The University is located in peaceful and sylvan surroundings with distinctive collegiate structure, about 19 km from Rajkot, Gujarat, India. It was established as an Engineering Institute in the year 
                    2009, by Shree G. N. Patel Education &amp; Charitable Trust with the objective to impart quality education and training in various fields of Engineering and Technology. It has now been transformed to the DARSHAN 
                    UNIVERSITY through an Act by the Government of Gujarat under Gujarat State Private Universities (Amendment) Act, 2021 (Act no. 15).From its inception, the organization has grown steadily and created a unique 
                    identity in the field of Engineering &amp; Technology by implementing skill and training-based foundation for education. The academic environment at the campus creates an ambience to promote creativity and 
                    exploration of technical skills. Darshan University is committed to the generation of knowledge, innovations and its contribution towards the development of the Nation.
                </p>
                <hr />
                <h2><a name="Courses_Run_By_University"></a>
                    Courses Run By University
                </h2>
                <hr />

                <h3>Diploma (After 10th)</h3>
                <br />
                <ol>
                    <li>Diploma Engineering (Diploma)(Civil Engineering, Mechanical Enginering, Electrical Engineering, Computer Science & Engineering)
                    </li>
                </ol>
                <h3>Doctoral (After UG)</h3>
                <br />
                <ol>
                    <li>Ph.D. (Ph.D.)(Computer Science, Computer Science and Engineering, Civil Engineering, Mechanical Engineering, Management, Commerce, Microbiology)
                    </li>
                </ol>
                <h3>Post Graduate (After UG)</h3>
                <br />
                <ol>
                    <li>Master of Business Administration (MBA)
                    </li>
                    <li>Master of Computer Application (MCA)
                    </li>
                    <li>Master of Design - Medical Product Design (M.Des.)
                    </li>
                    <li>Master of Design - Product Design (M.Des.PD)
                    </li>
                    <li>Master of Science (M.Sc.) (Microbiology)
                    </li>
                    <li>Master of Technology (M.Tech.) (Structural Engineering, Transportation Engineering, Thermal Engineering, Electrical Engineering, Software Engineering)2 Years
                    </li>
                </ol>
                <h3>Under Graduate (After 12th)</h3>
                <ol>
                    <li>Bachelor of Business Administration (BBA)
                    </li>
                    <li>Bachelor of Commerce (B.Com.)
                    </li>
                    <li>Bachelor of Computer Application (BCA)
                    </li>
                    <li>Bachelor of Science (B.Sc.)
                    </li>
                    <li>Bachelor of Science in Information Technology (B.Sc. IT)
                    </li>
                    <li>Bachelor of Technology (B.Tech.)(Civil Engineering, Mechanical Enginering, Electrical Engineering, Computer Science & Engineering)
                    </li>
                    <li>Bachelor of Technology (Diploma to Degree) (D2D) (Computer Engineering, Civil Engineering, Electrical Engineering, Mechanical Engineering)
                    </li>

                </ol>

                <hr />
                <h2><a name="Departments"></a>
                    Departments
                </h2>
                <hr />
                <h3>Computer Engineering Department</h3>
                <p align="justify">
                    Computer engineer, also known as a software engineer, is responsible for designing, developing, testing and evaluating the software that make our computers work. 
                    This involves designing and coding of new programs and applications to meet the needs of a business or an individual. A computer engineer may also be responsible for constructing 
                    and managing on organization's computer system.Computer Engineering Department @Darshan is highly reputed in academics and industry. it is well known for its integrity, faculties, 
                    placement, infrastructure, and industry linkage nad apps development. Environment of the department is friendly and professional. Students can access resources any time,faculties 
                    are available round the clock. In a nutshell, it's a dream place for study and holistic development.
                </p>

                <h3>Civil Engineering Department</h3>
                <p align="justify">
                    Department of Civil Engineering believes that Real engineering means: Institute Knowledge with Industrial Experience. Our ancient Sanskrit, "योगः कर्मेसु कौशलम" also supports the same. 
                    To make students an excellent in the field of civil engineering. The department has designed different activities which provide a multitude of a platform for students to enhance their 
                    technical and industrial skills. Some of the activities are listed below:
                    <strong>अधिभूतं - The material manifestation</strong>
                    Under this program, students acquire the special skill of material identification by visualizing which is an important and required skill in the field.
                    <strong>Kaizen</strong>
                    Students are identified and divided into groups based on their area of interest. Industrial/field exposure provided by faculties which helps students to prepare technical articles 
                    and presentation for the expression of their views, talents, knowledge etc.
                </p>

                <h3>Electrical Engineering Department</h3>
                <p align="justify">
                    Electrical Engineering Department (EED), at Institute is involved in providing quality education at both Postgraduate and Undergraduate levels. Department aims to produce engineers 
                    who are critical, original, and independent thinkers along with the strong foundation in contemporary electrical engineering, basic sciences, mathematics, computing, and communication. 
                    Department also believes in values, attitudes, diversity of opinion,ethics and vision that will prepare student for lifetimes of success,continued learning and leadership in their 
                    chosen careers.
                </p>

                <h3>Mechanical Engineering Department</h3>
                <p align="justify">
                    Mechanical Engineering education is a very strategic and specialized segment where the engineers are being trained to meet the innovative demands of futuristic technologies. In the recent past, 
                    Department of Mechanical Engineering at DIET has established itself as one of the premier brands in technical education in region and has enhanced its reputation by introducing B.E. 
                    and M.E. programs.Department of Mechanical Engineering at DIET has flourished to a great extent due to their experienced faculties from diversified fields, optimal faculty to 
                    student ratio and enthusiastic students. Department of Mechanical Engineering focuses on comprehensive course curriculum with intense practical exposure to students which will enable 
                    them to take up challenging roles in professional careers.Our initiatives are aimed to transform education and build careers of our students with whole hearted acceptance from industries 
                    across the nation. We give equal emphasis on fundamental studies, practical exposure and industrial orientation.Department is also encouraging their faculties for quality improvement programs 
                    to learn latest change and trends in their respective fields.
                </p>

                <hr />
                <h2><a name="Staff_Members"></a>
                    Staff Members
                </h2>
                <hr />
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <div class="col">
                        <div class="card h-100">
                            <asp:Image ID="imgStaff1" runat="server" ImageUrl="https://darshan.ac.in/U01/Faculty-Photo/5---21-06-2021-10-50-15.jpg" class="card-img-top" AlternateText="Dr. Gopi Sanghani" ToolTip="Dr. Gopi Sanghani" />
                            <div class="card-body">
                                <h5 class="card-title">Dr. Gopi Sanghani</h5>
                                <span>Dean - School of Computer Science</span>
                                <hr />
                                <div>
                                    <span>Ph.D. , M.E. (CE)</span>
                                </div>
                                <div>
                                    <div>
                                        <hr />
                                        <div>
                                            <div>
                                                <span>Experience</span>
                                                <span>21+ Years</span>
                                            </div>
                                            <div>
                                                <span>Working Since</span>
                                                <span>Jul-2012</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col">
                        <div class="card h-100">
                            <asp:Image ID="imgStaff2" runat="server" ImageUrl="https://darshan.ac.in/U01/Faculty-Photo/01CENMG%20(2)_19042019_063552AM_21052019_044853AM.jpg" class="card-img-top" AlternateText="Dr. Nilesh Gambhava" ToolTip="Dr. Nilesh Gambhava" />
                            <div class="card-body">
                                <h5 class="card-title">Dr. Nilesh Gambhava</h5>
                                <span>Professor</span>
                                <hr />
                                <div>
                                    <span>Ph.D. , M.E. (CE)</span>
                                </div>
                                <div>
                                    <div>
                                        <hr />
                                        <div>
                                            <div>
                                                <span>Experience</span>
                                                <span>19+ Years</span>
                                            </div>
                                            <div>
                                                <span>Working Since</span>
                                                <span>Jul-2009</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col">
                        <div class="card h-100">
                            <asp:Image ID="imgStaff3" runat="server" ImageUrl="https://darshan.ac.in/U01/Faculty-Photo/02CEPUJ_19042019_063653AM.jpg" class="card-img-top" AlternateText="Dr. Pradyumansinh Jadeja" ToolTip="Dr. Pradyumansinh Jadeja" />
                            <div class="card-body">
                                <h5 class="card-title">Dr. Pradyumansinh Jadeja</h5>
                                <span>Associate Professor</span>
                                <hr />
                                <div>
                                    <span>Ph.D. , M.E. (CE)</span>
                                </div>
                                <div>
                                    <div>
                                        <hr />
                                        <div>
                                            <div>
                                                <span>Experience</span>
                                                <span>16+ Years</span>
                                            </div>
                                            <div>
                                                <span>Working Since</span>
                                                <span>Jul-2009</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col">
                        <div class="card h-100">
                            <asp:Image ID="imgStaff4" runat="server" ImageUrl="https://darshan.ac.in/U01/Faculty-Photo/06CEFAS_19042019_063811AM.jpg" class="card-img-top" AlternateText="Prof. Firoz Sherasiya" ToolTip="Prof. Firoz Sherasiya" />
                            <div class="card-body">
                                <h5 class="card-title">Prof. Firoz Sherasiya</h5>
                                <span>Assistant Professor</span>
                                <hr />
                                <div>
                                    <span>M.E. (CE)</span>
                                </div>
                                <div>
                                    <div>
                                        <hr />
                                        <div>
                                            <div>
                                                <span>Experience</span>
                                                <span>16+ Years</span>
                                            </div>
                                            <div>
                                                <span>Working Since</span>
                                                <span>Jul-2011</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <hr />
                <h2><a name="News"></a>
                    News
                </h2>
                <hr />
                <div class="row">
                    <div class="col-md-3 col-lg-3 col-sm-4 col-xs-6">
                        <asp:HyperLink ID="hlNews1" runat="server" NavigateUrl="https://gtu.darshan.ac.in/Upload/DIET/Documents/DIET_eNewsletter_April_2021_15052021_104544AM.pdf" Target="_blank">
                            <div style="padding: 0px; border-radius: 5px; box-shadow: 0px 0px 3px 2px #DDD;">
                                <div style="padding: 5px; background-color: #666;">
                                    <h3 style="color: #fff; margin: 3px 0 5px 0;">January-June 2021</h3>
                                </div>
                                <div style="margin-bottom: 10px;">
                                    <div>
                                        <asp:Image ID="imgNews1" runat="server" Style="width: 100%" ImageUrl="https://gtu.darshan.ac.in/Upload/DIET/Documents/DIET_NewsLetter_Front_April_2021_15052021_104505AM.png" AlternateText="April 2021 News" ToolTip="April 2021 News" />
                                    </div>
                                </div>
                            </div>
                        </asp:HyperLink>
                    </div>


                    <div class="col-md-3 col-lg-3 col-sm-4 col-xs-6">
                        <asp:HyperLink ID="hlNews2" runat="server" NavigateUrl="https://gtu.darshan.ac.in/Upload/DIET/Documents/DIET_eNewsletter_March_2021_16042021_125354PM.pdf" Target="_blank">
                            <div class="thumbnails thumbnail-style " style="padding: 0px; border-radius: 5px; box-shadow: 0px 0px 3px 2px #DDD;">
                                <div style="padding: 5px; background-color: #666;">
                                    <h3 style="color: #fff; margin: 3px 0 5px 0;">May 2021</h3>
                                </div>
                                <div style="margin-bottom: 10px;">
                                    <div>
                                        <asp:Image ID="imgNews2" runat="server" Style="width: 100%" ImageUrl="https://gtu.darshan.ac.in/Upload/DIET/Documents/DIET_NewsLetter_March_2021_Front_16042021_125334PM.png" AlternateText="March 2021 News" ToolTip="March 2021 News" />
                                    </div>
                                </div>
                            </div>
                        </asp:HyperLink>
                    </div>
                </div>

                <hr />
                <h2><a name="Contact"></a>
                    Contact
                </h2>
                <hr />
                <h2 align="center">Contact Us</h2>
                <h4>Address</h4>
                <p>Rajkot - Morbi Highway,Rajkot - 363650, Gujarat (INDIA)</p>
                <h4>Email Address</h4>
                <p>info@darshan.ac.in</p>
                <h4>Contact Number</h4>
                <p>
                    +91 - 97277 47310<br />
                    +91 - 97277 47311
                </p>
                <h4>Schedule Time</h4>
                <p>
                    Mon-Sat	:	07:45 AM - 04:00 PM
                </p>
                <p class="auto-style1">
                    <strong>Sun	:	Closed</strong>
                </p>

                <hr />

                <div class="my-5">
                    <h2 class="d-flex justify-content-center">Radio Button</h2>
                    <strong>Select College:</strong>
                    <asp:RadioButton ID="rbDiet" runat="server" Text="DIET" GroupName="college" />
                    <asp:RadioButton ID="rbDietDs" runat="server" Text="DIETDS" GroupName="college" />
                    <br />
                    <asp:Button ID="btnClick" runat="server" Text="Courses" OnClick="btnClick_Click" />
                    <br />
                    <div>
                        <div id="diet" runat="server" visible="false">
                            <asp:RadioButton ID="rbComputerDiet" runat="server" Text="Computer Engineering - Degree" GroupName="Diet" /><br />
                            <asp:RadioButton ID="rbMechanicalDiet" runat="server" Text="Mechanical Engineering - Degree" GroupName="Diet" /><br />
                            <asp:RadioButton ID="rbElectricalDiet" runat="server" Text="Electrical Engineering - Degree" GroupName="Diet" /><br />
                            <asp:RadioButton ID="rbCivilDiet" runat="server" Text="Civil Engineering - Degree" GroupName="Diet" /><br />
                        </div>
                        <div id="dietDs" runat="server" visible="False">
                            <asp:RadioButton ID="rbComputerDietDs" runat="server" Text="Diploma In Computer Engineering" GroupName="DietDs" /><br />
                            <asp:RadioButton ID="rbMechanicalDietDs" runat="server" Text="Diploma In Mechanical Engineering" GroupName="DietDs" /><br />
                            <asp:RadioButton ID="rbElectricalDietDs" runat="server" Text="Diploma In Electrical Engineering" GroupName="DietDs" /><br />
                            <asp:RadioButton ID="rbCivilDietDs" runat="server" Text="Diploma In Civil Engineering" GroupName="DietDs" /><br />
                        </div>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Button ID="btnCourseCheck" runat="server" Text="Enter" OnClick="btnCourseCheck_Click" Width="71px" Visible="False" />
                        <br />
                        <strong id="textCourse" runat="server" visible="False">Selected Course Is:</strong>
                        <asp:Label ID="lblCourse" runat="server" Text="" Visible="False"></asp:Label>
                    </div>
                </div>

                <hr />

                <div>
                    <div>
                        <h2 class="d-flex justify-content-center">Check Box</h2>
                        <strong>Select Your College</strong>
                        <asp:CheckBox ID="chkDiet" runat="server" Text="DIET" />
                        <asp:CheckBox ID="chkDietds" runat="server" Text="DIETDS" /><br />
                        <asp:Button ID="btnClick2" runat="server" Text="Courses" OnClick="btnClick2_Click1"/>
                    </div>
                    <div>
                        <asp:CheckBox ID="chkCheckAll" runat="server" Text="Check All" Visible="False" OnCheckedChanged="chkCheckAll_CheckedChanged" AutoPostBack="True" /><br />
                        <asp:CheckBox ID="chkClearAll" runat="server" Text="Clear All" Visible="False" AutoPostBack="True" OnCheckedChanged="chkClearAll_CheckedChanged" /><br />
                    </div>
                    <div>
                        <asp:CheckBox ID="chkDietCe" runat="server" Text="Computer Engineering - Degree" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietMe" runat="server" Text="Mechanical Engineering - Degree" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietEe" runat="server" Text="Electrical Engineering - Degree" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietCi" runat="server" Text="Civil Engineering - Degree" Visible="False" /><br />
                    </div>
                    <div>
                        <asp:CheckBox ID="chkDietdsCe" runat="server" Text="Diploma in Computer Engineering" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietdsMe" runat="server" Text="Diploma in Mechanical Engineering" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietdsEe" runat="server" Text="Diploma in Electrical Engineering" Visible="False" /><br />
                        <asp:CheckBox ID="chkDietdsCi" runat="server" Text="Diploma in Civil Engineering" Visible="False" /><br />
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="lblCollegeSelection" runat="server"></asp:Label>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/><br />
                        <asp:Label ID="lblBranchSelection" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
