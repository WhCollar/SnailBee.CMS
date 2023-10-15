using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace SnailBee.CMS.Features.SiteInit.Models;

public class Work : ContentPart
{
    public TextField Name { get; set; }
    
    public MediaField Image { get; set; }
}