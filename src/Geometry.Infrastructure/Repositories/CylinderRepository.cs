using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geometry.Application.Interfaces.Repositories;
using Geometry.Domain.Entities;

namespace Geometry.Infrastructure.Repositories
{
    public class CylinderRepository : ICylinderRepository
    {
        private readonly List<Cylinder> _storage = new();

        public Task<Cylinder> AddAsync(Cylinder cylinder)
        {
            _storage.Add(cylinder);
            return Task.FromResult(cylinder);
        }

        public Task<Cylinder?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_storage.FirstOrDefault(c => c.Id == id));
        }

        public Task<IReadOnlyCollection<Cylinder>> GetAllAsync()
        {
            return Task.FromResult((IReadOnlyCollection<Cylinder>)_storage.ToList());
        }

        public Task<Cylinder> UpdateAsync(Cylinder cylinder)
        {
            var index = _storage.FindIndex(c => c.Id == cylinder.Id);
            _storage[index] = cylinder;
            return Task.FromResult(cylinder);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var cylinder = _storage.FirstOrDefault(c => c.Id == id);
            if (cylinder == null) return Task.FromResult(false);

            _storage.Remove(cylinder);
            return Task.FromResult(true);
        }
    }
}
