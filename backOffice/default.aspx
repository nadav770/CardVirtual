<%@ Page Title="" Language="C#" MasterPageFile="~/backOffice/main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CardVirtual.backOffice._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
     <div class="content-header row">
            </div>
            <div class="content-body">
                <!-- Hospital Info cards -->
                <div class="row">
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                             <i class="la la-users font-large-2 dark"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">עובדים פעילים</h5>
                                            <h3 class="text-bold-600">122</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                             <i class="la la-dollar font-large-2 success"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">עבודות בתהליך</h5>
                                            <h3 class="text-bold-600">34</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                            <i class="la la-calendar-check-o font-large-2 purple"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">סה"כ JobId עד היום</h5>
                                            <h3 class="text-bold-600">3.5K</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                             <i class="la la-users font-large-2 dark"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">לקוחות</h5>
                                            <h3 class="text-bold-600">179</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                            <i class="la la-bar-chart font-large-2 warning"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">חברות בשיתוף פעולה עם CardFlow   </h5>
                                            <h3 class="text-bold-600">500</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-12">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <a href="Actions.aspx">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                            <i class="la la-area-chart font-large-2 pink"></i>
                                        </div>
                                        <div class="media-body text-right">
                                           
                                            <h5 class="text-muted text-bold-500">שים לב שהקיט נקלט כבר במערכת!</h5>
                                            <h3 class="text-bold-600">התחל פעולה</h3>
                                        </div>
                                    </div>
                                    </a>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <a href="KitAdd.aspx">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                           <i class="la la-server font-large-2 yellow"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">רשימת קיטים</h5>
                                            <h3 class="text-bold-600">לחץ כאן להעלאת קיט</h3>
                                        </div>
                                    </div>
                                    </a>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-">
                        <div class="card pull-up">
                            <div class="card-content">
                                <div class="card-body">
                                    <a href="StockKitList.aspx">
                                    <div class="media d-flex">
                                        <div class="align-self-center">
                                           <i class="la la-paste font-large-2 gray-dark"></i>
                                        </div>
                                        <div class="media-body text-right">
                                            <h5 class="text-muted text-bold-500">מלאי קיטים</h5>
                                            <h3 class="text-bold-600">כאן ניתן לצפות במלאי הקיים</h3>
                                        </div>
                                    </div>
                                    </a>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
               
                
                
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
