using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace gMusic.UITests
{
    public class NowPlayingPage :BasePage
    {
        public Query ShuffleButton;
        public Query RepeatButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("NowPlayingPage"),
            iOS = x => x.Marked("NowPlayingPage")
        };

        public NowPlayingPage()
        {
            if (OnAndroid)
            {
            ShuffleButton = x => x.Marked("BottomControlsGrid").Child(4).Child(1);
                RepeatButton = x => x.Marked("BottomControlsGrid").Child(4).Child(2);
            }

            if(OniOS)
            {

            }
        }

        public NowPlayingPage PressShuffleButton()
        {
            app.WaitForElement(ShuffleButton);
            app.Tap(ShuffleButton);
            return this;
        }

        public NowPlayingPage PressRepeat()
        {
            app.WaitForElement(RepeatButton);
            app.Tap(RepeatButton);
            return this;
        }

    }
}
