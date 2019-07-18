using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace gMusic.UITests
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
                Assert.Ignore("Local only");

            app.Repl();
        }

        [Test]
        [Ignore("Already signed in")]
        public void LogInTest()
        {
            new WelcomePage()
                .OpenLogin();

            new LoginPage()
                    .EnterEmail(TestConstants.userEmail)
                    .EnterPassword(TestConstants.userPassword)
                    .SignIn();

            new RootPage();
        }

        [Test]
        public void SongPlayTest()
        {
            new RootPage()
                .OpenMoreDetailsButton("Play")
                .OpenNowPlaying();

            new NowPlayingPage()
                .CloseNowPlaying();

            new RootPage();
        }

        [Test]
        public void NowPlayingTest()
        {
            new RootPage()
                .OpenMoreDetailsButton("Play")
                .OpenNowPlaying();

            new NowPlayingPage()
                .PressNext()
                .PressShuffleButton()
                .PressThumbsUp()
                .CloseNowPlaying();

            new RootPage();
        }

        [Test]
        [TestCase("Queen")]
        [TestCase("Vulfpeck")]
        public void SearchTest(string SongSearchName)
        {
            new RootPage()
                .SelectSideMenuOption("Search");

            new SearchPage()
                .SearchSong(SongSearchName)
                .VerifySearchResults();
        }

        [Test]
        [Category("regression")]
        public void PlayPauseTest()
        {
            new RootPage()
               .OpenMoreDetailsButton("Play")
               .OpenNowPlaying();

            new NowPlayingPage()
                .PressPausePlay();
        }
    }
}
