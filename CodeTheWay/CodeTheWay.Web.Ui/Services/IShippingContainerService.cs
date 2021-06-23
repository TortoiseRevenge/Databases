using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models;

namespace CodeTheWay.Web.Ui.Services
{
    public interface IShippingContainerService
    {
        public Task<List<ShippingContainer>> GetContainers();
        public Task<ShippingContainer> GetContainers(Guid id);
        public Task<ShippingContainer> Create(ShippingContainer container);
        public Task<ShippingContainer> Update(ShippingContainer container);

        public Task<ShippingContainer> Delete(ShippingContainer container);
    }
}
