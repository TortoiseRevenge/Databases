using CodeTheWay.Web.Ui.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Repositories
{
    public class ShippingContainerRepository : IShippingContainerRepository
    {
        private AppDbContext AppDbContext;

        public ShippingContainerRepository(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<ShippingContainer> Create(ShippingContainer container)
        {
            var result = await this.AppDbContext.AddAsync(container);
            await this.AppDbContext.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<List<ShippingContainer>> GetContainers()
        {
            return await this.AppDbContext.ShippingContainers.ToListAsync();
        }
        public async Task<ShippingContainer> GetContainers(Guid id)
        {
            return await AppDbContext.ShippingContainers.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<ShippingContainer> Update(ShippingContainer model)
        {
            var result = AppDbContext.ShippingContainers.Update(model);
            await AppDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ShippingContainer> Delete(ShippingContainer model)
        {
            AppDbContext.ShippingContainers.Remove(model);
            await AppDbContext.SaveChangesAsync();
            return model;
        }
    }
}
