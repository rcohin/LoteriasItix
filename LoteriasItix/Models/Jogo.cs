using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoteriasItix.Models
{
    public class Jogo
    {
        [Required, Display(Name = "-")]
        public int N1 { get; set; }
        [Required, Display(Name = "-")]
        public int N2 { get; set; }
        [Required, Display(Name = "-")]
        public int N3 { get; set; }
        [Required, Display(Name = "-")]
        public int N4 { get; set; }
        [Required, Display(Name = "-")]
        public int N5 { get; set; }
        [Required, Display(Name = "-")]
        public int N6 { get; set; }
    }
}