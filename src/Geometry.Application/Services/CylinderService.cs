using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geometry.Application.Interfaces.Repositories;
using Geometry.Application.Interfaces.Services;
using Geometry.Application.Models.Cylinders;
using Geometry.Domain.Entities;

namespace Geometry.Application.Services
{
    public class CylinderService : ICylinderService
    {
        private readonly ICylinderRepository _repository;

        public CylinderService(ICylinderRepository repository)
        {
            _repository = repository;
        }

        public async Task<CylinderResponse> CreateAsync(CreateCylinderRequest request)
        {
            var cylinder = new Cylinder
            {
                Id = Guid.NewGuid(),
                Radius = request.Radius,
                Height = request.Height
            };

            await _repository.AddAsync(cylinder);
            return ToResponse(cylinder);
        }

        public async Task<CylinderResponse?> GetByIdAsync(Guid id)
        {
            var cylinder = await _repository.GetByIdAsync(id);
            return cylinder == null ? null : ToResponse(cylinder);
        }

        public async Task<List<CylinderResponse>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).Select(ToResponse).ToList();
        }

        public async Task<CylinderResponse?> UpdateAsync(Guid id, UpdateCylinderRequest request)
        {
            var cylinder = await _repository.GetByIdAsync(id);
            if (cylinder == null) return null;

            cylinder.Radius = request.Radius;
            cylinder.Height = request.Height;

            await _repository.UpdateAsync(cylinder);
            return ToResponse(cylinder);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        private static CylinderResponse ToResponse(Cylinder c) =>
            new CylinderResponse
            {
                Id = c.Id,
                Radius = c.Radius,
                Height = c.Height,
                Volume = c.Volume,
                SurfaceArea = c.SurfaceArea
            };
    }
}
