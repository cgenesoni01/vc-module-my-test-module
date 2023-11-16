using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCoolCompany.MyTestModule.Core;
using MyCoolCompany.MyTestModule.Core.Models;
using MyCoolCompany.MyTestModule.Core.Services;
using MyCoolCompany.MyTestModule.Data.Services;
using VirtoCommerce.NotificationsModule.Core.Model;
using VirtoCommerce.Platform.Core.GenericCrud;

namespace MyCoolCompany.MyTestModule.Web.Controllers.Api
{
    [Route("api/my-test-module")]
    public class MyTestModuleController : Controller
    {
        //private readonly ICrudService<Blog> _blogService;
        //private readonly ISearchService<BlogSearchCriteria, BlogSearchResult, Blog> _blogSearchService;
        private readonly ICustomNotificationService _customNotificationService;

        public MyTestModuleController(
            //ICrudService<Blog> blogService,
            //ISearchService<BlogSearchCriteria, BlogSearchResult, Blog> blogSearchService,
            ICustomNotificationService customNotificationService)
        {
            //_blogService = blogService;
            //_blogSearchService = blogSearchService;
            _customNotificationService = customNotificationService;
        }

        //[HttpPost]
        //[Route("")]
        //public async Task<ActionResult<Blog>> AddBlog(string name)
        //{
        //    var blog = new Blog { Name = name };

        //    await _blogService.SaveChangesAsync(new List<Blog> { blog });

        //    return Ok(blog);
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<ActionResult<BlogSearchResult>> GetAll()
        //{
        //    var result = await _blogSearchService.SearchAsync(new BlogSearchCriteria());

        //    return Ok(result);
        //}

        // GET: api/my-test-module
        /// <summary>
        /// Get message
        /// </summary>
        /// <remarks>Return "Hello world!" message</remarks>
        [HttpGet]
        [Route("HelloWorld")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult<string> Get()
        {
            return Ok(new { result = "Hello world!" });
        }

        [HttpGet]
        [Route("SendNotification")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult<Task<NotificationSendResult>> SendNotification()
        {
            return _customNotificationService.SendNotification();
        }
    }
}

