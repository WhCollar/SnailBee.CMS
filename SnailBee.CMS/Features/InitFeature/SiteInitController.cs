using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Entities;
using OrchardCore.Settings;
using SnailBee.CMS.Domain;
using SnailBee.CMS.Features.InitFeature.Responses;


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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaticData))]
    public async Task<IActionResult> Init()
    {
        var settings = await _siteService.GetSiteSettingsAsync();
        var contentItem = settings.As<ContentItem>(nameof(SnailBeeSettings));
        var staticData = contentItem.As<SnailBeeSettings>();

        var response = new StaticData(
            Info: new Info(
                Phone: staticData.Phone.Text,
                Email: staticData.Email.Text,
                Telegram: staticData.Telegram.Text,
                Title: staticData.AutomationDepartment.Text
            )
        );

        return Ok(response);
    }
}