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
    public class RestauarnteSQLRepository
    {
        

        private readonly RutaArtesanalContext _context;

        public RestauarnteSQLRepository()
        {
         _context = new RutaArtesanalContext();
        }



         public IEnumerable<Restaurante> GetAll()
        {
            var query = _context.Restaurantes.Select(Restaurante => Restaurante);
            return query;
        }


         public Restaurante GetById(int id)
        {
            var query = _context.Restaurantes.FirstOrDefault(Restaurante => Restaurante.Idrestaurante ==id);
            return query;
        }


        public IEnumerable<Restaurante> GetByFilter(Restaurante restaurante)
        {
            var query = _context.Restaurantes.Select(x=>x);

            if (!string.IsNullOrEmpty(restaurante.Nombrerestaurante))
            {
                query = query.Where(x=>x.Nombrerestaurante.Contains(restaurante.Nombrerestaurante));
            }


            if (restaurante.Idrestaurante>0)
            {
                query = query.Where(x=>x.Idrestaurante==restaurante.Idrestaurante);
            }


            if (restaurante.Menurestaurante>0)
            {
                query = query.Where(x=>x.Menurestaurante == restaurante.Menurestaurante);
            }


            return query;

            
        }




        // Retornar elementos que sean de diferentes nombres
           public IEnumerable<string> GetARestaurantes(string nombre)
        {
           var  query = _context.Restaurantes.Select(res=>res.Nombrerestaurante).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Restaurante> GetStartWith(string word)
        {
           
            var query = _context.Restaurantes.Where(p=>p.Nombrerestaurante.StartsWith(word));
            return query;
        }






    }
}