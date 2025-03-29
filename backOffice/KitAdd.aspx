<%@ Page Title="" Language="C#" MasterPageFile="~/backOffice/main.Master" AutoEventWireup="true" CodeBehind="KitAdd.aspx.cs" Inherits="CardVirtual.backOffice.KitAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
       <div class="content-header row">
                <div class="content-header-left col-md-6 col-12 mb-2">
                    <h3 class="content-header-title">העלאת קיטים</h3>
                    <div class="row breadcrumbs-top">
                        <div class="breadcrumb-wrapper col-12">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx">דף הבית</a>
                                </li>
                                <li class="breadcrumb-item"><a href="KitList.aspx">קיטים</a>
                                </li> 
                                <li class="breadcrumb-item active">הוספת קיט
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
                

                <section id="add-payments">
                    <div class="card">
                        <div class="card-header">
                            <h2 class="card-title">הוסף קיט חדש</h2>
                        </div>
                        <div class="card-body">
                             <asp:HiddenField ID="HIdKitId" runat="server" />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="TxtKitName" runat="server" class="form-control" placeholder="נא הזן שם קיט" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                         <asp:TextBox ID="TxtKitTag" runat="server" class="form-control" placeholder="נא הזן מספר תג" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                         <asp:TextBox ID="TxtKitBarcode" runat="server" class="form-control" placeholder="נא הזן ברקוד" />
                                    </div>
                                </div>
                            </div>
                            
                             <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="TxtKitDesc" runat="server" class="form-control" placeholder="תיאור"/>
                                    </div>
                                </div>
                            </div>
                           <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="TxtKitImage" runat="server" class="form-control" placeholder="תמונה"/>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group"><asp:DropDownList runat="server" ID="DDLCustomerId"  class="form-control"></asp:DropDownList>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                         <asp:TextBox ID="TxtNumOfParts" runat="server" class="form-control" placeholder="נא הזן מספר החלקים" />
                                    </div>
                                </div>
                            </div>
                             
                        <div class="card-footer ml-auto">
                            <span>
                                 <asp:Button ID="BtnSave" runat="server" class="btn btn-outline-success mr-1" Text="שמירה" OnClick="BtnSave_Click" />
                            </span>
                        </div>

                    </div>
                </section>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
