using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QrCode.models
{
    public class Identificador
    {
        [Key]
        public string ideNumInterno { get; set; }
        public int ideNumExterno { get; set; }

        public Byte? ideTipo { get; set; }

        public Byte? ideCategoria { get; set; }

        public Byte? ideHabilitado { get; set; }

        public string ideValidade { get; set; }

        [ForeignKey("Pessoa")]
        public string PIN { get; set; }
        public Pessoa Pessoa { get; set; }
        public Byte? ideSituacao { get; set; }

        public string DataHoraAssociacao { get; set; }

    }
}
