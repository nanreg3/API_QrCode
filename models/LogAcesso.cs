using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QrCode.models
{
    public class LogAcesso
    {
        [Key]
        public int lacNumero { get; set; }

        [MaxLength(20)]
        [ForeignKey("Pessoas")]
        public string PIN { get; set; }

        [MaxLength(20)]
        public string ideNumInterno { get; set; }

        [MaxLength(20)]
        public string lacData { get; set; }

        [MaxLength(20)]
        public string lacHora { get; set; }
        public Byte? conNumero { get; set; }
        public Byte? estNumero { get; set; }
        public Int16? resNumero { get; set; }
        public Int16? resTipo { get; set; }
        public Int16? ambNumero { get; set; }

    }
}
