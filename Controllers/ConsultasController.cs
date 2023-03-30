using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabalho_Final_MOD_17E.Data;

namespace Trabalho_Final_MOD_17E.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();
        // GET: Consultas
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [Authorize(Roles = "Administrador")]
        public ActionResult PesquisaUtilizador()
        {
            int pesquisa;
            string nome = Request.Form["nome"];

            int.TryParse(Request.Form["pesquisa"], out pesquisa);
            var utilizadores = db.Users.Where(u => false);
            switch (pesquisa)
            {
                case 1:
                    utilizadores = db.Users.Where(u => u.nome.Contains(nome));
                    break;

                case 2:
                    utilizadores = db.Users.Where(u => u.email.Contains(nome));
                    break;

                case 3:
                    int num;
                    if (!int.TryParse(nome, out num))
                    {
                        if ("Utilizador".Contains(nome))
                            num = 1;
                        if ("Administrador".Contains(nome))
                            num = 0;
                    }
                    utilizadores = db.Users.Where(u => u.perfil == num);
                    break;
            }


            return View("PesquisaUtilizador", utilizadores.ToList());
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult PesquisaDinamica()
        {
            return View();
        }

        public ActionResult PesquisaCarregadores()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult PesquisaCarregamentos()
        {
            return View();
        }

        public JsonResult PesquisaNome(string nome, string p)
        {
            int pesquisa;

            int.TryParse(p, out pesquisa);
            var utilizadores = db.Users.Where(u => false).ToList();
            switch (pesquisa)
            {
                case 1:
                    utilizadores = db.Users.Where(u => u.nome.Contains(nome)).ToList();
                    break;

                case 2:
                    utilizadores = db.Users.Where(u => u.email.Contains(nome)).ToList();
                    break;

                case 3:
                    if (nome != "")
                    {
                        int num = -1;

                        if (nome == "1" || "utilizador".Contains(nome.ToLower()))
                            num = 1;
                        else if (nome == "0" || "administrador".Contains(nome.ToLower()))
                            num = 0;

                        utilizadores = db.Users.Where(u => u.perfil == num).ToList();
                    }


                    if (nome == "")
                    {
                        utilizadores = db.Users.ToList();
                    }
                    break;
            }
            //var utilizadores = db.Users.Where(c => c.nome.Contains(nome)).ToList();
            var lista = new List<Campos>();
            foreach (var c in utilizadores)
            {
                lista.Add(new Campos() {userID = c.UserID, nome = c.nome, email = c.email });
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MelhorUtilizador()
        {
            using (var context = new Trabalho_Final_MOD_17EContext())
            {
                string sql = @"SELECT nome, email, SUM(preco_total) AS valor
                            FROM carregamentoes INNER JOIN users
                            ON carregamentoes.UtilizadorID=users.UserID
                            GROUP BY nome, email
                            ORDER BY valor DESC";

                var melhor = context.Database.SqlQuery<Campos>(sql);
                if (melhor != null && melhor.ToList().Count > 0)
                    ViewBag.melhor = melhor.ToList()[0];
                else
                    ViewBag.melhor = null;
            }
            return View();
        }



        public JsonResult PesquisaCarregador(string nome, string p)
        {
            int pesquisa;

            int.TryParse(p, out pesquisa);
            var carregadores = db.Carregadors.Where(u => false).ToList();
            switch (pesquisa)
            {
                case 1:
                    carregadores = db.Carregadors.Where(u => u.Localidade.Contains(nome)).ToList();
                    break;

                case 2:
                    carregadores = db.Carregadors.Where(u => u.Empresa.Contains(nome)).ToList();
                    break;

                case 3:
                    if (nome != "")
                    {
                        decimal num = (decimal)0.00;
                        if (int.TryParse(nome, out int intValue))
                        {
                            num = (decimal)intValue;
                        }
                        else if (decimal.TryParse(nome, out decimal decimalValue))
                        {
                            num = decimalValue;
                        }

                        carregadores = db.Carregadors.Where(u => u.Preco_por_kWh == num).ToList();
                    }


                    if (nome == "")
                    {
                        carregadores = db.Carregadors.ToList();
                    }
                    break;
            }
            //var utilizadores = db.Users.Where(c => c.nome.Contains(nome)).ToList();
            var lista = new List<CamposCarregador>();
            foreach (var c in carregadores)
            {
                lista.Add(new CamposCarregador() { CarregadorID = c.CarregadorID, Localidade = c.Localidade, Empresa = c.Empresa, Estado = c.Estado, Preco_por_kWh = c.Preco_por_kWh, Latitude = c.Latitude, Longitude=c.Longitude });
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }



        [Authorize(Roles = "Administrador")]
        public JsonResult PesquisaCarregamento(string nome, string p)
        {
            int pesquisa;

            int.TryParse(p, out pesquisa);
            var Carregamentos = db.Carregamentos.Where(u => false).ToList();
            switch (pesquisa)
            {
                case 1:
                    if (nome != "")
                    {
                        int num;
                        int.TryParse(nome, out num);
                        Carregamentos = db.Carregamentos.Where(u => u.CarregamentoID == num).ToList();
                    }

                    if (nome == "")
                    {
                        Carregamentos = db.Carregamentos.ToList();
                    }
                    break;

                case 2:
                    if (nome != "")
                    {
                        int num;
                        int.TryParse(nome, out num);
                        Carregamentos = db.Carregamentos.Where(u => u.UtilizadorID == num).ToList();
                    }

                    if (nome == "")
                    {
                        Carregamentos = db.Carregamentos.ToList();
                    }
                    break;

                case 3:
                    if (nome != "")
                    {
                        int num;
                        int.TryParse(nome, out num);
                        Carregamentos = db.Carregamentos.Where(u => u.CarregadorID == num).ToList();
                    }

                    if (nome == "")
                    {
                        Carregamentos = db.Carregamentos.ToList();
                    }
                    break;

                case 4:
                    if (nome != "")
                    {
                        decimal num = (decimal)0.00;
                        if (int.TryParse(nome, out int intValue))
                        {
                            num = (decimal)intValue;
                        }
                        else if (decimal.TryParse(nome, out decimal decimalValue))
                        {
                            num = decimalValue;
                        }

                        Carregamentos = db.Carregamentos.Where(u => u.preco_total == num).ToList();
                    }


                    if (nome == "")
                    {
                        Carregamentos = db.Carregamentos.ToList();
                    }
                    break;
            }
            //var utilizadores = db.Users.Where(c => c.nome.Contains(nome)).ToList();
            var lista = new List<CamposCarregamento>();
            foreach (var c in Carregamentos)
            {
                lista.Add(new CamposCarregamento() { CarregamentoID = c.CarregamentoID, CarregadorID = c.CarregadorID, UtilizadorID=c.UtilizadorID, preco_total=c.preco_total});
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public class Campos
        {
            public int userID { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public decimal valor { get; set; }
        }

        public class CamposCarregador
        {
            public int CarregadorID { get; set; }
            public string Localidade { get; set; }
            public string Empresa { get; set; }
            public bool Estado { get; set; }
            public decimal Preco_por_kWh { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }

        public class CamposCarregamento
        {
            public int CarregamentoID { get; set; }
            public int UtilizadorID { get; set; }
			public int CarregadorID {get; set; }
            public decimal preco_total { get; set; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}