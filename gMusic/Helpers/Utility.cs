using System;
using gMusic.Managers;
using Xamarin.Essentials;

namespace gMusic
{
	public static class Utility {
		public static async void SetSecured(string key, string value)
		{
			try {
				await SecureStorage.SetAsync (key, value);
			} catch (Exception ex) {
				LogManager.Shared.Report (ex);
				// Possible that device doesn't support secure storage on device.
			}
		}
		public static string GetSecured(string key)
		{
			try {
				var value = SecureStorage.GetAsync (key).Result;
				return value;
			} catch (Exception ex) {
				// Possible that device doesn't support secure storage on device.
				return null;
			}
		}
		public static bool IsSimulator { get; set; }
		public static string DeviceId {
			get {
				if (IsSimulator)
					return "58B5F896-3C78-4A19-9BA4-8D98DB7D1149";

				var id = GetSecured ("GoogleDeviceId");
				if (string.IsNullOrWhiteSpace (id)) {
					id = "ios:" + Guid.NewGuid ().ToString ();
					SetSecured ("GoogleDeviceId", id);
				}
				if (!id.StartsWith ("ios:"))
					id = "ios:" + id;
				return id;
			}
		}

		public static string DeviceName { get; set; }
	}
}
