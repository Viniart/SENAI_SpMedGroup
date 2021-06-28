using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTiposUsuario { get; set; }
        [Required(ErrorMessage = "É obrigatório definir uma senha!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "É obrigatório definir um email!")]
        public string Email { get; set; }

        public virtual TiposUsuario IdTiposUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
