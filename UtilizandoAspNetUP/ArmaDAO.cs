using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilizandoAspNetUP
{
    public class ArmaDAO
    {
        internal static void CadastrarArma(Arma arma)
        {
            try
            {
                using (var ctx = new BetaGameDBEntities())
                {
                    ctx.Armas.Add(arma);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {               
            }
        }
    }
}