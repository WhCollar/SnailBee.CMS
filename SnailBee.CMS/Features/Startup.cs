using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using SnailBee.CMS.Domain;
using StartupBase = Microsoft.AspNetCore.Hosting.StartupBase;


namespace SnailBee.CMS.Features;


[Feature("OrchardCore.ContentTypes")]
public class Startup : StartupBase
{
    public override void Configure(IApplicationBuilder app)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddContentPart<SnailBeeSettings>();
        services.AddContentPart<Client>();
        services.AddContentPart<Work>();
        services.AddContentPart<QuickForm>();
        services.AddContentPart<BriefForm>();
        services.AddScoped<IDataMigration, Migration>();
    }
}