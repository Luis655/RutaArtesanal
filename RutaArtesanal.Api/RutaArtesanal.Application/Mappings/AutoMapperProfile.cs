using System.Runtime.InteropServices;
using System;
using AutoMapper;
using QueryApi.Domain.Dtos.Response;
using QueryApi.Domain.Dtos.Requests;
using RutaArtesanal.Domain.Dtos;
using RutaArtesanal.Api.Domain;
using System.Reflection.Metadata.Ecma335;

namespace QueryApi.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personaartesano, ArtesanoResponse>()
            .ForMember(dest=> dest.Nombrecompleto, opt=> opt.MapFrom(src=> $"{src.Nombre} {src.Apellidop} {src.Apellidom}"))
            .ForMember(dest=> dest.Nombreasociacion, opt => opt.MapFrom(src => src.IdasociacionNavigation == null ? "N/A": src.IdasociacionNavigation.Nombreasociacion))
            .ForMember(dest=> dest.Statu, opt => opt.MapFrom(src => src.IdloginNavigation.Statu))
            .ForMember(dest=> dest.Nombretaller, opt => opt.MapFrom(src => src.IdtallerNavigation.Nombretaller))
            .ForMember(dest=> dest.Telefonocontacto, opt  => opt.MapFrom(src => src.IdtallerNavigation.Telefonocontacto))
            .ForMember(dest=> dest.Emailcontacto, opt => opt.MapFrom(src => src.IdtallerNavigation.Emailcontacto))
            .ForMember(dest=> dest.Redessociales, opt => opt.MapFrom(src => src.IdtallerNavigation.Redessociales))
            .ForMember(dest=> dest.Latitud, opt => opt.MapFrom(src => src.IdtallerNavigation.Latitud))
            .ForMember(dest=> dest.Longitud, opt => opt.MapFrom(src => src.IdtallerNavigation.Longitud));
           
            
             CreateMap<ArtesanoCreateRequest, Personaartesano>()
            .ForPath(dest => dest.IdasociacionNavigation.Nombreasociacion, opt => opt.MapFrom(src => src.Nombreasociacion))
            .ForPath(dest => dest.IdloginNavigation.Correo, opt=> opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.IdloginNavigation.Contraseña, opt=> opt.MapFrom(src => src.Contraseña))
            .ForPath(dest => dest.IdloginNavigation.Statu, opt=> opt.MapFrom(src => src.Statu))
            .ForPath(dest => dest.IdtallerNavigation.Nombretaller, opt=> opt.MapFrom(src => src.Nombretaller))
            .ForPath(dest => dest.IdtallerNavigation.Logodeltaller, opt=> opt.MapFrom(src => src.Logodeltaller))
            .ForPath(dest => dest.IdtallerNavigation.Telefonocontacto, opt=> opt.MapFrom(src => src.Telefonocontacto))
            .ForPath(dest => dest.IdtallerNavigation.Emailcontacto, opt=> opt.MapFrom(src => src.Emailcontacto))
            .ForPath(dest => dest.IdtallerNavigation.Redessociales, opt=> opt.MapFrom(src => src.Redessociales))
            .ForPath(dest => dest.IdtallerNavigation.Latitud, opt=> opt.MapFrom(src => src.Latitud))
            .ForPath(dest => dest.IdtallerNavigation.Longitud, opt=> opt.MapFrom(src => src.Longitud));
            
            

            CreateMap<Artesanium, ArtesaniaResponse>()
            
            .ForMember(dest=> dest.Nombrematerial, opt => opt.MapFrom(src => src.IdmaterialNavigation == null ? "N/A": src.IdmaterialNavigation.Nombrematerial))
            .ForMember(dest=> dest.Descripcionmat, opt => opt.MapFrom(src => src.IdmaterialNavigation == null ? "N/A": src.IdmaterialNavigation.Descripcionmat));

            CreateMap<ArtesaniaCreateRequest, Artesanium>()
            .ForPath(dest => dest.IdmaterialNavigation.Nombrematerial, opt => opt.MapFrom(src => src.Nombrematerial))
            .ForPath(dest => dest.IdmaterialNavigation.Descripcionmat, opt=> opt.MapFrom(src => src.Descripcionmat));
           


            
            
        }
    }
}