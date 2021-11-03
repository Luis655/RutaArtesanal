using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Restaurante
    {
        public int Idrestaurante { get; set; }
        public string Nombrerestaurante { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Menurestaurante { get; set; }

        public virtual Menu MenurestauranteNavigation { get; set; }
    }
}
