using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizandoAspNetUP
{
    public partial class FrmTipoMunicao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<TipoMunicao> lista = TipoMunicaoDAO.ObterTipoMunicao();
                PopularLvTipo(lista);
            }

        }

        private void ChecarQueryString()
        {
            var id = Request.QueryString["id"];

            if (id != null)
            {

            
            var view = Request.QueryString["view"];

            if (view != null)
            {
                    var id = Convert.ToInt32(Request.QueryString["id"]);
                    var view = Request.QueryString["view"];

                    //Visualizando os dados
                    if (view != null)
                    {
                        VisualizarTipoMunicao(id);
                    }
                    //Alterando dados
                    else
                    {
                        AlterarTipoMunicao(id);
                    }

                }
            }
        }

        private void AlterarTipoMunicao(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterando Tipo Munição";
        }

        private void PreencherDados(int id)
        {
            throw new NotImplementedException();
        }

        private void VisualizarTipoMunicao(int id)
        {
            TipoMunicao tipo = TipoMunicaoDAO.ObterTipoMunicao(id);
            if (tipo != null)
            {
                txtTipo.Text = tipo.DescricaoTipoMunicao;
                txtTipo.Enabled = false;
                btnCadastrar.Visible = false;
            }
        }

        private void PopularLvTipo(List<TipoMunicao> lista)
        {
            lvTipo.DataSource = lista;

            //Renderiza na página html
            lvTipo.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                TipoMunicao tipo = null;
                if(!alterando)
                {
                    tipo = new TipoMunicao();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    tipo = TipoMunicaoDAO.ObterTipoMunicao(codigo);
                }

                tipo.DescricaoTipoMunicao = txtTipo.Text;

                var mensagem = "";
                if (!alterando)
                {
                    //Se não setiver alterando, iremos cadastrar
                    TipoMunicaoDAO.CadastrarTipoMunicao(tipo);
                    mensagem = "Tipo de munição cadastrado com sucesso";
                }
                else
                {
                    //Se estivermos alterando, chamaremos o método 
                    TipoMunicaoDAO.AlterarTipoMunicao(tipo);
                    mensagem = "Tipo de munição alterado com sucesso";
                    btnCadastrar.Text = "Cadastrar";
                    h1Titulo.InnerText=""
                }
               // TipoMunicaoDAO.CadastrarTipoMunicao(tipo);

                PopularLvTipo(TipoMunicaoDAO.ObterTipoMunicao());

                lblMensagem.InnerText ="Tipo de munição cadastrado com sucesso!";
                txtTipo.Text = "";
                
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText =
                    "Ocorreu um erro ao realizar a operação: " +
                    ex.Message;
            }
        }

        protected void btnExcluir_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                TipoMunicaoDAO.RemoverTipoMunicao(id);
            }

            PopularLvTipo(TipoMunicaoDAO.ObterTipoMunicao());
        }
    }
}