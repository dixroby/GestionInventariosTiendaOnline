namespace UserQuery.Authentication.Option;

public class AuthenticationOption
{
    public const string SectionKey = nameof(AuthenticationOption);
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int Minutes { get; set; }
}
