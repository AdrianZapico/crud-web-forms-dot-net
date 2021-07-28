<%@ Page Title="Cadastro de Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="Cadastro.Produto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>

    <br />
    <asp:Label ID="ID" runat="server" Text="ID"></asp:Label>
    <br />
    <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
    <br />
    <asp:TextBox ID="tbnome" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Quantidade"></asp:Label>
    <br />
    <asp:TextBox ID="tbquantidade" runat="server" OnTextChanged="onlyNumbers"></asp:TextBox>
    <br />
    telefone<br />

    <asp:TextBox ID="idtelefone" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <br />
    sexo<br />
    <asp:TextBox ID="idsexo" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="btsave" runat="server" Text="save" OnClick="Salvar" />

  

    <br />

  

    <br />
    <asp:Label ID="idMensagem" runat="server" Text="Label"></asp:Label>

  

    <br />
    <asp:Button ID="idselect" runat="server" OnClick="Button1_Click" Text="BuscarInfo" />
    <br />
    <asp:Button ID="idDelete" runat="server" OnClick="Delete" Text="Excluir" />

  

</asp:Content>
