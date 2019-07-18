using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace gMusic.UITests
{
    public class NowPlayingPage : BasePage
    {
        readonly Query thumbsDownButton;
        readonly Query previousButton;
        readonly Query playPauseButton;
        readonly Query nextButton;
        readonly Query thumbsUpButton;

        readonly Query shareButton;
        readonly Query shuffleButton;
        readonly Query repeatButton;
        readonly Query moreButton;

        readonly Query closeButton;
        readonly Query playlistButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("NowPlayingPage"),
            iOS = x => x.Marked("NowPlayingPage")
        };

        public NowPlayingPage()
        {
            thumbsDownButton = x => x.Marked("thumbsDownButton");
            previousButton = x => x.Marked("previousButton");
            playPauseButton = x => x.Marked("playPauseButton");
            nextButton = x => x.Marked("nextButton");
            thumbsUpButton = x => x.Marked("thumbsUpButton");

            shareButton = x => x.Marked("shareButton");
            shuffleButton = x => x.Marked("shuffleButton");
            repeatButton = x => x.Marked("repeatButton");
            moreButton = x => x.Marked("moreButton");

            closeButton = x => x.Marked("NavCloseButton");
            playlistButton = x => x.Marked("NavCurrentPlaylistButton");

            if (OnAndroid)
            {

            }

            if (OniOS)
            {

            }
        }

        public NowPlayingPage PressThumbsDown()
        {
            app.WaitForElement(thumbsDownButton);
            app.Tap(thumbsDownButton);
            return this;
        }

        public NowPlayingPage PressPrevious()
        {
            app.WaitForElement(previousButton);
            app.Tap(previousButton);
            return this;
        }

        public NowPlayingPage PressPausePlay()
        {
            app.WaitForElement(playPauseButton);
            app.Tap(playPauseButton);
            return this;
        }

        public NowPlayingPage PressNext()
        {
            //TODO: Add verification check Song title changed
            app.WaitForElement(nextButton);
            app.Tap(nextButton);
            return this;
        }

        public NowPlayingPage PressThumbsUp()
        {
            app.WaitForElement(thumbsUpButton);
            app.Tap(thumbsUpButton);
            return this;
        }

        public NowPlayingPage PressShare()
        {
            app.WaitForElement(shareButton);
            app.Tap(shareButton);
            return this;
        }

        public NowPlayingPage PressShuffleButton()
        {
            app.WaitForElement(shuffleButton);
            app.Tap(shuffleButton);
            return this;
        }

        public NowPlayingPage PressRepeat()
        {
            app.WaitForElement(repeatButton);
            app.Tap(repeatButton);
            return this;
        }

        public NowPlayingPage PressMore()
        {
            app.WaitForElement(moreButton);
            app.Tap(moreButton);
            return this;
        }

        public NowPlayingPage CloseNowPlaying()
        {
            app.WaitForElement(closeButton);
            app.Tap(closeButton);

            app.WaitForNoElement(closeButton);
            app.Screenshot("NowPlaying Closed");
            return this;
        }

        public NowPlayingPage OpenPlaylist()
        {
            app.WaitForElement(playlistButton);
            app.Tap(playlistButton);
            return this;
        }
    }
}
