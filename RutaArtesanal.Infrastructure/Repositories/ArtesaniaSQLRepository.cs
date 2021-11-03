using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;
using System.Collections.Generic;
using RutaArtesanal.Infrastructure.Context;
using RutaArtesanal.Domain.Dtos;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RutaArtesanal.Infrastructure.Repositories
{
    public class ArtesaniasSQLRepository
    {
        

        private readonly RutaArtesanalContext _context;

        public ArtesaniasSQLRepository()
        {
         _context = new RutaArtesanalContext();
        }



         public IEnumerable<Artesanium> GetAll()
        {
            var query = _context.Artesania.Select(artesanos => artesanos);
            return query;
        }


         public Artesanium GetById(int id)
        {
            var query = _context.Artesania.FirstOrDefault(artesano => artesano.Idartesania ==id);
            return query;
        }


        public IEnumerable<Artesanium> GetByFilter(Artesanium artesanium)
        {
            var query = _context.Artesania.Select(x=>x);

            if (!string.IsNullOrEmpty(artesanium.Nombreartesania))
            {
                query = query.Where(x=>x.Nombreartesania.Contains(artesanium.Nombreartesania));
            }


            if (artesanium.Idartesania>0)
            {
                query = query.Where(x=>x.Idartesania==artesanium.Idartesania);
            }


            if (!string.IsNullOrEmpty(artesanium.Material))
            {
                query = query.Where(x=>x.Material.Contains(artesanium.Material));
            }


           


            return query;

            
        }




        // Retornar elementos que sean de diferentes Materiales
           public IEnumerable<string> GetMateriales(string Material)
        {
           var  query = _context.Artesania.Select(Person=>Person.Material).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Artesanium> GetStartWith(string word)
        {
           
            var query = _context.Artesania.Where(p=>p.Descripcion.StartsWith(word));
            return query;
        }






    }
}