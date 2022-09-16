<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCategoria.aspx.cs" Inherits="UtilizandoAspNetUP.FrmCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <nav>
        <a href="~/" runat="server">início</a>
        <a href="~/FrmCategoria.aspx" runat="server">Categoria</a>
        <a href="~/FrmArma.aspx" runat="server">Arma</a>
        <a href="~/FrmTipoMunicao.aspx" runat="server">Tipo de munição</a>
    </nav>

    <h1>Gerenciamento de Categorias</h1>


    <form id="form1" runat="server">
        <div>
            <p>
                <asp:TextBox runat="server"
                    ID="txtCategoria" />

                <%--<input type="text" runat="server" 
                    id="txtCategoria"/>--%>
            </p>
            <p>
                <asp:Button ID="btnCadastrar"
                    runat="server"
                    Text="Cadastrar"
                    OnClick="btnCadastrar_Click" />
            </p>
            <p>
                <label id="lblMensagem" runat="server">
                </label>
            </p>
        </div>


        <h3>Categorias Cadastradas</h3>
        <p>
            <table border="1">
                <thead>
                    <tr>
                        <td>Código</td>
                        <td>Descrição</td>
                        <td colspan="2">Ações</td>
                    </tr>
                </thead>
                <asp:ListView runat="server" ID="lvCategorias">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("IdCategoria") %>
                            </td>
                            <td>
                                <%# Eval("DescricaoCategoria") %>
                            </td>
                            <td>
                                <a href='<%# "~/FrmCategoria.aspx?id=" + Eval("IdCategoria") %>'
                                    runat="server">
                                    <img src="imagens/edit.png" style="max-width: 20px;" />
                                </a>
                            </td>
                            <td>
                                <asp:ImageButton
                                    ImageUrl="imagens/delete.jpg"
                                    runat="server"
                                    Style="max-width: 20px;"
                                    />

                            </td>
                        </tr>
                    </ItemTemplate>

                    <EmptyItemTemplate>
                        <%--Não existem itens!!--%>
                        <strong>Não existem categorias cadastradas!</strong>
                    </EmptyItemTemplate>
                </asp:ListView>
            </table>
        </p>
    </form>

</body>
</html>
