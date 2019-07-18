using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using WebQuery = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppWebQuery>;

namespace gMusic.UITests
{
    public class LoginPage : BasePage
    {
        readonly WebQuery emailField;
        readonly WebQuery nextButton;
        readonly WebQuery passwordField;
        readonly WebQuery signInButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("Sign in"),
            iOS = x => x.Marked("Sign in")
        };

        public LoginPage()
        {
            emailField = x => x.Css("#Email");
            nextButton = x => x.Css("#next");
            passwordField = x => x.Css("#Passwd");
            signInButton = x => x.Css("#signIn");
        }

        public LoginPage EnterEmail(string email)
        {
            app.WaitForElement(emailField);
            app.Tap(emailField);
            app.EnterText(email);
            app.DismissKeyboard();
            app.Screenshot("Email Entered");

            app.Tap(nextButton);

            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            app.WaitForElement(passwordField);
            app.Tap(passwordField);
            app.EnterText(password);
            app.DismissKeyboard();
            app.Screenshot("Password Entered");

            return this;
        }

        public void SignIn()
        {
            app.WaitForElement(signInButton);
            app.Tap(signInButton);
        }

    }
}
