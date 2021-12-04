using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.Domain
{
    public partial class Personaartesano
    {
        public int Idartesano { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public int? Idtaller { get; set; }
        public int? Idasociacion { get; set; }
        public int? Idlogin { get; set; }

        public virtual Asociacion IdasociacionNavigation { get; set; }
        public virtual Usuario IdloginNavigation { get; set; }
        public virtual Taller IdtallerNavigation { get; set; }
    }
}
