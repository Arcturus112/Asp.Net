<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Campus.aspx.cs" Inherits="MasterDU.Content.Webpages.Campus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../CSS/MainCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <section>
        <div class="container" id="u-section">
            <h2>Life at Campus</h2>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Image runat="server" ID="imgEvent1" ImageUrl="https://darshan.ac.in/U01/Page/30---16-06-2021-03-58-33.jpeg" Height="230px" />
                </div>
                <div class="col-md-8">
                    <h4>Frolic - Techfest</h4>
                    <p align="justify">
                        Frolic is National Level Technical Symposium where talent meets opportunity. Technical fests should be an essential part of course curriculum as it gives a platform to young brains to showcase their innovative ideas and compete with their peers.
                    </p>
                    <p align="justify">
                        These technical fests are an amalgamation of fun and learning where spectacular ideas are displayed, and students learn and feel inspired. These events guide engineers, computer experts, researchers to dream bigger and achieve them. Frolic hosts technical competitions and events covering all areas of engineering are organized every year in the first week of September, where students participate enthusiastically to make the Tech-Fest a success.
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <h4>Udaan - Cultural Festival</h4>
                    <p align="justify">
                        Udaan is an annual cultural festival. It usually takes place in the second week of April. This consists of literary and debating events/competitions like singing, dance, play, mimicry, garba, etc. Students put in their best efforts to make college fests entertaining and exciting. These multiple cultural events, technical fests, celebrity performances, competitions, partying with friends make you confident and job-ready.
                    </p>
                    <p align="justify">
                        These amazing college fests play a significant role in shaping the career of a student, read on to know-how. Students who volunteer and organize college fests display their self-starter attitude. Students also develop four essential skills from organizing fests – planning, teamwork, leadership, and multi-tasking. They also learn how to balance personal and professional life which helps in differentiating between doers and dreamers.
                    </p>
                </div>
                <div class="col-md-4">
                    <asp:Image runat="server" ID="imgEvent2" ImageUrl="https://darshan.ac.in/U01/Page/30---18-06-2021-10-19-11.jpeg" Height="230px" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Image runat="server" ID="imgEvent3" ImageUrl="https://darshan.ac.in/U01/Page/30---18-06-2021-10-17-37.jpg" Height="230px" />
                </div>
                <div class="col-md-8">
                    <h4>Project Exhibition</h4>
                    <p align="justify">
                        The objective behind organizing the project exhibition is to give a platform to final year students to showcase their creativity and hard work they have put in the past year in terms of their final year project work. Further, the interaction of juniors with their senior colleagues will give them exposure to various possible areas and help them to identify their area of interest and where they can take up projects.
                    </p>
                    <p align="justify">
                        Experts from industries, as well as other senior faculties from the institute who visit the exhibition, will not only motivate students but also give them directions for future work as well as for converting the concept to a marketable product.
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <h4>Sports Festival</h4>
                    <p align="justify">
                        Studies have revealed that students who are involved in athletic activities achieve better scores through their education. With the view of the overall development of students, Institute organizes a Sports Festival every year in the winter season. Students can participate in inter-college competitions at the university & state level.
                    </p>
                    <p align="justify">
                        During sports festivals a large number of students participate in outdoor games like Cricket, Football, Volleyball, etc., and indoor games like Badminton, Table Tennis, Carom, Chess, etc. Students develop better fitness habits and coordination by engaging in sports and exercises. Through sports, students can build a wide range of abilities and skills such as leadership, confidence, teamwork, patience, self-reliance, trust, and many more which facilitate the overall development of an individual.
                    </p>
                </div>
                <div class="col-md-4">
                    <asp:Image runat="server" ID="imgEvent4" Height="230px" ImageUrl="https://darshan.ac.in/U01/Page/30---18-06-2021-10-20-00.jpg" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
