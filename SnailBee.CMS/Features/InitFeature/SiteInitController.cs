using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Entities;
using OrchardCore.Settings;
using SnailBee.CMS.Features.InitFeature.Models;


namespace SnailBee.CMS.Features.InitFeature;


[IgnoreAntiforgeryToken, AllowAnonymous]
public class SiteInitController : Controller
{
    private readonly ISiteService _siteService;

    public SiteInitController(ISiteService siteService)
    {
        _siteService = siteService;
    }
    
    [HttpGet("/api/static")]
    public async Task<IActionResult> Init()
    {
        var siteSettings = await _siteService.GetSiteSettingsAsync();
        var settings = siteSettings.As<ContentItem>(nameof(SnailBeeSettings));
        return Ok(settings.As<SnailBeeSettings>());
    }
}