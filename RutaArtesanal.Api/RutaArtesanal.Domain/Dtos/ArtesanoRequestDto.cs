using System;
using System.Collections.Generic;

namespace RutaArtesanal.Domain.Dtos

{
    public class ArtesanoRequestDto
    {
     
        public int Idartesano { get; set; }
        public string Nombre { get; set; }
        public string Asociacion { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
    }

    
}