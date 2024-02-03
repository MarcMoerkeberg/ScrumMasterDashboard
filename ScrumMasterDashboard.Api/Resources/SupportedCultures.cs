using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace ScrumMasterDashboard.Api.Resources
{
	public static class SupportedCultures
	{
		private static readonly RequestCulture _defaultCulture = new RequestCulture("en-US");
		private static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo>
		{
			new CultureInfo("en-US"),
			new CultureInfo("da-DK"),
		};

		/// <summary>
		/// Returns the supported- and default cultures for requests as a <see cref="RequestLocalizationOptions"/> object.
		/// </summary>
		public static readonly RequestLocalizationOptions LocalizationOptions = new RequestLocalizationOptions
		{
			DefaultRequestCulture = _defaultCulture,
			SupportedCultures = _supportedCultures
		};
	}
}
