using System;
using System.Collections.Generic;

using Xamarin.Forms;
using gMusic.Models;
using gMusic.ViewModels;
using gMusic.Data;
using SimpleDatabase;
using gMusic.Views.Controls;
using System.Collections;
using gMusic.Managers;
using System.Collections.ObjectModel;
using Localizations;

namespace gMusic.Views
{
    public partial class AlbumDetailsPage : ContentPage
    {
        ObservableCollection<GroupedList> songs = new ObservableCollection<GroupedList>();
        public AlbumDetailsPage(Album album)
        {
            this.Title = album.Name;
            InitializeComponent();
            var groupInfo = new GroupInfo
            {
                From = "Song",
                Params = { { "@AlbumId", album.Id } },
                Filter = "AlbumId = @AlbumId",
                OrderBy = "Disc, Track"
            };

            songs.Add(new GroupedList(new SimpleDatabaseSource<Song>(Database.Main)
            {
                GroupInfo = groupInfo,
                IsGrouped = false,

            }));
            this.ListView.ItemsSource = songs;
            this.ListView.HasUnevenRows = true;
            this.ListView.Header = new SquareContentView(album);
            this.album = album;
        }
        bool hasLoaded;
        private readonly Album album;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadAdditionalSongs();
        }
        async void loadAdditionalSongs()
        {
            if (hasLoaded)
                return;
            try
            {
                var additionalSongs = await MusicManager.Shared.GetOnlineTracks(album);
                hasLoaded = true;
                if(additionalSongs.Count > 0)
                    songs.Add(new GroupedList(additionalSongs) { Section = Strings.AdditionalTracks});

            }
            catch (Exception ex)
            {
                LogManager.Shared.Report(ex);
            }
        }

        class GroupedList : IList
        {
            private readonly IList items;

            public GroupedList(IList items)
            {
                this.items = items;
            }

            public object this[int index] {
                get => items[index];
                set => items[index] = value;
            }

            public string Section { get; set; }

            public int Count => items.Count;

            public bool IsReadOnly => items.IsReadOnly;

            public bool IsFixedSize => items.IsFixedSize;

            public bool IsSynchronized => items.IsSynchronized;

            public object SyncRoot => items.SyncRoot;

            public int Add(object value) => items.Add(value);

            public void Clear() => items.Clear();

            public bool Contains(object value) => items.Contains(value);

            public void CopyTo(Array array, int index) => items.CopyTo(array, index);

            public int IndexOf(object value) => items.IndexOf(value);

            public void Insert(int index, object value) => items.Insert(index, value);

            public void Remove(object value) => items.Remove(value);

            public void RemoveAt(int index) => items.RemoveAt(index);

            IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
        }
    }
}
