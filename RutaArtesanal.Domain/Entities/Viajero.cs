using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Viajero
    {
        public int Idviajero { get; set; }
        public string Nombrebiajero { get; set; }
        public string Apellidopat { get; set; }
        public string Apellidomat { get; set; }
        public string Genero { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contraseñaviajero { get; set; }
        public DateTime? Fechanaci { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
