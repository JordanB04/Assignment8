using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Geometry.Domain.Entities;

namespace Geometry.Application.Interfaces.Repositories
{
    public interface ICylinderRepository
    {
        Task<Cylinder> AddAsync(Cylinder cylinder);
        Task<Cylinder?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Cylinder>> GetAllAsync();
        Task<Cylinder> UpdateAsync(Cylinder cylinder);
        Task<bool> DeleteAsync(Guid id);
    }
}
