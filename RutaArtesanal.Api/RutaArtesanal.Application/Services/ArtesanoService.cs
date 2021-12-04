using System;
using RutaArtesanal.Api.Domain;

namespace QueryApi.Application.Services
{

    public class ArtesanoService
    {
        public static bool ValidationUpdate(Personaartesano personaartesano)
        {
            if(personaartesano.Idartesano<=0)
                return false;
            if(string.IsNullOrEmpty(personaartesano.Nombre))
                return false;
            return true;
        }
    }
}