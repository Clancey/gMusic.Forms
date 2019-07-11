//using System;
//// Aliases Func<AppQuery, AppQuery> with Query
//using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

//namespace gMusic.UITests
//{
//    public class HomePage : BasePage
//    {
//        readonly Query deleteButton;
//        readonly Func<string, Query> checkMarkForTask;

//        protected override PlatformQuery Trait => new PlatformQuery
//        {
//            Android = x => x.Marked("menu_add_task"),
//            iOS = x => x.Marked("gMusic")
//        };

//        public HomePage()
//        {
//            if (OnAndroid)
//            {

//            }

//            if (OniOS)
//            {

//            }
//        }
//    }
//}



/***
 *
 * 
readonly Func<string, Query> menuItem = itemName => x => x.Marked(itemName);

public BasePage SelectMenuItem(string itemName)
{
    app.SwipeRightToLeft();
    app.WaitForElement(menuItem(itemName));
    app.Tap(menuItem(itemName));
    return this;
}

public void OpenNowPlaying()
{
    app.DragCoordinates(414, 830, 207, 448);
}
*
*
***/
