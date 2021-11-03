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
    public class ViajeroSQLRepository
    {
        

        private readonly RutaArtesanalContext _context;

        public ViajeroSQLRepository()
        {
         _context = new RutaArtesanalContext();
        }



         public IEnumerable<Viajero> GetAll()
        {
            var query = _context.Viajeros.Select(Viajero => Viajero);
            return query;
        }


         public Viajero GetById(int id)
        {
            var query = _context.Viajeros.FirstOrDefault(artesano => artesano.Idviajero ==id);
            return query;
        }


        public IEnumerable<Viajero> GetByFilter(Viajero viajero)
        {
            var query = _context.Viajeros.Select(x=>x);

            if (!string.IsNullOrEmpty(viajero.Nombrebiajero))
            {
                query = query.Where(x=>x.Nombrebiajero.Contains(viajero.Nombrebiajero));
            }


            if (viajero.Idviajero>0)
            {
                query = query.Where(x=>x.Idviajero==viajero.Idviajero);
            }


            if (!string.IsNullOrEmpty(viajero.Email))
            {
                query = query.Where(x=>x.Email.Contains(viajero.Email));
            }


            if (viajero.Genero!=null)
            {
                query = query.Where(x=>x.Genero ==viajero.Genero);
            }


            if (viajero.Fechanaci!=null)
            {
                query = query.Where(x=>x.Fechanaci ==viajero.Fechanaci);
            }


            return query;

            
        }




        // Retornar elementos que sean de diferentes nombres
           public IEnumerable<string> GetAviajeros(string nombre)
        {
           var  query = _context.Viajeros.Select(Person=>Person.Nombrebiajero).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Viajero> GetStartWith(string word)
        {
           
            var query = _context.Viajeros.Where(p=>p.Celular.StartsWith(word));
            return query;
        }






    }
}