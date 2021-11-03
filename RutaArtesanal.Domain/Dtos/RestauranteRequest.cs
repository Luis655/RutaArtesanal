using System;
using System.Collections.Generic;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;



namespace RutaArtesanal.Domain.Dtos
{
    public class RestauranteRequest
    {
        public int Idrestaurante { get; set; }
        public string Nombrerestaurante { get; set; }
        public int? Menurestaurante { get; set; }

        public virtual Menu MenurestauranteNavigation { get; set; }
        
    }
}