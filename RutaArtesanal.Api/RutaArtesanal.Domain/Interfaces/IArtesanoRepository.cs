using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RutaArtesanal.Api.Domain;

using System.Collections.Generic;

namespace QueryApi.Domain.Interfaces
{
    public interface IArtesanoRepository
    {
        Task<Personaartesano> GetById(int id);
        Task<bool> Delete(int id);
        Task<IQueryable<Personaartesano>> GetAll();
        Task<IQueryable<Personaartesano>> GetByFilter(Personaartesano artesano);
        bool Exist(Expression<Func<Personaartesano, bool>> expression);
        Task<int> Create(Personaartesano artesano);
        Task<bool> Update(int id, Personaartesano artesano);
    }
}