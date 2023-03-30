using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final_MOD_17E.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nome do utilizador")]
        [StringLength(50)]
        [MinLength(2, ErrorMessage ="nome é muito pequeno")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Palavra passe")]
        public string password { get; set; }

        [Required(ErrorMessage = "Indique o perfil do utilizador")]
        public int perfil { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> perfis { get; set; }

        public virtual List<Carregamento> listaCarregamentos { get; set; }
    }
}