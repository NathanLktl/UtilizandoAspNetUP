using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizandoAspNetUP
{
    public partial class FrmCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Categoria> lista = CategoriaDAO.ObterCategorias();
                PopularLvCategorias(lista);
            }
            
        }

        private void PopularLvCategorias(List<Categoria> lista)
        {
            lvCategorias.DataSource = lista;
            
            //Renderiza na página html
            lvCategorias.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.DescricaoCategoria = txtCategoria.Text;

                CategoriaDAO.CadastrarCategoria(cat);

                PopularLvCategorias(CategoriaDAO.ObterCategorias());

                lblMensagem.InnerText =
                        "Categoria cadastrada com sucesso!";
                txtCategoria.Text = "";
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText =
                    "Ocorreu um erro ao realizar a operação: " +
                    ex.Message;
            }
        }
    }
}