using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;
using MyCoolCompany.MyTestModule.Core;
using MyCoolCompany.MyTestModule.Data.Repositories;
using MyCoolCompany.MyTestModule.Core.Models;
using MyCoolCompany.MyTestModule.Data.Services;
using System;
using VirtoCommerce.Platform.Core.GenericCrud;
using Microsoft.Win32;
using VirtoCommerce.NotificationsModule.Core.Services;
using System.IO;
using VirtoCommerce.NotificationsModule.TemplateLoader.FileSystem;
using VirtoCommerce.NotificationsModule.Data.Services;
using MyCoolCompany.MyTestModule.Core.Services;
using MyCoolCompany.MyTestModule.Core.Type;
using VirtoCommerce.NotificationsModule.Core.Types;
using VirtoCommerce.NotificationsModule.Core.Model;
using VirtoCommerce.OrdersModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.OrdersModule.Data.Repositories;

namespace MyCoolCompany.MyTestModule.Web;

public class Module : IModule, IHasConfiguration
{
    public ManifestModuleInfo ModuleInfo { get; set; }
    public IConfiguration Configuration { get; set; }

    public void Initialize(IServiceCollection serviceCollection)
    {
        // Initialize database
        var connectionString = Configuration.GetConnectionString(ModuleInfo.Id) ??
                               Configuration.GetConnectionString("VirtoCommerce");

        // database initialization
        serviceCollection.AddDbContext<MyTestModuleDbContext>((provider, options) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            options.UseSqlServer(configuration.GetConnectionString(ModuleInfo.Id) ?? configuration.GetConnectionString("VirtoCommerce"));
        });

        serviceCollection.AddTransient<BlogRepository>();        
        serviceCollection.AddTransient<Func<BlogRepository>>(provider => () => provider.CreateScope().ServiceProvider.GetRequiredService<BlogRepository>());
        serviceCollection.AddTransient<IOrderRepository, OrderRepositoryV2>();
        //serviceCollection.AddTransient<ICrudService<Blog>, BlogService>();
        //serviceCollection.AddTransient<ISearchService<BlogSearchCriteria, BlogSearchResult, Blog>, BlogSearchService>();

        serviceCollection.AddTransient<ICustomNotificationService,CustomNotificationService>();

        // Override models
        //AbstractTypeFactory<OriginalModel>.OverrideType<OriginalModel, ExtendedModel>().MapToType<ExtendedEntity>();
        //AbstractTypeFactory<OriginalEntity>.OverrideType<OriginalEntity, ExtendedEntity>();

        AbstractTypeFactory<CustomerOrder>.OverrideType<CustomerOrder, CustomerOrderV2>()
               .WithFactory(() => new CustomerOrderV2 { OperationType = "CustomerOrder" });
        //AbstractTypeFactory<IOperation>.OverrideType<CustomerOrder, CustomerOrderV2>();
        //AbstractTypeFactory<CustomerOrderEntity>.OverrideType<CustomerOrderEntity, CustomerOrderV2Entity>();
        // Register services
        //serviceCollection.AddTransient<IMyService, MyService>();



    }

    public void PostInitialize(IApplicationBuilder appBuilder)
    {
        var serviceProvider = appBuilder.ApplicationServices;

        // Register settings
        var settingsRegistrar = serviceProvider.GetRequiredService<ISettingsRegistrar>();
        settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

        // Register permissions
        var permissionsRegistrar = serviceProvider.GetRequiredService<IPermissionsRegistrar>();
        permissionsRegistrar.RegisterPermissions(ModuleConstants.Security.Permissions.AllPermissions
            .Select(x => new Permission { ModuleId = ModuleInfo.Id, GroupName = "MyTestModule", Name = x })
            .ToArray());

        // Register notifications
        var notificationRegistrar = appBuilder.ApplicationServices.GetService<INotificationRegistrar>();
        var moduleTemplatesPath = Path.Combine(ModuleInfo.FullPhysicalPath, "Templates");
        notificationRegistrar.RegisterNotification<SampleEmailNotification>().WithTemplatesFromPath(moduleTemplatesPath);
        

        //notificationRegistrar.RegisterNotification<SampleEmailNotification>().WithTemplatesFromPath(Path.Combine(moduleTemplatesPath, "Custom"), Path.Combine(moduleTemplatesPath, "Default"));

        //Set individual discovery folder for templates
        notificationRegistrar.OverrideNotificationType<RegistrationEmailNotification, NewRegistrationEmailNotification>()
            .WithTemplates(new EmailNotificationTemplate()
            {
                Sample = "",
                Subject = "Registration email notification test",
                Body = "Registration email notification body test",
            });

        // Apply migrations
        using var serviceScope = serviceProvider.CreateScope();
        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<MyTestModuleDbContext>();
        dbContext.Database.Migrate();
    }

    public void Uninstall()
    {
        // Nothing to do here
    }
}
