using Microsoft.Extensions.Localization;

namespace COSMO.API.Resources
{
    public interface ICommonResource
    {
        string SavedSuccessfully { get; }

        string UnExpectedError { get; }

        string InvalidUser { get; }


    }

    public class CommonResource : ICommonResource
    {
        private readonly IStringLocalizer<CommonResource> _localizer;

        public CommonResource(IStringLocalizer<CommonResource> localizer) =>
            _localizer = localizer;

        public string SavedSuccessfully => GetString(nameof(SavedSuccessfully));

        public string UnExpectedError => GetString(nameof(UnExpectedError));

        public string InvalidUser => GetString(nameof(InvalidUser));


        private string GetString(string name) =>
            _localizer[name];
    }
}
