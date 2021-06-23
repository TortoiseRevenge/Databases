using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;


namespace CodeTheWay.Web.Ui.Services
{
    public class ShippingContainerService : IShippingContainerService
    {
        IShippingContainerRepository ShippingContainerRepository;

        public ShippingContainerService(AppDbContext dbContext)
        {
            this.ShippingContainerRepository = new ShippingContainerRepository(dbContext);
        }
        public async Task<List<ShippingContainer>> GetContainers()
        {
            return await this.ShippingContainerRepository.GetContainers();
        }
        public async Task<ShippingContainer> GetContainers(Guid id)
        {
            return await this.ShippingContainerRepository.GetContainers(id);
        }
        public async Task<ShippingContainer> Create(ShippingContainer container)
        {
            return await this.ShippingContainerRepository.Create(container);
        }
        public async Task<ShippingContainer> Update(ShippingContainer container)
        {
            return await ShippingContainerRepository.Update(container);
        }
        public async Task<ShippingContainer> Delete(ShippingContainer container)
        {
            return await ShippingContainerRepository.Delete(container);
        }
    }
}
