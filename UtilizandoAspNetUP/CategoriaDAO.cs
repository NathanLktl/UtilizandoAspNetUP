using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilizandoAspNetUP
{
    internal class CategoriaDAO
    {
        internal static void CadastrarCategoria(Categoria cat)
        {
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    //Equivalente ao insert
                    ctx.Categorias.Add(cat);
                    //Executa o camando
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static List<Categoria> ObterCategorias()
        {
            List<Categoria> lista = null;
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    lista = ctx.Categorias.OrderBy(
                        x => x.DescricaoCategoria).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return lista;
        }
    }
}