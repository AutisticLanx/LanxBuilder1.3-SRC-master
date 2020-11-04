using System.ComponentModel;

namespace lanx1337
{
    public enum DownloadPayloadResult
    {
        [Description("None")]
        None = 0,

        [Description("Valid")]
        Valid,

        [Description("Invalid URL")]
        InvalidURL,

        [Description("Invalid .NET Assembly")]
        InvalidNETAssembly,

        [Description("Could not load Assembly")]
        InvalidAssembly,
    }
}
//junk codes nothing to see here  zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz