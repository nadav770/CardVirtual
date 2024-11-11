<%@ Page Title="" Language="C#" MasterPageFile="~/backOffice/main.Master" AutoEventWireup="true" CodeBehind="KitAdd.aspx.cs" Inherits="CardVirtual.backOffice.KitAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
       <div class="content-header row">
                <div class="content-header-left col-md-6 col-12 mb-2">
                    <h3 class="content-header-title">הוספת מיוחד קיט</h3>
                    <div class="row breadcrumbs-top">
                        <div class="breadcrumb-wrapper col-12">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx">דף הבית</a>
                                </li>
                                <li class="breadcrumb-item"><a href="#">תשלומים</a>
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
                <!-- Add Payments -->

                <section id="add-payments">
                    <div class="card">
                        <div class="card-header">
                            <h2 class="card-title">הוסף קיט חדש</h2>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Kit Id">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Kit Name">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Worker Name">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="date" class="form-control" placeholder="Payment Date">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="number" class="form-control" placeholder="Total Amount">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <input type="number" class="form-control" placeholder="Discount">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <select name="paymentMethod" class="form-control">
                                            <option value="select">Select Payment Method</option>
                                            <option value="cash">ניקוי חול</option>
                                            <option value="credit">חומצות</option>
                                            <option value="debit">qc</option>
                                            <option value="cheque">אריזה</option>
                                            <option value="netbanking">מוכן למשלוח</option>
                                            <option value="insaurance">נשלח</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <select name="paymentStatus" class="form-control">
                                            <option value="select">Select Payment Status</option>
                                            <option value="pending">Pending</option>
                                            <option value="partial">Partial</option>
                                            <option value="Complete">Complete</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer ml-auto">
                            <span>
                                <button class="btn btn-outline-success mr-1">Submit</button> <button class="btn btn-outline-danger">Cancel</button>
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
