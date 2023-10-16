namespace SnailBee.CMS.Features.InitFeature.Responses;

public record Info(string Phone, string Email, string Telegram, string Title);

public record StaticData(Info Info);