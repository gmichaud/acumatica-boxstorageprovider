<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true"
    CodeFile="SM202620.aspx.cs" Inherits="Pages_SM_SM202620" Title="Box Screen Configuration"
    ValidateRequest="false" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="dsContent" ContentPlaceHolderID="phDS" runat="server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" PrimaryView="Screens" TypeName="PX.SM.BoxStorageProvider.ScreenConfiguration" SuspendUnloading="False">
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="formContent" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="screensForm" runat="server" DataSourceID="ds" DataMember="Screens" Width="100%">
        <Template>
		 <px:PXLayoutRule ID="PXLayoutRule1" runat="server" ControlSize="XL" LabelsWidth="M" ></px:PXLayoutRule>  
		 <px:PXSelector ID="edProductionReportID" runat="server" DataField="ScreenID" ValueField="ScreenID" DataSourceID="ds" CommitChanges="true"/>
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="gridContent" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid ID="fieldsGrid" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" AdjustPageSize="Auto" AllowSearch="True" SkinID="Details" MatrixMode="true" Caption="Grouping Fields" CaptionVisible="true">
        <Levels>
            <px:PXGridLevel DataMember="Fields">
                <Mode InitNewRow="True" />
                <RowTemplate>
                    <px:PXDropDown ID="fieldDdlID" runat="server" DataField="FieldName" />
                </RowTemplate>
                <Columns>
                    <px:PXGridColumn AllowNull="False" DataField="FieldName" TextAlign="Left" Width="150px" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
    </px:PXGrid>
</asp:Content>
