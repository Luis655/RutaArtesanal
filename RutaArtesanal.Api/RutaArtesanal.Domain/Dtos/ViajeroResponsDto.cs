using System;
using System.Collections.Generic;

namespace RutaArtesanal.Domain.Dtos

{
    public class ViajeroResponseDto
    {
     
        public string Nombrebiajero { get; set; }
        public string Apellidopat { get; set; }
        public string Apellidomat { get; set; }
        public string Genero { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime? Fechanaci { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
        
    
}