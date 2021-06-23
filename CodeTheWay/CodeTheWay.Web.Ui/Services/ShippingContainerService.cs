using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CodeTheWay.Web.Ui.Services
{
    public class ShippingContainerService : IShippingContainerService
    {
        IShippingContainerRepository ShippingContainerRepository;

        public ShippingContainerService(AppDbContext dbContext)
        {
            this.ShippingContainerRepository = new ShippingContainerRepository(dbContext);
        }
        public async Task<ShippingContainer> Create(ShippingContainer shippingcontainer) {
            return await this.ShippingContainerRepository.Create(shippingcontainer);
        }

        public async Task<List<ShippingContainer>> GetShippingContainers() {
            return await this.ShippingContainerRepository.GetShippingContainers();
        }
        public async Task<ShippingContainer> GetShippingContainer(Guid id) {
            return await this.ShippingContainerRepository.GetShippingContainer(id);
        }

        public async Task<ShippingContainer> Update(ShippingContainer model) {
            return await this.ShippingContainerRepository.Update(model);
        }

        public async Task<ShippingContainer> Delete(ShippingContainer model) {
            return await this.ShippingContainerRepository.Delete(model);
        }
    }
}