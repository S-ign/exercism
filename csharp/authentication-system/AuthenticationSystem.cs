using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    public Identity Admin { get; }

    public Authenticator(Identity admin)
    {
        this.Admin = admin;

        var devs = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = EyeColor.Blue
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = EyeColor.Brown
            }
        };

        developers = new ReadOnlyDictionary<string, Identity>(devs);
    }

    private readonly IDictionary<string, Identity> developers;
    public IDictionary<string, Identity> GetDevelopers() => developers;


}

public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}
