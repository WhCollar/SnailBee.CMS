using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Title.Models;
using SnailBee.CMS.Domain;
using SnailBee.CMS.Features.QuickFormFeature.Commands;


namespace SnailBee.CMS.Features.QuickFormFeature;


[IgnoreAntiforgeryToken, AllowAnonymous]
public class QuickFormController : Controller
{
    private readonly IContentManager _contentManager;

    public QuickFormController(IContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    [HttpPost("/api/quickform")]
    public async Task<IActionResult> AddQuickForm([FromBody] AddQuickForm quickForm)
    {
        var contentItem = await _contentManager.NewAsync(nameof(QuickForm));

        var part = contentItem.As<QuickForm>();
        part.Name = new() { Text = quickForm.Name };
        part.Phone = new() { Text = quickForm.Phone };
        part.Apply();
        
        await _contentManager.CreateAsync(contentItem, VersionOptions.Published);

        var titlePart = contentItem.As<TitlePart>();
        titlePart.Title = $"Id: {contentItem.Id} |";
        contentItem.DisplayText = titlePart.Title;
        titlePart.Apply();
        
        await _contentManager.UpdateAsync(contentItem);
        
        return Ok();
    }
}