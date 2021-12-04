using System.Collections;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RutaArtesanal.Api.Domain;
using System.Collections.Generic;
using RutaArtesanal.Api.Domain.Context;
using RutaArtesanal.Domain.Dtos;
using Microsoft.EntityFrameworkCore.Metadata;
using QueryApi.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;

#nullable disable

namespace RutaArtesanal.Infrastructure.Repositories
{
    public class ArtesanosSQLRepository : IArtesanoRepository
    {
        

        private readonly RUTAARTESANALAPIContext _context;

        public ArtesanosSQLRepository(RUTAARTESANALAPIContext context)
        {
        this._context = context;
        }



         public async Task<IQueryable<Personaartesano>> GetAll()
        {
            var query = await _context.Personaartesanos.Include(x => x.IdasociacionNavigation).Include(x => x.IdloginNavigation).Include(x=> x.IdtallerNavigation).AsQueryable<Personaartesano>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


         public async Task<Personaartesano> GetById(int id)
        {
            var query = await _context.Personaartesanos.Include(x => x.IdasociacionNavigation).Include(x => x.IdloginNavigation).Include(x=> x.IdtallerNavigation).FirstOrDefaultAsync(x => x.Idartesano ==id);

            return query;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            
            entity.IdloginNavigation = new Usuario();
            entity.IdloginNavigation.Statu = "0";

            _context.Update(entity);


            var rows =await _context.SaveChangesAsync();

            return rows >0;
        }



        public async Task<IQueryable<Personaartesano>> GetByFilter(Personaartesano artesano)
        {

            if (artesano == null)
                return new List<Personaartesano>().AsQueryable();
                
        
            var query = _context.Personaartesanos.Select(x=>x);

            if (!string.IsNullOrEmpty(artesano.Nombre))
            {
                query = query.Where(x=>x.Nombre.Contains(artesano.Nombre));
            }


            if (artesano.Idartesano>0)
            {
                query = query.Where(x=>x.Idartesano==artesano.Idartesano);
            }


            if (!string.IsNullOrEmpty(artesano.IdasociacionNavigation.Nombreasociacion))
            {
                query = query.Where(x=>x.IdasociacionNavigation.Nombreasociacion.Contains(artesano.IdasociacionNavigation.Nombreasociacion));
            }


            if (artesano.IdloginNavigation.Correo !=null)
            {
                query = query.Where(x=>x.IdloginNavigation.Correo ==artesano.IdloginNavigation.Correo);
            }

            var result = await query.ToListAsync();
            return result.AsQueryable().AsNoTracking();

        }
        



     
        // Retornar elementos que sean de diferentes asociasiones
           public IEnumerable<string> GetAsociations(string asociation)
        {
           var  query = _context.Personaartesanos.Select(Person=>Person.IdasociacionNavigation.Nombreasociacion).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Personaartesano> GetStartWith(string word)
        {
           
            var query = _context.Personaartesanos.Where(p=>p.IdasociacionNavigation.Nombreasociacion.StartsWith(word));
            return query;
        }


        public async Task<int> Create(Personaartesano personaartesano)
        {
           var entity = personaartesano;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            
            return entity.Idartesano;
        }



         public async Task<bool> Update(int id, Personaartesano personaartesano)
        {
            if(id<= 0 || personaartesano==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");


            var entity = await GetById(id);

            entity.Nombre = personaartesano.Nombre;
            entity.Apellidop = personaartesano.Apellidop;
            entity.Apellidom = personaartesano.Apellidom;
            /*entity.IdasociacionNavigation.Nombreasociacion = personaartesano.IdasociacionNavigation.Nombreasociacion;
            entity.IdloginNavigation.Statu = personaartesano.IdloginNavigation.Statu;
            entity.IdtallerNavigation.Nombretaller = personaartesano.IdtallerNavigation.Nombretaller;
            entity.IdtallerNavigation.Telefonocontacto= personaartesano.IdtallerNavigation.Telefonocontacto;
            entity.IdtallerNavigation.Emailcontacto= personaartesano.IdtallerNavigation.Emailcontacto;
            entity.IdtallerNavigation.Redessociales=personaartesano.IdtallerNavigation.Redessociales;
            entity.IdtallerNavigation.Latitud=personaartesano.IdtallerNavigation.Latitud;
            entity.IdtallerNavigation.Longitud=personaartesano.IdtallerNavigation.Longitud;*/
           //entity.idna = new Asociacion();
           
            //entidad.Nombreasociacion = personaartesano.IdasociacionNavigation.Nombreasociacion;
            
            
            /*
            if(personaartesano.IdloginNavigation !=null)
            {
                if(entity.IdloginNavigation==null)
                    entity.IdloginNavigation = new Usuario();
                
                  entity.IdloginNavigation.Correo = personaartesano.IdloginNavigation.Correo;
                  entity.IdloginNavigation.Contraseña = personaartesano.IdloginNavigation.Contraseña;
            }
            

            

             if(personaartesano.IdtallerNavigation !=null)
            {
                if(entity.IdtallerNavigation==null)
                    entity.IdtallerNavigation = new Taller();
                
                  entity.IdtallerNavigation.Nombretaller = personaartesano.IdtallerNavigation.Nombretaller;
                  entity.IdtallerNavigation.Logodeltaller = personaartesano.IdtallerNavigation.Logodeltaller;
                  entity.IdtallerNavigation.Telefonocontacto = personaartesano.IdtallerNavigation.Telefonocontacto;
                  entity.IdtallerNavigation.Emailcontacto = personaartesano.IdtallerNavigation.Emailcontacto;
                  entity.IdtallerNavigation.Redessociales = personaartesano.IdtallerNavigation.Redessociales;
                  entity.IdtallerNavigation.Latitud = personaartesano.IdtallerNavigation.Latitud;
                  entity.IdtallerNavigation.Longitud = personaartesano.IdtallerNavigation.Longitud;
            }*/
            

            

            

            _context.Update(entity);


            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }

         public bool Exist(Expression<Func<Personaartesano, bool>> expression)
        {
            return _context.Personaartesanos.Any(expression);
        }



    }
}

