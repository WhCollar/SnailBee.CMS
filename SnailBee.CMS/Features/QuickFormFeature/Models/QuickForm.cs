using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;


namespace SnailBee.CMS.Features.QuickFormFeature.Models;


public class QuickForm : ContentPart
{
    public TextField Name { get; set; }
    
    public TextField Phone { get; set; }
}