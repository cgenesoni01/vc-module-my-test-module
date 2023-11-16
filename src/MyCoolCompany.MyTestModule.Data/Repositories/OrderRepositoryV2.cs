using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolCompany.MyTestModule.Data.Models;
using VirtoCommerce.OrdersModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Domain;

namespace MyCoolCompany.MyTestModule.Data.Repositories
{
    public class OrderRepositoryV2 : OrderRepository
    {
        public OrderRepositoryV2(MyTestModuleDbContext dbContext, IUnitOfWork unitOfWork = null)
           : base(dbContext, unitOfWork)
        {
        }

        public IQueryable<CustomerOrderV2Entity> CustomerOrdersV2 => DbContext.Set<CustomerOrderV2Entity>();
    }
}
