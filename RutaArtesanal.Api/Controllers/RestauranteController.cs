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
    public class RestauranteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repositorio = new RestauarnteSQLRepository();
            var art = repositorio.GetAll();
            var respuesta = art.Select(x =>CreateDTOFromObjects(x));
            
            return Ok(respuesta);
        }


        [HttpGet]
        [Route("Find")]
        public IActionResult GetBuFilter(RestauranteRequest restaurante)
        {
            var repositorio = new RestauarnteSQLRepository();
            var art = CreateObjctFromDTO(restaurante);
            var artesanos = repositorio.GetByFilter(art);
            var respuesta = artesanos.Select(x =>CreateDTOFromObjects(x)
            );
            return Ok(respuesta);
        }


        public Restaurante CreateObjctFromDTO(RestauranteRequest dto)
        {
            var restaurante = new Restaurante{
                Idrestaurante = dto.Idrestaurante,
                Nombrerestaurante = dto.Nombrerestaurante,
                Menurestaurante= dto.Menurestaurante
            };

            return restaurante;
        }

        private RestauranteRespons CreateDTOFromObjects(Restaurante restaurante)
        {
            var dtos = new RestauranteRespons{
                Nombrerestaurante =restaurante.Nombrerestaurante,
                Latitud = restaurante.Latitud,
                Longitud = restaurante.Longitud
                
                
            };

            return dtos;
        }


         [HttpGet]
        [Route("asociacion{asociaciones}")]
        // Retornar elementos que sean de diferentes asociasiones
        public IActionResult GetDistincJobs(string restaurante)
            {
                var repositorio = new RestauarnteSQLRepository();
                var artesanos = repositorio.GetARestaurantes(restaurante);
                
            return Ok(artesanos);
            } 

            
        //valores que contengan


        [HttpGet]
        [Route("word")]

         public IActionResult GetStartWith(string word)
        {
            var repositorio = new RestauarnteSQLRepository();
                var artesanos = repositorio.GetStartWith(word);
                
            return Ok(artesanos);
        } 





        

    }
}