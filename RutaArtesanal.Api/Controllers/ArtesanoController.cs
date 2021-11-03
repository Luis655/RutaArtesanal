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
    public class ArtesanoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repositorio = new ArtesanosSQLRepository();
            var art = repositorio.GetAll();
            var respuesta = art.Select(x =>CreateDTOFromObjects(x));
            
            return Ok(respuesta);
        }


        [HttpGet]
        [Route("Find")]
        public IActionResult GetBuFilter(ArtesanoRequest artesano)
        {
            var repositorio = new ArtesanosSQLRepository();
            var art = CreateObjctFromDTO(artesano);
            var artesanos = repositorio.GetByFilter(art);
            var respuesta = artesanos.Select(x =>CreateDTOFromObjects(x)
            );
            return Ok(respuesta);
        }


        public Artesano CreateObjctFromDTO(ArtesanoRequest dto)
        {
            var artesano = new Artesano{
                Idartesano = dto.Idartesano,
                Nombre = dto.Nombre,
                Apellidop= string.Empty,
                Apellidom= string.Empty,
                Asociacion= dto.Asociacion,
                Genero = dto.Genero,
                Celular= string.Empty,
                Email = dto.Email,
                Contraseña = string.Empty,
                Fechanacimiento = null,
                Statusartesano = null
            };

            return artesano;
        }

        private ArtesanoResponse CreateDTOFromObjects(Artesano artesanos)
        {
            var dtos = new ArtesanoResponse{
                Nombre = $"{artesanos.Nombre} {artesanos.Apellidop} {artesanos.Apellidom}",
                Asociacion = artesanos.Asociacion,
                Genero = artesanos.Genero,
                Celular = artesanos.Celular,
                Email = artesanos.Email,
                Fechanacimiento = artesanos.Fechanacimiento

            };

            return dtos;
        }


         [HttpGet]
        [Route("asociacion{asociaciones}")]
        // Retornar elementos que sean de diferentes asociasiones
        public IActionResult GetDistincJobs(string asociation)
            {
                var repositorio = new ArtesanosSQLRepository();
                var artesanos = repositorio.GetAsociations(asociation);
                
            return Ok(artesanos);
            } 

            
        //valores que contengan


        [HttpGet]
        [Route("word")]

         public IActionResult GetStartWith(string word)
        {
            var repositorio = new ArtesanosSQLRepository();
                var artesanos = repositorio.GetStartWith(word);
                
            return Ok(artesanos);
        } 





        

    }
}