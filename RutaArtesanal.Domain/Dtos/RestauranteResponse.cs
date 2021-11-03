using System;
using System.Collections.Generic;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;



namespace RutaArtesanal.Domain.Dtos
{
    public class RestauranteRespons
    {
       
        public string Nombrerestaurante { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Menurestaurante { get; set; }

        public virtual Menu MenurestauranteNavigation { get; set; }
    }
}