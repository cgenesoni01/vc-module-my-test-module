using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolCompany.MyTestModule.Core.Models;
using MyCoolCompany.MyTestModule.Data.Models;
using MyCoolCompany.MyTestModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Data.GenericCrud;

namespace MyCoolCompany.MyTestModule.Data.Services
{
    public class BlogService : CrudService<Blog, BlogEntity, BlogChangingEvent, BlogChangedEvent>
    {
        public BlogService(
            Func<BlogRepository> repositoryFactory, 
            IPlatformMemoryCache platformMemoryCache,
            IEventPublisher eventPublisher) : base(repositoryFactory, platformMemoryCache, eventPublisher)
        {
        }

        protected override async Task<IList<BlogEntity>> LoadEntities(IRepository repository, IList<string> ids, string responseGroup)
        {
            var blogRepository = repository as BlogRepository;
            return (IList<BlogEntity>)await blogRepository.GetBlogsByIdsAsync(ids);
        }
    }

    public class BlogChangedEvent : GenericChangedEntryEvent<Blog>
    {
        public BlogChangedEvent(IEnumerable<GenericChangedEntry<Blog>> changedEntries)
            : base(changedEntries)
        {
        }
    }

    public class BlogChangingEvent : GenericChangedEntryEvent<Blog>
    {
        public BlogChangingEvent(IEnumerable<GenericChangedEntry<Blog>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
