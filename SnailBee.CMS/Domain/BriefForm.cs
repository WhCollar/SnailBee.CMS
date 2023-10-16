using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace SnailBee.CMS.Domain;


public class BriefForm : ContentPart
{
    public TextField About { get; set; }
    
    public TextField Case { get; set; }
    
    public TextField Budget { get; set; }
    
    public TextField Commentary { get; set; }
    
    public TextField Name { get; set; }
    
    public TextField Phone { get; set; }
    
    public TextField Email { get; set; }
}