<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmTipoMunicao.aspx.cs" Inherits="UtilizandoAspNetUP.FrmTipoMunicao" %>

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

    <h1 id="h1Titulo" runat="server">Gerenciamento de Tipos de Munição</h1>

    <form id="form1" runat="server">
        <div>
            <p>
                <asp:TextBox runat="server"
                    ID="txtTipo" />

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


        <h3>Categorias Tipos de Munição</h3>
        <p>
            <table border="1">
                <thead>
                    <tr>
                        <td>Código</td>
                        <td>Descrição</td>
                        <td colspan="3">Ações</td>
                    </tr>
                </thead>
                <asp:ListView runat="server" ID="lvTipo">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("IdTipoMunicao") %>
                            </td>
                            <td>
                                <%# Eval("DescricaoTipoMunicao") %>
                            </td>

                            <td>
                                <a href='<%# "~/FrmTipoMunicao.aspx?view=1&id=" + Eval("IdTipoMunicao") %>'
                                    runat="server">
                                    <img src="imagens/view-details.png" style="max-width: 20px;"  />
                                </a>
                            </td>


                            <td>
                                <a href='<%# "~/FrmTipoMunicao.aspx?id=" + Eval("IdTipoMunicao") %>'
                                    runat="server">
                                    <img src="imagens/edit.png" style="max-width: 20px;" />
                                </a>
                            </td>
                            <td>
                                <asp:ImageButton
                                    ID="btnExcluir"
                                    ImageUrl="imagens/delete.jpg"
                                    Style="max-width: 20px;"
                                    runat="server"
                                    OnCommand="btnExcluir_Command"
                                    CommandArgument='<%# Eval("IdTipoMunicao") %>'
                                    CommandName="Excluir"
                                    OnClientClick="return confirm('Deseja realmente excluir o tipo selecionado?')"
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
