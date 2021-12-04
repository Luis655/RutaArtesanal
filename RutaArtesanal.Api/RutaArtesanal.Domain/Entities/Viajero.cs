using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.Domain
{
    public partial class Viajero
    {
        public int Idviajero { get; set; }
        public string Username { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
