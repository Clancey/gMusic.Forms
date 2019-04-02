using System;
namespace gMusic {
	public class Spinner : IDisposable {

		public Spinner (string title)
		{
			Title = title;
		}

		public string Title { get; }

		public void Dispose ()
		{
			//TODO: Make this thing work for real
		}
	}
}
