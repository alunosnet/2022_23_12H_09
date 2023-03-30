using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trabalho_Final_MOD_17E.Models
{
    public class Carregamento
    {
        [Key]
        public int CarregamentoID { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Tem de indicar a data em que o carregamento foi feito")]
        [Display(Name = "Data do carregamento")]
        public DateTime data_carregamento { get; set; }


        [ForeignKey("user")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Tem de indicar um cliente")]
        public int UtilizadorID { get; set; }
        public User user { get; set; }


        [ForeignKey("carregador")]
        [Display(Name = "Carregador")]
        [Required(ErrorMessage = "Tem de indicar um carregador")]
        public int CarregadorID { get; set; }
        public Carregador carregador { get; set; }


        [Display(Name = "kWh carregados")]
        [Required(ErrorMessage = "Tem de indicar quantos kWh foram carregados")]
        public decimal kWh { get; set; }


        [DataType(DataType.Currency)]
        [Display(Name = "Valor pago")]
        public decimal preco_total { get; set; }
    }
}