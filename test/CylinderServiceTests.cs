using System;
using System.Threading.Tasks;
using Xunit;
using Geometry.Application.Services;
using Geometry.Application.Models.Cylinders;
using Geometry.Infrastructure.Repositories;

namespace Geometry.Tests
{
    public class CylinderServiceTests
    {
        [Fact]
        public async Task Create_Works()
        {
            var repo = new CylinderRepository();
            var service = new CylinderService(repo);

            var result = await service.CreateAsync(new CreateCylinderRequest
            {
                Radius = 3,
                Height = 5
            });

            Assert.NotNull(result);
            Assert.Equal(3, result.Radius);
            Assert.Equal(5, result.Height);
        }

        [Fact]
        public async Task Update_Works()
        {
            var repo = new CylinderRepository();
            var service = new CylinderService(repo);

            var created = await service.CreateAsync(new CreateCylinderRequest
            {
                Radius = 2,
                Height = 4
            });

            var updated = await service.UpdateAsync(created.Id,
                new UpdateCylinderRequest { Radius = 8, Height = 9 });

            Assert.Equal(8, updated!.Radius);
            Assert.Equal(9, updated.Height);
        }

        [Fact]
        public async Task Delete_Works()
        {
            var repo = new CylinderRepository();
            var service = new CylinderService(repo);

            var created = await service.CreateAsync(new CreateCylinderRequest
            {
                Radius = 1,
                Height = 1
            });

            var deleted = await service.DeleteAsync(created.Id);

            Assert.True(deleted);
        }
    }
}
