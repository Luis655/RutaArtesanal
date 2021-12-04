using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RutaArtesanal.Api.Domain;

using System.Collections.Generic;

namespace QueryApi.Domain.Interfaces
{
    public interface IArtesaniaRepository
    {
        Task<Artesanium> GetById(int id);
        Task<bool> Delete(int id);
        Task<IQueryable<Artesanium>> GetAll();
        Task<IQueryable<Artesanium>> GetByFilter(Artesanium artesania);
        Task<int> Create(Artesanium artesania);
        Task<bool> Update(int id, Artesanium artesania);
    }
}