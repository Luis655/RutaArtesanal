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
    public class ArtesanosSQLRepository
    {
        

        private readonly RutaArtesanalContext _context;

        public ArtesanosSQLRepository()
        {
         _context = new RutaArtesanalContext();
        }



         public IEnumerable<Artesano> GetAll()
        {
            var query = _context.Artesanos.Select(artesanos => artesanos);
            return query;
        }


         public Artesano GetById(int id)
        {
            var query = _context.Artesanos.FirstOrDefault(artesano => artesano.Idartesano ==id);
            return query;
        }


        public IEnumerable<Artesano> GetByFilter(Artesano artesano)
        {
            var query = _context.Artesanos.Select(x=>x);

            if (!string.IsNullOrEmpty(artesano.Nombre))
            {
                query = query.Where(x=>x.Nombre.Contains(artesano.Nombre));
            }


            if (artesano.Idartesano>0)
            {
                query = query.Where(x=>x.Idartesano==artesano.Idartesano);
            }


            if (!string.IsNullOrEmpty(artesano.Asociacion))
            {
                query = query.Where(x=>x.Asociacion.Contains(artesano.Asociacion));
            }


            if (artesano.Genero!=null)
            {
                query = query.Where(x=>x.Genero ==artesano.Genero);
            }


            if (artesano.Email!=null)
            {
                query = query.Where(x=>x.Email ==artesano.Email);
            }


            return query;

            
        }




        // Retornar elementos que sean de diferentes asociasiones
           public IEnumerable<string> GetAsociations(string asociation)
        {
           var  query = _context.Artesanos.Select(Person=>Person.Asociacion).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Artesano> GetStartWith(string word)
        {
           
            var query = _context.Artesanos.Where(p=>p.Asociacion.StartsWith(word));
            return query;
        }






    }
}