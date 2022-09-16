<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArma.aspx.cs" Inherits="UtilizandoAspNetUP.FrmArma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gerenciamento de armas</title>
    <link href="css/estilos.css" rel="stylesheet" />
</head>

<body>
    <nav>
        <a href="~/" runat="server">início</a>
        <a href="~/FrmCategoria.aspx" runat="server">Categoria</a>
        <a href="~/FrmArma.aspx" runat="server">Arma</a>
        <a href="~/FrmTipoMunicao.aspx" runat="server">Tipo de munição</a>
    </nav>

    <h1>Gerenciamento de Armas</h1>

    <form id="form1" runat="server">
        <div>
            <p>
                <label>Descrição da arma:</label>
                <asp:TextBox runat="server" id="txtDescricao"/>
            </p>
            <p>
                <label>Categoria:</label>
                <asp:DropDownList runat="server" ID="ddlCategoria">
                </asp:DropDownList>
            </p>
            <p>
                <label>Dano:</label>
                <asp:TextBox runat="server" id="txtDano" TextMode="Number" />
            </p>
            <p>
                <label>Durabilidade:</label>
                <asp:TextBox runat="server" id="txtDurabilidade" TextMode="Number" />
            </p>
            <p>
                <label>Precisão:</label>
                <asp:TextBox runat="server" id="txtPrecisao" TextMode="Number" />
            </p>
            <p>
                <label>Peso:</label>
                <asp:TextBox runat="server" id="txtPeso" TextMode="Number" />
            </p>
            <p>
                <label>Alcance:</label>
                <asp:TextBox runat="server" id="txtAlcance" TextMode="Number" />
            </p>
            <p>
                <label>Tipo de Munição:</label>
                <asp:DropDownList runat="server" ID="ddlTipoMunicao">                    
                </asp:DropDownList>
            </p>
            <p>
                <label>Quantidade de Munição:</label>
                <asp:TextBox runat="server" id="txtQtdeMunicao" TextMode="Number" />
            </p>
            <p>
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </p>
        </div>
    </form>
</body>
</html>
