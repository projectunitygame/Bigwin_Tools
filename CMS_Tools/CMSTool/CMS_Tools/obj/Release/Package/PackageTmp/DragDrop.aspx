<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DragDrop.aspx.cs" Inherits="CMS_Tools.DragDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div id="div1" class="col-md-4" style="border:solid 1px;background-color:gainsboro;">
         <span>Col1</span><br /><br />
      </div>
      <div id="div2" class="col-md-4" style="border:solid 1px;background-color:grey;">
         <span>
            Col2
         </span>
         <br /><br />
      </div>
      <div id="div3" class="col-md-4" style="border:solid 1px;background-color:gainsboro;">
         <span>
            Col3
         </span>
         <br /><br />
      </div>

      <script>
          $("#div1").draggable({ snap: true });
          $("#div2").draggable({ snap: true });
         $("#div3").draggable({snap: true});
      </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
</asp:Content>
