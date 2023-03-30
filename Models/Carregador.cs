using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Final_MOD_17E.Models
{
    public class Carregador
    {
        [Key]
        [DisplayName("Nº do carregador")]
        public int CarregadorID { get; set; }


        [UIHint("Indique a localidade onde se encontra o carregador")]
        [Required(ErrorMessage = "Tem de indicar a localidade onde se encontra o carregador")]
        public string Localidade { get; set; }


        [UIHint("Indique a empresa do carregador")]
        [Required(ErrorMessage = "Tem de indicar a empresa do carregador")]
        public string Empresa { get; set; }


        [UIHint("Indique se o carregador está a ser utilizado")]
        [DisplayName("Em utilização?")]
        public bool Estado { get; set; } = false;


        [UIHint("Indique quanto custa cada kWh deste carregador")]
        [Required(ErrorMessage = "Tem de indicar o preço por kWh do carregador")]
        [DisplayName("Preço por kWh")]
        public decimal Preco_por_kWh { get; set; }


        [UIHint("Indique a latitude do carregador")]
        [RegularExpression(@"^\d{2}\.\d{7}$",
         ErrorMessage = "Tem de ter a formatação 00.0000000")]
        public string Latitude { get; set; }


        [UIHint("Indique a longitude do carregador")]
        [RegularExpression(@"^\d{2}\.\d{7}$",
         ErrorMessage = "Tem de ter a formatação 00.0000000")]
        public string Longitude { get; set; }
    }
}