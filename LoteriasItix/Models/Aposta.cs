using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace LoteriasItix.Models
{
    public class Aposta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0), Display(Name = "Número da Aposta")]
        public int JogoId { get; set; }
        [Display (Name ="Número do Sorteio")]
        public int NumeroSorteio { get; set; }
        [Display(Name = "Números")]
        public Jogo Numeros { get; set; }
        public String Data { get; set; }
    }
}