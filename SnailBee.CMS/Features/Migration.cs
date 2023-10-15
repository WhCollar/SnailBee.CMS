using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Title.Models;
using SnailBee.CMS.Features.BriefFormFeature.Models;
using SnailBee.CMS.Features.QuickFormFeature.Models;
using SnailBee.CMS.Features.SiteInit.Models;

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
        DeleteDefaultTypes();
        AddSnailBeeSettings();
        AddClient();
        AddWork();
        AddQuickForm();
        AddBriefForm();
        
        return 1;
    }

    private void DeleteDefaultTypes()
    {
        _contentDefinitionManager.DeletePartDefinition("ContentMenuItem");
        _contentDefinitionManager.DeleteTypeDefinition("ContentMenuItem");
        
        _contentDefinitionManager.DeletePartDefinition("HtmlMenuItem");
        _contentDefinitionManager.DeleteTypeDefinition("HtmlMenuItem");
        
        _contentDefinitionManager.DeletePartDefinition("LinkMenuItem");
        _contentDefinitionManager.DeleteTypeDefinition("LinkMenuItem");
        
        _contentDefinitionManager.DeletePartDefinition("Menu");
        _contentDefinitionManager.DeleteTypeDefinition("Menu");
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
            .WithPart(nameof(TitlePart))
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
            .WithPart(nameof(TitlePart))
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

    private void AddQuickForm()
    {
        _contentDefinitionManager.AlterTypeDefinition(nameof(QuickForm), type => type
            .WithPart(nameof(QuickForm))
            .WithPart(nameof(TitlePart))
            .Creatable()
        );

        _contentDefinitionManager.AlterPartDefinition(nameof(QuickForm), part => part
            .WithField(nameof(QuickForm.Name), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(QuickForm.Name))
            )
            .WithField(nameof(QuickForm.Phone), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(QuickForm.Phone))
            )
        );
    }

    private void AddBriefForm()
    {
        _contentDefinitionManager.AlterTypeDefinition(nameof(BriefForm), type => type
            .WithPart(nameof(BriefForm))
            .WithPart(nameof(TitlePart))
            .Creatable()
        );

        _contentDefinitionManager.AlterPartDefinition(nameof(BriefForm), part => part
            .WithField(nameof(BriefForm.Name), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Name))
            )
            .WithField(nameof(BriefForm.Phone), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Phone))
            )
            .WithField(nameof(BriefForm.Email), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Email))
            )
            .WithField(nameof(BriefForm.About), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.About))
            )
            .WithField(nameof(BriefForm.Case), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Case))
            )
            .WithField(nameof(BriefForm.Budget), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Budget))
            )
            .WithField(nameof(BriefForm.Commentary), field => field
                .OfType(nameof(TextField))
                .WithDisplayName(nameof(BriefForm.Commentary))
            )
        );
    }
}