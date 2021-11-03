using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            Restaurantes = new HashSet<Restaurante>();
        }

        public int Idmenu { get; set; }
        public string Nombreplatillo { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}
