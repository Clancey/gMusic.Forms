using System;
using System.Collections.Generic;
using Localizations;
using Xamarin;
using Xamarin.Forms;
using gMusic.Views;
using gMusic.ViewModels;
using gMusic.Data;
using System.Linq;
using gMusic.Managers;

namespace gMusic
{
    public class RootPage
    {
        public List<NavigationItem> Items { get; set; } = new List<NavigationItem>
        {
            new NavigationItem{Title = Strings.Search, Image = Images.Menu.SearchIcon},
            new NavigationItem{Title = Strings.MusicLibraryHeading},
			new NavigationItem{Title = Strings.Artists, Page = new NavigationPage(new ArtistsPage()),Image = Images.Menu.ArtistIcon },
			new NavigationItem{Title = Strings.Album, Page = new NavigationPage(new AlbumsPage()), Image = Images.Menu.AlbumIcon },
			new NavigationItem{Title = Strings.Genres, Page = new NavigationPage(new GenresPage()), Image = Images.Menu.GenreIcon},
			new NavigationItem{Title = Strings.Songs, Page = new NavigationPage(new SongsPage()), Image = Images.Menu.SongsIcon},
			new NavigationItem{Title = Strings.Playlists, Page = new NavigationPage(new PlaylistsPage()), Image = Images.Menu.PlaylistIcon},
			//new MenuItem(Strings.Search,"SVG/search.svg",20,new SearchPage()){SaveIndex = false},
			////new NavigationHeaderItem("my music"),
			//new NavigationItem(Strings.Artists, "SVG/artist.svg", new ArtistsPage()),
			//new NavigationItem(Strings.Albums, "SVG/album.svg",new AlbumsPage()),

		};
        public RootPage()
        {
            Root = Xamarin.Forms.Device.OS == TargetPlatform.Android ? CreateAndroidRoot() : CreateIosRoot();

			if (ApiManager.Shared.Count > 0)
				return;
			Root.Navigation.PushModalAsync (new WelcomePage ());
            //MasterDetail.Master.Icon = new SvgImageSource { SvgName = Images.MenuIconName, MaxSize = 15f };
			
        }

        Page CreateIosRoot()
        {
            return SlideUpPanel = new SlideUpPanel
            {
                Master = new NowPlayingPage { Title = "gMusic" },
                Detail = (MasterDetail = new MasterDetailPage
                {
                    Title = "gMusic",
                    Master = new SideNavigationPage { BindingContext = this },
                    Detail = GetInitialPage(),
                }),
            };
        }

        Page CreateAndroidRoot()
        {
            return MasterDetail = new MasterDetailPage
            {
                Master = new SideNavigationPage { BindingContext = this },
                Detail = (SlideUpPanel = new SlideUpPanel
                {
                    Master = new NowPlayingPage { Title = "gMusic" },
                    Detail = GetInitialPage(),
                }),
            };
        }

        Page GetInitialPage() => Items[Settings.CurrentMenuIndex].Page ?? Items.Select(x => x.Page).FirstOrDefault(x => x != null);

        public static implicit operator Page(RootPage r)
        {
            return r.Root;
        }

        SlideUpPanel SlideUpPanel;
        MasterDetailPage MasterDetail;

        public MasterDetailPage ContentMasterDetail => Xamarin.Forms.Device.OnPlatform(MasterDetail, SlideUpPanel, MasterDetail);

        public Page Root { get; set; }

        public Page NowPlayingPage { get; set; }

        public void Navigate(NavigationItem item)
        {
            if (item?.Page == null)
                return;
            ContentMasterDetail.Detail = item.Page;
            MasterDetail.IsPresented = false;
        }
    }
}
