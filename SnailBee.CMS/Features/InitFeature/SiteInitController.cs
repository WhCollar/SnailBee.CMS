using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using OrchardCore.Entities;
using OrchardCore.Settings;
using SnailBee.CMS.Features.SiteInit.Models;


namespace SnailBee.CMS.Features.InitFeature;


[IgnoreAntiforgeryToken, AllowAnonymous]
public class SiteInitController : Controller
{
    private readonly ISiteService _siteService;

    public SiteInitController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    [AllowAnonymous]
    [HttpGet("/api/static")]
    public async Task<IActionResult> Init()
    {
        var siteSettings = await _siteService.GetSiteSettingsAsync();
        var settings = siteSettings.As<ContentItem>(nameof(SnailBeeSettings));
        
        var parsedSettings = JsonConvert.DeserializeObject<SnailBeeSettingsContent>(
            Convert.ToString(settings.Content)
        ) as SnailBeeSettingsContent;

        if (parsedSettings is null)
            return NotFound("Не удалось получить настроки сайта");
        
        return Ok(parsedSettings.SnailBeeSettings);
    }
}