//using System;
//using NUnit.Framework;
//using Xamarin.UITest;

//namespace gMusic.UITests
//{
//    public class SettingsTest : BaseTestFixture
//    {
//        public SettingsTest(Platform platform)
//            : base(platform)
//        {
//        }

//        [Test]
//        public void Repl()
//        {
//            if (TestEnvironment.IsTestCloud)
//                Assert.Ignore("Local only");

//            app.Repl();
//        }

//        [TestCase("Settings")]
//        [TestCase("Artists")]
//        public void SettingsPageTest(string menuItem)
//        {
//            new HomePage()
//                 .SelectMenuItem(menuItem);

//            app.Repl();
//        }
//    }
//}
