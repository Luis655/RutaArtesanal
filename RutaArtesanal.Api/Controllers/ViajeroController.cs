using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using RutaArtesanal.Infrastructure.Repositories;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;
using RutaArtesanal.Domain.Dtos;
using System.Linq;


namespace RutaArtesanal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeroController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repositorio = new ViajeroSQLRepository();
            var art = repositorio.GetAll();
            var respuesta = art.Select(x =>CreateDTOFromObjects(x));
            
            return Ok(respuesta);
        }


        [HttpGet]
        [Route("Find")]
        public IActionResult GetBuFilter(ViajeroRequest viajero)
        {
            var repositorio = new ViajeroSQLRepository();
            var art = CreateObjctFromDTO(viajero);
            var artesanos = repositorio.GetByFilter(art);
            var respuesta = artesanos.Select(x =>CreateDTOFromObjects(x)
            );
            return Ok(respuesta);
        }


        public Viajero CreateObjctFromDTO(ViajeroRequest dto)
        {
            var viajero = new Viajero{
                Idviajero = dto.Idviajero,
                Nombrebiajero = dto.Nombrebiajero,
                Apellidomat= dto.Apellidomat,
                Apellidopat= dto.Apellidopat,
                Genero = dto.Genero,
                Email = dto.Email,
                Fechanaci = dto.Fechanaci,
                
            };

            return viajero;
        }

        private ViajeroResponse CreateDTOFromObjects(Viajero viajero)
        {
            var dtos = new ViajeroResponse{
                Nombrebiajero = viajero.Nombrebiajero,
                Apellidomat= viajero.Apellidomat,
                Apellidopat= viajero.Apellidopat,
                Genero = viajero.Genero,
                Celular = viajero.Celular,
                Email = viajero.Email,
                Fechanaci = viajero.Fechanaci,
                Lat = viajero.Lat,
                Long = viajero.Long

            };

            return dtos;
        }


         [HttpGet]
        [Route("asociacion{asociaciones}")]
        // Retornar elementos que sean de diferentes asociasiones
        public IActionResult GetDistincJobs(string nombre)
            {
                var repositorio = new ViajeroSQLRepository();
                var artesanos = repositorio.GetAviajeros(nombre);
                
            return Ok(artesanos);
            } 

            
        //valores que contengan


        [HttpGet]
        [Route("word")]

         public IActionResult GetStartWith(string word)
        {
            var repositorio = new ViajeroSQLRepository();
                var viajeros = repositorio.GetStartWith(word);
                
            return Ok(viajeros);
        } 





        

    }
}