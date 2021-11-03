using System;
using System.Collections.Generic;

namespace RutaArtesanal.Domain.Dtos

{
    public class ViajeroRequest
    {
     
        public int Idviajero { get; set; }
        public string Nombrebiajero { get; set; }
        public string Apellidopat { get; set; }
        public string Apellidomat { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public DateTime? Fechanaci { get; set; }
       
    }
        
    
}