using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using SimpleDatabase;

namespace gMusic.ViewModels
{
	public class SimpleDatabaseSource<T> : IList, INotifyCollectionChanged where T : new()
	{
		public bool IsGrouped { get; set; } = true;
		public SimpleDatabaseSource(SimpleDatabaseConnection connection)
		{
			Database = connection;
		}
		public object this[int index] {
			get {
				try {
					//Debug.WriteLine ($"Loading {index}");
					if (IsGrouped)
						return new GroupedList<T> (Database, GroupInfo, index) {
							Display = Database?.SectionHeader<T> (GroupInfo, index) ?? "",
						};
					return Database != null ? Database.ObjectForRow<T> (GroupInfo, 0, index) : new T ();
				} catch (Exception ex) {
					Debug.WriteLine (ex);
					return new T ();
				}
			}

			set => throw new NotImplementedException ();
		}

		GroupInfo groupInfo;

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void ResfreshData()
		{
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
		}

		public GroupInfo GroupInfo
		{
			get { return groupInfo ?? (groupInfo =Database.GetGroupInfo<T>()); }
			set { 
				groupInfo = value;
				ResfreshData();
			}
		}

		public int Count => (IsGrouped ? Database?.NumberOfSections<T>(GroupInfo) : Database?.RowsInSection<T>(GroupInfo, 0)) ?? 0;

		public SimpleDatabaseConnection Database { get; set; }

		public bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

		public bool IsReadOnly => true;

		public bool IsSynchronized => throw new NotImplementedException ();

		public object SyncRoot => throw new NotImplementedException ();

		public int Add (object value) => throw new NotImplementedException ();

		public void Clear () => throw new NotImplementedException ();

		public bool Contains (object value) => throw new NotImplementedException ();

		public void CopyTo (Array array, int index) => throw new NotImplementedException ();

		public IEnumerator GetEnumerator () => throw new NotImplementedException ();

		public int IndexOf (object value) => throw new NotImplementedException ();

		public void Insert (int index, object value) => throw new NotImplementedException ();

		public void Remove (object value) => throw new NotImplementedException ();

		public void RemoveAt (int index) => throw new NotImplementedException ();


	}
	public class GroupedList<T> : IList where T : new()
	{
		public GroupedList(SimpleDatabaseConnection database, GroupInfo groupInfo, int section)
		{
			GroupInfo = groupInfo;
			Database = database;
			Section = section;
		}
		public GroupInfo GroupInfo { get; set; }

		public string Display { get; set; } = "";

		public SimpleDatabaseConnection Database { get; set; }
		public int Section { get; set; }

		public bool IsReadOnly => true;

		public bool IsFixedSize => true;

		public int Count => Database?.RowsInSection<T>(GroupInfo, Section) ?? 0;

		public object SyncRoot => throw new NotImplementedException ();

		public bool IsSynchronized => throw new NotImplementedException ();

		public object this[int index] {
			get {
				try {
					//Debug.WriteLine ($"Loading {Section}:{index}");
					var item = Database.ObjectForRow<T> (GroupInfo, Section, index);
					return item;
				} catch (Exception ex) {
					Debug.WriteLine (ex);
					return new T ();
				}
			}

			set => throw new NotImplementedException ();
		}

		public int Add (object value) => throw new NotImplementedException ();

		public bool Contains (object value) => throw new NotImplementedException ();

		public void Clear () => throw new NotImplementedException ();

        public int IndexOf(object value) => -1;

		public void Insert (int index, object value) => throw new NotImplementedException ();

		public void Remove (object value) => throw new NotImplementedException ();

		public void RemoveAt (int index) => throw new NotImplementedException ();

		public void CopyTo (Array array, int index) => throw new NotImplementedException ();

		public IEnumerator GetEnumerator () => throw new NotImplementedException ();
	}
}
