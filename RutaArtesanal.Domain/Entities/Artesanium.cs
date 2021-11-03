using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Artesanium
    {
        public int Idartesania { get; set; }
        public string Nombreartesania { get; set; }
        public string Descripcion { get; set; }
        public string Material { get; set; }
        public string Foto { get; set; }
    }
}
