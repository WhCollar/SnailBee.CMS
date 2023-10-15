using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace SnailBee.CMS.Features.SiteInit.Models;

public class SnailBeeSettings : ContentPart
{
    public TextField Phone { get; set; }

    public TextField Email { get; set; }

    public TextField Telegram { get; set; }

    public TextField GameDepartmentName { get; set; }

    public TextField AutomationDepartment { get; set; }
}