using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EShopOnAbp.CurrencyService.EntityFrameworkCore;
//using EShopOnAbp.CurrencyService.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using System.Threading.Tasks;
using EShopOnAbp.CurrencyService.DbMigrations;
using EShopOnAbp.Shared.Hosting.Microservices;
using Volo.Abp.Identity;
using Volo.Abp.Http.Client.IdentityModel.Web;
using EShopOnAbp.Shared.Hosting.AspNetCore;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Uow;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
      typeof(EShopOnAbpSharedHostingMicroservicesModule),
    typeof(CurrencyServiceApplicationModule),
    typeof(CurrencyServiceEntityFrameworkCoreModule),
    typeof(CurrencyServiceHttpApiModule),
        typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelWebModule)


    //typeof(CurrencyServiceApplicationContractsModule),
    //typeof(AbpAutofacModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    //typeof(AbpEntityFrameworkCoreSqlServerModule),
    //typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    //typeof(AbpSettingManagementEntityFrameworkCoreModule),
    //typeof(AbpTenantManagementEntityFrameworkCoreModule),
    //typeof(AbpAspNetCoreSerilogModule),
    //typeof(AbpSwashbuckleModule)
    )]
public class CurrencyServiceHttpApiHostModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "CurrencyService");

        SwaggerConfigurationHelper.ConfigureWithAuth(
            context: context,
            authority: configuration["AuthServer:Authority"],
            scopes: new
                Dictionary<string, string> /* Requested scopes for authorization code request and descriptions for swagger UI only */
                {
                    { "CurrencyService", "Currency Service API" }
                },
            apiTitle: "Currency Service API"
        );

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(CurrencyServiceApplicationModule).Assembly, opts =>
            {
                opts.RootPath = "currency";
                opts.RemoteServiceName = "Currency";
            });
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            //Standalone MongoDB servers don't support transactions
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });







        var hostingEnvironment = context.Services.GetHostingEnvironment();
 

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<CurrencyServiceDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EShopOnAbp.CurrencyService.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CurrencyServiceDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EShopOnAbp.CurrencyService.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CurrencyServiceApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EShopOnAbp.CurrencyService.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CurrencyServiceApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EShopOnAbp.CurrencyService.Application", Path.DirectorySeparatorChar)));
            });
        }

        //context.Services.AddAbpSwaggerGenWithOAuth(

        //    configuration["AuthServer:Authority"],
        //    new Dictionary<string, string>
        //    {
        //        {"CurrencyService", "CurrencyService API"}
        //    },
        //    options =>
        //    {
        //        options.SwaggerDoc("v1", new OpenApiInfo {Title = "CurrencyService API", Version = "v1"});
        //        options.DocInclusionPredicate((docName, description) => true);
        //        options.CustomSchemaIds(type => type.FullName);
        //    });

        //Configure<AbpLocalizationOptions>(options =>
        //{
        //    options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
        //    options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
        //    options.Languages.Add(new LanguageInfo("en", "en", "English"));
        //    options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
        //    options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
        //    options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
        //    options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
        //    options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
        //    options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
        //    options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
        //    options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
        //    options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
        //    options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
        //    options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
        //    options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        //    options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        //    options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
        //    options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
        //    options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        //    options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        //});






        //context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options =>
        //    {
        //        options.Authority = configuration["AuthServer:Authority"];
        //        options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
        //        options.Audience = "CurrencyService";
        //    });

        //Configure<AbpDistributedCacheOptions>(options =>
        //{
        //    options.KeyPrefix = "CurrencyService:";
        //});

        //var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("CurrencyService");
        //if (!hostingEnvironment.IsDevelopment())
        //{
        //    var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "CurrencyService-Protection-Keys");
        //}

    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        //if (MultiTenancyConsts.IsEnabled)
        //{
        //    app.UseMultiTenancy();
        //}
        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Currency Service API");
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            //options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

            //var configuration = context.GetConfiguration();
            //options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            //options.OAuthScopes("CurrencyService");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }

    public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        await context.ServiceProvider
            .GetRequiredService<CurrencyServiceDatabaseMigrationChecker>()
            .CheckAndApplyDatabaseMigrationsAsync();
    }
    //public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    //{
    //    await context.ServiceProvider
    //        .GetRequiredService<CurrencyServiceDatabaseMigrationChecker>()
    //        .CheckAndApplyDatabaseMigrationsAsync();
    //}
}
