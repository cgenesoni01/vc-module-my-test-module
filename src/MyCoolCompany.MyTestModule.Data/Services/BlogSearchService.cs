using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MyCoolCompany.MyTestModule.Core.Models;
using MyCoolCompany.MyTestModule.Data.Models;
using MyCoolCompany.MyTestModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.GenericCrud;
using VirtoCommerce.Platform.Data.GenericCrud;

namespace MyCoolCompany.MyTestModule.Data.Services
{
    public class BlogSearchService : SearchService<BlogSearchCriteria, BlogSearchResult, Blog, BlogEntity>
    {
        public BlogSearchService(
            Func<BlogRepository> repositoryFactory,
            IPlatformMemoryCache platformMemoryCache,
            ICrudService<Blog> crudService,
             IOptions<CrudOptions> crudOptions)
             : base(repositoryFactory, platformMemoryCache, crudService,crudOptions)
        {

        }

        protected override IQueryable<BlogEntity> BuildQuery(IRepository repository, BlogSearchCriteria criteria)
        {
            var query = ((BlogRepository)repository).Blogs;
            return query;
        }

        protected override IList<SortInfo> BuildSortExpression(BlogSearchCriteria criteria)
        {
            var sortInfos = criteria.SortInfos;

            if (sortInfos.IsNullOrEmpty())
            {
                sortInfos = new[]
                {
                    new SortInfo { SortColumn = nameof(BlogEntity.Id) }
                };
            }

            return sortInfos;
        }
    }

    public class BlogSearchCriteria : SearchCriteriaBase { }
    public class BlogSearchResult : GenericSearchResult<Blog> { }
}
