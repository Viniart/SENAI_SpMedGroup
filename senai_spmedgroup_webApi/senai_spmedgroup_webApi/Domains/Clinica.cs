using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }
        public int IdClinica { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o CNPJ!")]
        [RegularExpression(@"[0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2}")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o Nome Fantasia!")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a Razão Social!")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o Endereço!")]
        public string Endereco { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
