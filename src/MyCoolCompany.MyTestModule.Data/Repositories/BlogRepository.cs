using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCoolCompany.MyTestModule.Data.Models;
using VirtoCommerce.Platform.Core.Domain;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace MyCoolCompany.MyTestModule.Data.Repositories
{
    public class BlogRepository : DbContextRepositoryBase<MyTestModuleDbContext>
    {
        public BlogRepository(MyTestModuleDbContext dbContext, IUnitOfWork unitOfWork = null)
            : base(dbContext, unitOfWork)
        {
            
        }

        public IQueryable<BlogEntity> Blogs => DbContext.Set<BlogEntity>();

        public virtual async Task<ICollection<BlogEntity>> GetBlogsByIdsAsync(IEnumerable<string> ids)
        {
            var result = await Blogs.Where(x => ids.Contains(x.Id)).ToListAsync();

            return result;
        }
    }
}
