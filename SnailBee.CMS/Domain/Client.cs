using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace SnailBee.CMS.Domain;


public class Client : ContentPart
{
    public TextField Name { get; set; }
    
    public MediaField Logo { get; set; }
}