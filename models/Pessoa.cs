using System;
using System.ComponentModel.DataAnnotations;

namespace API_QrCode.models
{
    public class Pessoa
    {
        [Key]
        public string PIN { get; set; }
        public int ctgNumero { get; set; }
        public string pesNome { get; set; }
        public string pesRG { get; set; }
        public string pesCPF { get; set; }
        public string pesCelular { get; set; }
        public string pesEmail { get; set; }
        public string pesObservacao { get; set; }
        public string empNumero { get; set; }
        public string dptNumero { get; set; }
        public string pesEmpresa { get; set; }
        public string pesCurso { get; set; }
        public string pesSerie { get; set; }
        public string pesGrau { get; set; }
        public string pesArea { get; set; }
        public string pesDisciplina { get; set; }
        public string pesPlacaVeiculo { get; set; }
        public string pesModeloVeiculo { get; set; }
        public string pesFabricanteVeiculo { get; set; }
        public string pesCorVeiculo { get; set; }
        public Byte? pesVerReconhecimentoFacial { get; set; }
        public Byte? pesHabilitado { get; set; }
        public Byte? pesAutorizante { get; set; }
        public string pesParentesco { get; set; }
        public string PINResponsavel { get; set; }
        public string PINApresentante { get; set; }
        public Int16? ambNumero { get; set; }
        public Int16? grpNumero { get; set; }
        public string pesDataAlteracao { get; set; }
        public string pesDataHoraUltimaPassagem { get; set; }
        public string pesCampoCfg01 { get; set; }
        public string pesCampoCfg02 { get; set; }
        public string pesCampoCfg03 { get; set; }
        public string pesCampoCfg04 { get; set; }
        public string pesCampoCfg05 { get; set; }
        public string pesCampoCfg06 { get; set; }
        public string pesCampoCfg07 { get; set; }
        public string pesCampoCfg08 { get; set; }
        public string pesCampoCfg09 { get; set; }
        public string pesCampoCfg10 { get; set; }
        public Byte? pesArmazenaDados { get; set; }
        public string pesCodigoExterno { get; set; }
        public int? pesAceite { get; set; }
        public string pesDataCadastro { get; set; }
        public string oprNome { get; set; }

    }
}
