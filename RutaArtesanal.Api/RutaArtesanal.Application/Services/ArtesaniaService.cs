using System;
using RutaArtesanal.Api.Domain;

namespace QueryApi.Application.Services
{

    public class ArtesaniaService
    {
        public static bool ValidationUpdate(Artesanium artesanium)
        {
            if(artesanium.Idartesania<=0)
                return false;
            if(string.IsNullOrEmpty(artesanium.Nombreartesania))
                return false;
            return true;
        }
    }
}