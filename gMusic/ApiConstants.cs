using System;
namespace gMusic
{
    internal static class ApiConstants
    {
        public static string GoogleClientId = "";
        public static string GoogleClientSecret = "";

		public static string AppCenteriOS = "";

		public static string AppCenterAndroid = "";

		public static string AppCenterApiKey => $"ios={AppCenteriOS};android={AppCenterAndroid}";
	}
}
