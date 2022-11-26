using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using EShopOnAbp.PublicBlazor.Localization;
using EShopOnAbp.PublicBlazor.Menus;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Uow;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Components.Server.LeptonXLiteTheme;
using Volo.Abp.AspNetCore.Components.Server.LeptonXLiteTheme.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Emailing;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Blazor.Server;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Blazor.Server;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Blazor.Server;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Blazor.Server;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using EShopOnAbp.Localization;
using EShopOnAbp.CurrencyService.Blazor.Server;
using EShopOnAbp.CurrencyService.Blazor;
using EShopOnAbp.CurrencyService.EntityFrameworkCore;
using EShopOnAbp.CurrencyService;
using Volo.Abp.Http.Client;
using Volo.Abp.Caching;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Volo.Abp.Security.Claims;
using Volo.Abp.EventBus.Distributed;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using StackExchange.Redis;
using Microsoft.AspNetCore.DataProtection;
using Yarp.ReverseProxy.Transforms;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.HttpOverrides;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Polly;
using EShopOnAbp.CmskitService;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.Caching.StackExchangeRedis;
using EShopOnAbp.CustomerService;
using EShopOnAbp.CustomerService.Blazor;
using EShopOnAbp.CustomerService.EntityFrameworkCore;
using EShopOnAbp.CustomerService.Blazor.Server;
using EShopOnAbp.PublicBlazor.Data;
using EShopOnAbp.Shared.Hosting.Microservices;

namespace EShopOnAbp.PublicBlazor;

