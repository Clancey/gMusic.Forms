using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using gMusic.Managers;
using gMusic.Models;

namespace gMusic.ViewModels {
	public class CurrentPlaylistViewModel : BaseModel {

		public CurrentPlaylist Items { get; set; } = new CurrentPlaylist ();
		public CurrentPlaylistViewModel ()
		{
			NotificationManager.Shared.CurrentPlaylistChanged += Shared_CurrentPlaylistChanged;
		}

		private void Shared_CurrentPlaylistChanged (object sender, EventArgs e)
		{
			Items.ProcCollectionChanged ();
		}

		public class CurrentPlaylist : IList, INotifyCollectionChanged {


			FixedSizeDictionary<string, int> indexes = new FixedSizeDictionary<string, int> (20);
			public object this [int index] {
				get {
					var s = PlaybackManager.Shared.GetSong (index);
					indexes [s.Id] = index;
					return s;
 				}
				set => throw new NotImplementedException ();
			}

			public bool IsFixedSize => false;

			public bool IsReadOnly => true;

			public int Count => PlaybackManager.Shared.CurrentPlaylistSongCount;

			public bool IsSynchronized => false;

			public object SyncRoot => throw new NotImplementedException ();

			public event NotifyCollectionChangedEventHandler CollectionChanged;
			public void ProcCollectionChanged ()
			{
				indexes.Clear ();
				CollectionChanged?.Invoke (this, new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
			}
			

			public int Add (object value)
			{
				throw new NotImplementedException ();
			}

			public void Clear ()
			{
				throw new NotImplementedException ();
			}

			public bool Contains (object value)
			{
				throw new NotImplementedException ();
			}

			public void CopyTo (Array array, int index)
			{
				throw new NotImplementedException ();
			}

			public IEnumerator GetEnumerator ()
			{
				throw new NotImplementedException ();
			}

			public int IndexOf (object value) => value == null ? -1 : indexes[((Song)value).Id];

			public void Insert (int index, object value)
			{
				throw new NotImplementedException ();
			}

			public void Remove (object value)
			{
				throw new NotImplementedException ();
			}

			public void RemoveAt (int index)
			{
				throw new NotImplementedException ();
			}
		}
	}
}
