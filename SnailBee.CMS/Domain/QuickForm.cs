using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace SnailBee.CMS.Domain;


public class QuickForm : ContentPart
{
    public TextField Name { get; set; }
    
    public TextField Phone { get; set; }
}