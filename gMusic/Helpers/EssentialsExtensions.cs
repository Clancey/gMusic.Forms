using System;

namespace Xamarin.Essentials {
	public static class EssentialsExtensions {
		public static bool HasInternet (this NetworkAccess access) => access == NetworkAccess.Internet;
	}
}
