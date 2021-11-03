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
    public class ArtesaniaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repositorio = new ArtesaniasSQLRepository();
            var art = repositorio.GetAll();
            var respuesta = art.Select(x =>CreateDTOFromObjects(x));
            
            return Ok(respuesta);
        }


        [HttpGet]
        [Route("Findartesania")]
        public IActionResult GetBuFilter(ArtesaniaRequest artesania)
        {
            var repositorio = new ArtesaniasSQLRepository();
            var art = CreateObjctFromDTO(artesania);
            var artesanos = repositorio.GetByFilter(art);
            var respuesta = artesanos.Select(x =>CreateDTOFromObjects(x)
            );
            return Ok(respuesta);
        }


        public Artesanium CreateObjctFromDTO(ArtesaniaRequest dto)
        {
            var artesania = new Artesanium{
                Idartesania = dto.Idartesania,
                Nombreartesania = dto.Nombreartesania,
                Descripcion= string.Empty,
                Material= dto.Material,
                Foto= string.Empty
            };

            return artesania;
        }

        private ArtesaniaResponse CreateDTOFromObjects(Artesanium artesanium)
        {
            var dtos = new ArtesaniaResponse{
                
                Nombreartesania = artesanium.Nombreartesania,
                Descripcion= artesanium.Descripcion,
                Material= artesanium.Material,
                Foto= artesanium.Foto

            };

            return dtos;
        }


         [HttpGet]
        [Route("asociacion{asociaciones}")]
        // Retornar elementos que sean de diferentes asociasiones
        public IActionResult GetDistincJobs(string Material)
            {
                var repositorio = new ArtesaniasSQLRepository();
                var artesanos = repositorio.GetMateriales(Material);
                
            return Ok(artesanos);
            } 

            
        //valores que contengan


        [HttpGet]
        [Route("word")]

         public IActionResult GetStartWith(string word)
        {
            var repositorio = new ArtesaniasSQLRepository();
                var artesanos = repositorio.GetStartWith(word);
                
            return Ok(artesanos);
        } 





        

    }
}