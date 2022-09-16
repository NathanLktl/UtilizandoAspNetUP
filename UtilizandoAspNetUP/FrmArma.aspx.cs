using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizandoAspNetUP
{
    public partial class FrmArma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularDdls();
            }
        }

        private void PopularDdls()
        {
            using (var ctx = new BetaGameDBEntities())
            {
                var categorias = ctx.Categorias.ToList();
                var municoes = ctx.TiposMunicoes.ToList();
                PopularDdlCategoria(categorias);
                PopularDdlTipoMunicao(municoes);
            }            
        }

        private void PopularDdlTipoMunicao(List<TipoMunicao> municoes)
        {
            ddlTipoMunicao.DataSource = 
                municoes.OrderBy(x => x.DescricaoTipoMunicao);
            ddlTipoMunicao.DataTextField = "DescricaoTipoMunicao";
            ddlTipoMunicao.DataValueField = "IdTipoMunicao";
            ddlTipoMunicao.DataBind();

            ddlTipoMunicao.Items.Insert(0, "Selecione..");
                
        }

        private void PopularDdlCategoria(List<Categoria> categorias)
        {
            ddlCategoria.DataSource =
               categorias.OrderBy(x => x.DescricaoCategoria);
            ddlCategoria.DataTextField = "DescricaoCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, "Selecione..");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Arma arma = new Arma();
            //Preencher as informações da arma
            var alcance = txtAlcance.Text;
            if(alcance != "") 
                arma.Alcance = Convert.ToDecimal(alcance);

            arma.ArmaDescricao = txtDescricao.Text;
            arma.Dano = Convert.ToDecimal(txtDano.Text);
            arma.Durabilidade = Convert.ToDecimal(txtDurabilidade.Text);
            var peso = txtPeso.Text;
            if (peso != "") 
                arma.Peso = Convert.ToDecimal(peso);

            arma.Precisao = Convert.ToDecimal(txtPrecisao.Text);
            var qtdeMunicao = txtQtdeMunicao.Text;
            if (qtdeMunicao != "")
                arma.QtdeMunicao = Convert.ToInt32(qtdeMunicao);

            //Selecionando a categoria
            var idx = ddlCategoria.SelectedIndex;
            if (idx > 0 )
            {
                //Significa que foi selecionada uma categoria
                var id = Convert.ToInt32(ddlCategoria.SelectedValue);
                arma.CategoriaID = id;
            }

            //Selecionando a Tipo Munição
            idx = ddlTipoMunicao.SelectedIndex;
            if (idx > 0)
            {
                //Significa que foi selecionada um tipo de munição
                var id = Convert.ToInt32(ddlTipoMunicao.SelectedValue);
                arma.TipoMunicaoID = id;
            }

            ArmaDAO.CadastrarArma(arma);

        }
    }
}