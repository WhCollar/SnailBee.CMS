using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;


namespace SnailBee.CMS.Features.InitFeature.Models;


public class Work : ContentPart
{
    public TextField Name { get; set; }
    
    public MediaField Image { get; set; }
}