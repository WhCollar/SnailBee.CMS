using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using SnailBee.CMS.Features.Clients.Models;
using SnailBee.CMS.Features.SiteInit.Models;
using SnailBee.CMS.Features.Works.Models;

namespace SnailBee.CMS.Features;

public class Migration : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public Migration(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public int Create()
    {
        AddSnailBeeSettings();
        AddClient();
        AddWork();
        
        return 1;
    }

    private void AddSnailBeeSettings()
    {
        _contentDefinitionManager.AlterTypeDefinition(nameof(SnailBeeSettings), type => type
            .WithPart(nameof(SnailBeeSettings))
            .Stereotype("CustomSettings")
        );

        _contentDefinitionManager.AlterPartDefinition(nameof(SnailBeeSettings), part => part
            .WithField(nameof(SnailBeeSettings.AutomationDepartment), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(SnailBeeSettings.AutomationDepartment))
            )
            .WithField(nameof(SnailBeeSettings.GameDepartmentName), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(SnailBeeSettings.GameDepartmentName))
            )
            .WithField(nameof(SnailBeeSettings.Phone), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(SnailBeeSettings.Phone))
            )
            .WithField(nameof(SnailBeeSettings.Email), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(SnailBeeSettings.Email))
            )
            .WithField(nameof(SnailBeeSettings.Telegram), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(SnailBeeSettings.Telegram))
            )
        );
    }

    private void AddClient()
    {
        _contentDefinitionManager.AlterTypeDefinition(nameof(Client), type => type
            .WithPart(nameof(Client))
            .Creatable()
        );

        _contentDefinitionManager.AlterPartDefinition(nameof(Client), part => part
            .WithField(nameof(Client.Name), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(Client.Name))
            )
            .WithField(nameof(Client.Logo), field => field
                .OfType(nameof(MediaField))
                .WithDisplayName(nameof(Client.Logo))
            )
        );
    }

    private void AddWork()
    {
        _contentDefinitionManager.AlterTypeDefinition(nameof(Work), type => type
            .WithPart(nameof(Work))
            .Creatable()
        );

        _contentDefinitionManager.AlterPartDefinition(nameof(Work), part => part
            .WithField(nameof(Work.Name), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(Work.Name))
            )
            .WithField(nameof(Work.Image), field => field
                .OfType(nameof(MediaField))
                .WithDisplayName(nameof(Work.Image))
            )
        );
    }
}