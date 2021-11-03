using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Taller
    {
        public int Idtaller { get; set; }
        public int? Datosartesano { get; set; }
        public string Nombretaller { get; set; }
        public string Telefono { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual Artesano DatosartesanoNavigation { get; set; }
    }
}
