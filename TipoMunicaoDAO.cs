using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilizandoAspNetUP
{
    public class TipoMunicaoDAO
    {
        public static void CadastrarTipoMunicao(TipoMunicao tipo)
        {
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    //Equivalente ao insert
                    ctx.TiposMunicoes.Add(tipo);
                    //Executa o camando
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static List<TipoMunicao> ObterTipoMunicao()
        {
            List<TipoMunicao> lista = null;
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    lista = ctx.TiposMunicoes.OrderBy(
                        x => x.DescricaoTipoMunicao).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return lista;
        }

        public static TipoMunicao ObterTipoMunicao(int id)
        {
            TipoMunicao tipo = null;
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    tipo = ctx.TiposMunicoes.FirstOrDefault(
                                tm => tm.IdTipoMunicao == id
                            );
                }
            }
            catch (Exception ex)
            {
            }
            return tipo;
        }

        public static void RemoverTipoMunicao(int id)
        {
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    var tipo = ctx.TiposMunicoes.
                        FirstOrDefault(
                            x => x.IdTipoMunicao == id);

                    ctx.TiposMunicoes.Remove(tipo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               
                
            }
        }

        public static void AlterarTipoMunicao(TipoMunicao tipo)
        {
            using (var ctx = new BetaGameDBEntities())
            {
                var tipoAlterado =
                    ctx.TiposMunicoes.FirstOrDefault(
                            x => x.IdTipoMunicao == tipo.IdTipoMunicao
                        );
                tipoAlterado.DescricaoTipoMunicao = 
                    tipo.DescricaoTipoMunicao;
                ctx.SaveChanges();

            }
        }
    }
}