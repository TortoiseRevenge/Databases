using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models;
namespace CodeTheWay.Web.Ui.Repositories
{
    public interface IShippingContainerRepository
    {
        public Task<List<ShippingContainer>> GetContainers();
        public Task<ShippingContainer> GetContainers(Guid id);

        public Task<ShippingContainer> Create(ShippingContainer container);
        public Task<ShippingContainer> Update(ShippingContainer model);

        public Task<ShippingContainer> Delete(ShippingContainer model);
    }
}
