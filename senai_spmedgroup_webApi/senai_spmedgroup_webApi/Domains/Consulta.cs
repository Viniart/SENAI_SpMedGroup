using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }
        [Required(ErrorMessage = "Deve ser definida uma data para uma consulta!")]
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual SituacaoConsulta IdSituacaoNavigation { get; set; }
    }
}
