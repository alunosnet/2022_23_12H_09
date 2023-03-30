using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabalho_Final_MOD_17E.Data;

namespace Trabalho_Final_MOD_17E.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper,
            System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";

            using(var context = new Trabalho_Final_MOD_17EContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT UserID FROM users WHERE email=@p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }

            return iduser;
        }

        public static List<SelectListItem> GetLocalidades()
        {
            var localidades = new List<string> { "Açores", "Aveiro", "Beja", "Braga", "Bragança", "Castelo Branco", "Coimbra", "Évora", "Faro", "Guarda", "Leiria", "Lisboa", "Madeira", "Portalegre", "Porto", "Santarém", "Setúbal", "Viana do Castelo", "Vila Real", "Viseu" };

            var localidadeList = localidades.Select(x => new SelectListItem
            {
                Value = x,
                Text = x
            }).ToList();

            return localidadeList;

        }

        public static string UserName(this HtmlHelper htmlHelper,
            System.Security.Principal.IPrincipal utilizador)
        {
            string userName = "";

            using (var context = new Trabalho_Final_MOD_17EContext())
            {
                var consulta = context.Database.SqlQuery<string>("SELECT nome FROM users WHERE email=@p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    userName = consulta.ToList()[0].ToString();
                }
            }

            return userName;
        }

    }
}