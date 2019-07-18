using System;
// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace gMusic.UITests
{
    public class WelcomePage : BasePage
    {
        readonly Query loginButton;
        readonly Query skipButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("Login"),
            iOS = x => x.Marked("Login")
        };

        public WelcomePage()
        {
            loginButton = x => x.Marked("Login");
            skipButton = x => x.Marked("Skip");
            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        public void SkipLogin()
        {
            app.WaitForElement(skipButton);
            app.Tap(skipButton);
        }

        public void OpenLogin()
        {
            app.WaitForElement(loginButton);
            app.Tap(loginButton);
        }
    }
}
