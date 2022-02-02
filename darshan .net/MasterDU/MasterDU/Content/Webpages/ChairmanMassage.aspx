<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChairmanMassage.aspx.cs" Inherits="MasterDU.Content.Webpages.ChairmanMassage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../CSS/MainCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <section>
        <div class="container" id="u-section">
            <h1>
                Chairman's Message
            </h1>
            <hr />
            <asp:Image ID="Image1" runat="server" ImageUrl="https://gtu.darshan.ac.in/Upload/DIET/Documents/RGD_10052017_035010AM.png" ToolTip="Dr. R.G. Dhamsaniya" AlternateText="Dr. R.G. Dhamsaniya"/>
            <p align="justify">
                Success knocks to those, who work vigorously and stays with those, who don’t rest on the laurels of the past. We have been a standing example for reaching success and sustaining it. We have been instrumental in shaping the success potential of many future citizens across the globe. In the process of this journey, we have set standards, initiated trends and achieved new milestones, successfully. Darshan Institute of Engineering & Technology established in 2009, affiliated to GTU (Gujarat Technological University) and approved by AICTE, New Delhi.
            </p>
            <br />
            <p align="justify">
                The Institute contributes quality education and encourages students to develop creative thinking, analytical aptitude and to acquire management techniques both in practical fields as well as academics.
            </p>
            <p align="justify">
                At Institute, we have highly qualified, experienced and dedicated faculty, state of art infrastructure and a pleasant environment, which empowers the students to meet the varied challenging requirements. With a long and rewarding history of achievement in education behind us, our management team will continue to move progressive together with determination, dignity, and enthusiasm.
            </p>
        </div>
    </section>
</asp:Content>
