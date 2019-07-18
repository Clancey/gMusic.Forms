using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace gMusic.UITests
{
    public class RootPage : BasePage
    {
        readonly Query mediaItemCell;
        readonly Query itemsListView;
        readonly Query moreDetailsButton;
        readonly Func<string,Query> moreDetailsMenuOption;
        readonly Func<string,Query> itemName;
        readonly Query sideNavigationMenu;
        readonly Func<string, Query> sideMenuOption;
        readonly Query miniPlayer;
        readonly Query gmusicTabBarButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("MainMasterDetailPage"),
            iOS = x => x.Marked("btn_MasterDetailPage")
        };

        public RootPage()
        {
            moreDetailsButton = x => x.Marked("ModeDetailsButton");
            moreDetailsMenuOption = option => x => x.Marked(option);
            itemName = name => x => x.Marked("MediaItemText").Text(name);
            sideNavigationMenu = x => x.Marked("SideNavigationMenu");
            sideMenuOption = name => x => x.Marked("MenuItemTitle").Text(name);
            miniPlayer = x => x.Marked("MiniPlayer");
            itemsListView = x => x.Marked("ItemsListView");
            gmusicTabBarButton = x => x.Marked("btn_MasterDetailPage");
        }

        //TODO : add logic to pick index from list 
        public RootPage OpenMoreDetailsButton(string menuOption)
        {
            app.WaitForElement(moreDetailsButton);
            app.Tap(moreDetailsButton);
            app.Screenshot("More Options Menu open");

            app.WaitForElement(moreDetailsMenuOption(menuOption));
            app.Tap(moreDetailsMenuOption(menuOption));
            return this;
        }

        public RootPage ListItem(string name)
        {
            app.WaitForElement(itemName(name));
            app.Tap(itemName(name));

            return this;
        }

        public RootPage SelectSideMenuOption(string optionName)
        {
            var list = app.Query(itemsListView);
            if(OnAndroid)
                {
                app.DragCoordinates((list[0].Rect.CenterX/10 - 50), list[0].Rect.CenterY, list[0].Rect.CenterX, list[0].Rect.CenterY); 
                }
            if (OniOS)
                app.Tap(gmusicTabBarButton);

            app.WaitForElement(sideNavigationMenu);

            app.ScrollDownTo(sideMenuOption(optionName));
            app.Tap(sideMenuOption(optionName));

            return this;
        }

        public void OpenNowPlaying()
        {
            var mini = app.Query(miniPlayer);
            var list = app.Query(itemsListView);
            if(OnAndroid)
                app.DragCoordinates(mini[0].Rect.CenterX, mini[0].Rect.CenterY, list[0].Rect.CenterX, (list[0].Rect.CenterY-150));
            if(OniOS)
                app.DragCoordinates(mini[0].Rect.CenterX, mini[0].Rect.CenterY, list[0].Rect.CenterX, (list[0].Rect.CenterY));
        }
    }
}
