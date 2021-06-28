using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webApi.Domains
{
    public partial class SituacaoConsulta
    {
        public SituacaoConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
