using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Geometry.Application.Models.Cylinders;

namespace Geometry.Application.Interfaces.Services
{
    public interface ICylinderService
    {
        Task<CylinderResponse> CreateAsync(CreateCylinderRequest request);
        Task<CylinderResponse?> GetByIdAsync(Guid id);
        Task<List<CylinderResponse>> GetAllAsync();
        Task<CylinderResponse?> UpdateAsync(Guid id, UpdateCylinderRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