[DependsOn(
    // ABP Framework packages
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAspNetCoreComponentsServerLeptonXLiteThemeModule),

    // Account module packages
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAccountWebOpenIddictModule),

    // Identity module packages
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpIdentityBlazorServerModule),

    // Audit logging module packages
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),

    // Permission Management module packages
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),

    // Tenant Management module packages
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementBlazorServerModule),

    // Feature Management module packages
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpFeatureManagementBlazorServerModule),

    // Setting Management module packages
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpSettingManagementBlazorServerModule),



    typeof(EShopOnAbpSharedLocalizationModule),
        typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpAccountWebIdentityServerModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAspNetCoreSignalRModule),
    typeof(AbpAutoMapperModule),
        typeof(CmskitServiceHttpApiClientModule),
     typeof(AbpHttpClientModule),

     typeof(EShopOnAbpSharedHostingMicroservicesModule),



        // Currency module packages
        typeof(CurrencyServiceEntityFrameworkCoreModule),
            typeof(CurrencyServiceHttpApiClientModule),
        typeof(CurrencyServiceBlazorServerModule),
        typeof(CurrencyServiceBlazorModule),
           typeof(CurrencyServiceDomainModule),
      typeof(CurrencyServiceDomainSharedModule),
     typeof(CurrencyServiceApplicationModule),
    typeof(CurrencyServiceApplicationContractsModule),

    // Customer module packages
    typeof(CustomerServiceEntityFrameworkCoreModule),
      typeof(CustomerServiceHttpApiClientModule),
       typeof(CustomerServiceBlazorServerModule),
     typeof(CustomerServiceBlazorModule),
           typeof(CustomerServiceDomainModule),
      typeof(CustomerServiceDomainSharedModule),
     typeof(CustomerServiceApplicationModule),
    typeof(CustomerServiceApplicationContractsModule)

)]
public class PublicBlazorModule : AbpModule
{
    /* Single point to enable/disable multi-tenancy */
    public const bool IsMultiTenant = true;

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                   typeof(EShopOnAbpResource),
                typeof(PublicBlazorModule).Assembly
            );
        });

        PreConfigure<AbpHttpClientBuilderOptions>(options =>
            {
                options.ProxyClientBuildActions.Add((remoteServiceName, clientBuilder) =>
                {
                    clientBuilder.AddTransientHttpErrorPolicy(policyBuilder =>
                        policyBuilder.WaitAndRetryAsync(
                            3,
                            i => TimeSpan.FromSeconds(Math.Pow(2, i))
                        )
                    );
                });
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.AddEmbedded<PublicBlazorModule>();
                });
            });
        FeatureConfigurer.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        if (hostingEnvironment.IsDevelopment())
        {
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
        }

        context.Services.Configure<AbpRemoteServiceOptions>(options =>
               {
                   options.RemoteServices.Default =
                       new RemoteServiceConfiguration(configuration["RemoteServices:Default:BaseUrl"]);
               });
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "EShopOnAbp:"; });

        context.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
        })

           .AddCookie("Cookies", options => { options.ExpireTimeSpan = TimeSpan.FromDays(365); })
           .AddAbpOpenIdConnect("oidc", options =>
           {
               options.Authority = configuration["AuthServer:Authority"];
               options.ClientId = configuration["AuthServer:ClientId"];
               options.ClientSecret = configuration["AuthServer:ClientSecret"];
               options.MetadataAddress = configuration["AuthServer:MetaAddress"];
               options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
               options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
               options.GetClaimsFromUserInfoEndpoint = true;
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("email");
               options.Scope.Add("phone");
               options.Scope.Add("role");
               options.Scope.Add("offline_access");

               options.Scope.Add("AdministrationService");

               options.Scope.Add("BasketService");
               options.Scope.Add("CatalogService");
               options.Scope.Add("PaymentService");
               options.Scope.Add("OrderingService");
               options.Scope.Add("CmskitService");
               options.Scope.Add("CurrencyService");
               options.Scope.Add("CustomerService");

               options.SaveTokens = true;

               //SameSite is needed for Chrome/Firefox, as they will give http error 500 back, if not set to unspecified.
               // options.NonceCookie.SameSite = SameSiteMode.Unspecified;
               // options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
               //
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   NameClaimType = "name",
                   RoleClaimType = ClaimTypes.Role,
                   ValidateIssuer = true
               };

               options.Events.OnAuthorizationCodeReceived = async (authContext) =>
               {
                   var userLoggedInEto = CreateUserLoggedInEto(authContext.Principal, authContext.HttpContext);
                   if (userLoggedInEto != null)
                   {
                       var eventBus =
                           authContext.HttpContext.RequestServices.GetRequiredService<IDistributedEventBus>();
                       await eventBus.PublishAsync(userLoggedInEto);
                   }
               };

               if (AbpClaimTypes.UserName != "preferred_username")
               {
                   options.ClaimActions.MapJsonKey(AbpClaimTypes.UserName, "preferred_username");
                   options.ClaimActions.DeleteClaim("preferred_username");
                   options.ClaimActions.RemoveDuplicate(AbpClaimTypes.UserName);
               }
           });

        if (Convert.ToBoolean(configuration["AuthServer:IsOnProd"]))
        {
            context.Services.Configure<OpenIdConnectOptions>("oidc", options =>
            {
                options.MetadataAddress = configuration["AuthServer:MetaAddress"].EnsureEndsWith('/') +
                                          ".well-known/openid-configuration";

                var previousOnRedirectToIdentityProvider = options.Events.OnRedirectToIdentityProvider;
                options.Events.OnRedirectToIdentityProvider = async ctx =>
                {
                    // Intercept the redirection so the browser navigates to the right URL in your host
                    ctx.ProtocolMessage.IssuerAddress = configuration["AuthServer:Authority"].EnsureEndsWith('/') +
                                                        "connect/authorize";

                    if (previousOnRedirectToIdentityProvider != null)
                    {
                        await previousOnRedirectToIdentityProvider(ctx);
                    }
                };
                var previousOnRedirectToIdentityProviderForSignOut =
                    options.Events.OnRedirectToIdentityProviderForSignOut;
                options.Events.OnRedirectToIdentityProviderForSignOut = async ctx =>
                {
                    // Intercept the redirection for signout so the browser navigates to the right URL in your host
                    ctx.ProtocolMessage.IssuerAddress = configuration["AuthServer:Authority"].EnsureEndsWith('/') +
                                                        "connect/endsession";

                    if (previousOnRedirectToIdentityProviderForSignOut != null)
                    {
                        await previousOnRedirectToIdentityProviderForSignOut(ctx);
                    }
                };
            });
        }


        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        context.Services
            .AddDataProtection()
            .PersistKeysToStackExchangeRedis(redis, "EShopOnAbp-Protection-Keys")
            .SetApplicationName("eShopOnAbp-PublicBlazor");

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new EShopOnAbpPublicBlazorMenuContributor(configuration));
        });



        context.Services
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"))
            .AddTransforms(builderContext =>
            {
                builderContext.AddRequestTransform(async (transformContext) =>
                {
                    transformContext.ProxyRequest.Headers
                        .Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        await transformContext.HttpContext.GetTokenAsync("access_token")
                    );
                });
            });














        // ConfigureAuthentication(context);
        ConfigureUrls(configuration);
        ConfigureBundles();
        ConfigureAutoMapper(context);
        ConfigureVirtualFiles(hostingEnvironment);
        ConfigureLocalizationServices();
        ConfigureSwaggerServices(context.Services);
        //ConfigureNavigationServices();
        ConfigureAutoApiControllers();
        ConfigureBlazorise(context);
        ConfigureRouter(context);
      ConfigureEfCore(context);
    }

    private void ConfigureEfCore(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PublicBlazorDbContext>(options =>
        {
            /* You can remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots
             * Documentation: https://docs.abp.io/en/abp/latest/Entity-Framework-Core#add-default-repositories
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(configurationContext =>
            {
                configurationContext.UseSqlServer();
            });
        });

    }
    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"].Split(','));
        });
    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            //// MVC UI
            //options.StyleBundles.Configure(
            //    LeptonXLiteThemeBundles.Styles.Global,
            //    bundle =>
            //    {
            //        bundle.AddFiles("/global-styles.css");
            //    }
            //);

            //BLAZOR UI
            options.StyleBundles.Configure(
                BlazorLeptonXLiteThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/blazor-global-styles.css");
                    //You can remove the following line if you don't use Blazor CSS isolation for components
                    bundle.AddFiles("/EShopOnAbp.PublicBlazor.styles.css");
                }
            );
        });
    }

    private void ConfigureLocalizationServices()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<PublicBlazorResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/PublicBlazor");

            options.DefaultResourceType = typeof(PublicBlazorResource);

            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("PublicBlazor", typeof(PublicBlazorResource));
        });
    }

    private void ConfigureVirtualFiles(IWebHostEnvironment hostingEnvironment)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PublicBlazorModule>();
            if (hostingEnvironment.IsDevelopment())
            {
                /* Using physical files in development, so we don't need to recompile on changes */
                options.FileSets.ReplaceEmbeddedByPhysical<PublicBlazorModule>(hostingEnvironment.ContentRootPath);
            }
        });
    }

    private void ConfigureSwaggerServices(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PublicBlazor API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(PublicBlazorModule).Assembly;
        });
    }

    //private void ConfigureNavigationServices()
    //{
    //    Configure<AbpNavigationOptions>(options =>
    //    {
    //        options.MenuContributors.Add(new PublicBlazorMenuContributor());
    //    });
    //}

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(PublicBlazorModule).Assembly);
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PublicBlazorModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PublicBlazorModule>();
        });
    }

    private UserLoggedInEto CreateUserLoggedInEto(ClaimsPrincipal principal, HttpContext httpContext)
    {
        var logger = httpContext.RequestServices.GetRequiredService<ILogger<PublicBlazorModule>>();

        if (principal == null)
        {
            logger.LogWarning($"AuthorizationCode does not contain principal to create/update user!");
            return null;
        }

        var claims = principal.Claims.ToList();

        var userNameClaim = claims.FirstOrDefault(x => x.Type == "preferred_username");
        var emailClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
        var isEmailVerified = claims.FirstOrDefault(x => x.Type == "email_verified")?.Value == "true";
        var phoneNumberClaim = claims.FirstOrDefault(x => x.Type == "phone");
        var userIdString = claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;

        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            logger.LogWarning(
                $"Handling UserLoggedInEvent... User creation failed! {userIdString} can not be parsed!");
            return null;
        }

        return new UserLoggedInEto
        {
            Id = userId,
            Email = emailClaim?.Value,
            UserName = userNameClaim?.Value,
            Phone = phoneNumberClaim?.Value,
            IsEmailVerified = isEmailVerified
        };
    }
    private X509Certificate2 GetSigningCertificate(IWebHostEnvironment hostingEnv)
    {
        const string fileName = "eshoponabp-publicblazor.pfx";
        const string passPhrase = "780F3C11-0A96-40DE-B335-9848BE88C77D";
        var file = Path.Combine(hostingEnv.ContentRootPath, fileName);

        if (!File.Exists(file))
        {
            throw new FileNotFoundException($"Signing Certificate couldn't found: {file}");
        }

        return new X509Certificate2(file, passPhrase);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {

        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.Use((ctx, next) =>
        {
            ctx.Request.Scheme = "https";
            return next();
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        // app.UseHttpMetrics();
        app.UseAuthentication();
        app.UseAbpSerilogEnrichers();
        app.UseUnitOfWork();

        app.UseAuthorization();
        //app.UseAnonymousUser();
        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy();
            // endpoints.MapMetrics();
        });
        //app.UseAuditing();
        //app.UseAbpSerilogEnrichers();
        //app.UseConfiguredEndpoints();
    }
}
































