using Microsoft.Extensions.Localization;

namespace Globals.Resources
{
    public class Messages
    {
        private readonly IStringLocalizer<Messages> localizer;

        public Messages(IStringLocalizer<Messages> localizer) => this.localizer = localizer;

        public string HelloWorld => localizer[nameof(HelloWorld)];

        public string Welcome => localizer[nameof(Welcome)];

        public string Ask => localizer[nameof(Ask)];
    }
}