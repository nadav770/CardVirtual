<%@ Page Title="" Language="C#" MasterPageFile="~/backOffice/main.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="CardVirtual.backOffice.RoleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
     <div class="content-header row">
                <div class="content-header-left col-md-6 col-12 mb-2">
                    <h3 class="content-header-title">רשימת התפקידים</h3>
                    <div class="row breadcrumbs-top">
                        <div class="breadcrumb-wrapper col-12">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx">דף הבית</a>
                                </li>
                                
                                <li class="breadcrumb-item active">תפקידים
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>
                <div class="content-header-right col-md-6 col-12">
                    <div class="btn-group float-md-right" role="group" aria-label="Button group with nested dropdown">
                        <button class="btn btn-info round dropdown-toggle dropdown-menu-right box-shadow-2 px-2 mb-1" id="btnGroupDrop1" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="ft-settings icon-left"></i> Settings</button>
                        <div class="dropdown-menu" aria-labelledby="btnGroupDrop1"><a class="dropdown-item" href="card-bootstrap.html">Cards</a><a class="dropdown-item" href="component-buttons-extended.html">Buttons</a></div>
                    </div>
                </div>
            </div>
            <div class="content-body">
                <!-- List Of All Patients -->

                <section id="patients-list">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <h2 class="card-title">תחקירים</h2>
                                    <div class="heading-elements">
                                        <a href="RoleAdd.aspx" class="btn btn-danger round btn-sm"><i class="la la-plus font-small-2"></i>
                                           העלאת תפקידים</a>
                                    </div>
                                </div>
                                <div class="card-body collapse show">
                                    <div class="card-body card-dashboard">
                                    </div>
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered patients-list">
                                            <thead>
                                                <tr>
                                                    <th>מזזה תפקיד</th>
                                                    <th>שם תפקיד</th>
                                                   
                                                </tr>
                                            </thead>
                                          <tbody>
                                              <asp:Repeater ID="RptRole" runat="server">
                                                  <ItemTemplate>
                                                       <tr>
                                                    <td><%#Eval("RoleId")%></td>
                                                           <td><%#Eval("RoleName")%></td>
                                                          
                                                              <td><a href="RoleAdd.aspx?RoleId=<%#Eval("RoleId")%>"><i class="ft-edit text-success"></i></a>
                                                        <a href="#"><i class="ft-trash-2 ml-1 text-warning"></i></a>
                                                    </td>
                                                  
                                                </tr>
                                                  </ItemTemplate>
                                              </asp:Repeater>
                                          </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th>מזזה תפקיד</th>
                                                    <th>שם תפקיד</th>
                                                    
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
