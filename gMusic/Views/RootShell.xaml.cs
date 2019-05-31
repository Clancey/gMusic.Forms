using System;
using System.Collections.Generic;
using System.Linq;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {

	static class NavigationItemExtension {
		public static FlyoutItem ToFlyoutItem (this NavigationItem item)
		{
			var flyout = new FlyoutItem {
				Title = item.Title,
				Icon = item.Image,
			};
			if (item.Page != null) {
				flyout.Items.Add (new ShellContent {
					Content = item.Page
				});
			}
			return flyout;
		}
	}

	public partial class RootShell : BottomDrawerShell {
		public List<NavigationItem> NavigationRootItems { get; set; } = new List<NavigationItem>
	   {
			new NavigationItem{Title = Strings.Search, Image = Images.Menu.SearchIcon, Page = new SearchPage()},
			new NavigationItem{Title = Strings.MusicLibraryHeading},
			new NavigationItem{Title = Strings.Artists, Page = new ArtistsPage(),Image = Images.Menu.ArtistIcon },
			new NavigationItem{Title = Strings.Album, Page = new AlbumsPage(), Image = Images.Menu.AlbumIcon },
			new NavigationItem{Title = Strings.Genres, Page = new GenresPage(), Image = Images.Menu.GenreIcon},
			new NavigationItem{Title = Strings.Songs, Page = new SongsPage(), Image = Images.Menu.SongsIcon},
			new NavigationItem{Title = Strings.Playlists, Page = new PlaylistsPage(), Image = Images.Menu.PlaylistIcon},
			new NavigationItem{Title = Strings.Settings, Page = new SettingsPage(),Image = Images.Menu.SettingsIcon },
			new NavigationItem {Title = Strings.CurrentPlaylist, Page = new CurrentPlaylistPage()},

		};
		public RootShell ()
		{
			InitializeComponent ();
			NavigationRootItems.Select (x => x.ToFlyoutItem()).ForEach (Items.Add);
		}
	}
}
