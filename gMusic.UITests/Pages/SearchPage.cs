using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace gMusic.UITests
{
    public class SearchPage : RootPage
    {
        readonly Query searchBarField;
        readonly Func<string, Query> searchResultTabBar;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SearchPage"),
            iOS = x => x.Marked("SearchPage")
        };

        public SearchPage()
        {
            searchBarField = x => x.Marked("SearchBarField");
            searchResultTabBar = tabName => x => x.Marked("SearchResultPageHeader").Text(tabName);
        }

        public SearchPage SearchSong(string songName)
        {
            app.WaitForElement(searchBarField);
            app.Tap(searchBarField);
            app.EnterText(songName);
            app.PressEnter();

            app.Screenshot($"Searched for value : {songName}");
            return this;
        }

        public SearchPage ChangeResultsTab(string tabName)
        {
            app.Tap(searchResultTabBar(tabName));
            app.Screenshot($"Tab changed to : {tabName}");

            return this;
        }

        public SearchPage VerifySearchResults()
        {
            ChangeResultsTab("Local");
            app.Screenshot("Local Results");

            ChangeResultsTab("Google");
            app.Screenshot("Google Results");

            return this;
        }
    }
}
