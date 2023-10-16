using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Title.Models;
using SnailBee.CMS.Domain;
using SnailBee.CMS.Features.BriefFormFeature.Commands;


namespace SnailBee.CMS.Features.BriefFormFeature;


[IgnoreAntiforgeryToken, AllowAnonymous]
public class BriefFormController : Controller
{
    private readonly IContentManager _contentManager;

    public BriefFormController(IContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    [HttpPost("/api/briefform")]
    public async Task<IActionResult> Add([FromBody] AddBriefForm briefForm)
    {
        var contentItem = await _contentManager.NewAsync(nameof(BriefForm));

        var part = contentItem.As<BriefForm>();
        part.About = new() { Text = briefForm.About };
        part.Case = new() { Text = briefForm.Case };
        part.Budget = new() { Text = briefForm.Budget };
        part.Commentary = new() { Text = briefForm.Commentary };
        part.Name = new() { Text = briefForm.Name };
        part.Phone = new() { Text = briefForm.Phone };
        part.Email = new() { Text = briefForm.Email };
        part.Apply();

        await _contentManager.CreateAsync(contentItem, VersionOptions.Published);
        
        var titlePart = contentItem.As<TitlePart>();
        titlePart.Title = $"Id: {contentItem.Id} |";
        contentItem.DisplayText = titlePart.Title;
        titlePart.Apply();
        
        return Ok();
    }
}