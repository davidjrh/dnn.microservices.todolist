<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="TodoList.View" %>
<script type="text/javascript" >
    $(document).ready(function () {
        var todoListMgr = new dnnservices.TodoListManager({
            container: $("#<% = Parent.ClientID %>")[0],
            loaddependencies: true
        });
        todoListMgr.init();
    });
</script>