using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Artesano
    {
        public int Idartesano { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Asociacion { get; set; }
        public string Genero { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public DateTime? Statusartesano { get; set; }
    }
}
