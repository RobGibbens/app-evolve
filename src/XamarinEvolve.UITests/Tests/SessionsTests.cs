using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace XamarinEvolve.UITests
{
    public class SessionsTests : AbstractSetup
    {
        public SessionsTests(Platform platform)
            : base (platform)
        {
        }

        //[TestCase("BunchORubbish", false)]
        //[TestCase("Xamarin.Forms", true)]
        //public void SearchSessions(string search, bool valid)
        //{
        //    new FeedPage().NavigateTo("Sessions");

        //    new SessionsPage()
        //        .EnterSearchAndVerify(search, valid);
        //}

        //[Test]
        //public void FilterSessions()
        //{
        //    new FeedPage().NavigateTo("Sessions");

        //    new SessionsPage()
        //        .GoToFilterSessionsPage();

        //    new FilterSessionsPage()
        //        .SelectSessionFilters(true, false)
        //        .SelectSessionCategories(
        //            DisplayAll:false,
        //            Android:false,
        //            iOS:false,
        //            XamarinForms:true,
        //            Design:false,
        //            Secure:true,
        //            Test:false,
        //            Monitor:false)
        //        .CloseSessionFilter();

        //    new SessionsPage();
        //}

        //[Test]
        //public void FavoriteSessionSignedOut()
        //{
        //    new FeedPage().NavigateTo("Sessions");

        //    new SessionsPage()
        //        .FavoriteFirstSession();
            
        //    new LoginPage()
        //        .EnterCredentials("xtc@xamarin.com", "fake")
        //        .TapLogin();

        //    new SessionsPage()
        //        .ValidateFavorite();
        //}

        //[Test]
        //public void FavoriteSessionSignedIn()
        //{
        //    SignIn();

        //    new SessionsPage()
        //        .FavoriteFirstSession();

        //    new SessionsPage()
        //        .ValidateFavorite();
        //}

        //[Test]
        //public void InvestigateSessionDetails()
        //{
        //    new FeedPage().NavigateTo("Sessions");

        //    new SessionsPage()
        //        .InvestigateFirstSession();

        //    new SessionsDetailsPage()
        //        .VerifyContentPresent();
        //}

        //[Test]
        //public void RateSessionSignedOut()
        //{
        //    new FeedPage().NavigateTo("Sessions");

        //    new SessionsPage()
        //        .InvestigateFirstSession();

        //    var page = new SessionsDetailsPage()
        //        .VerifyContentPresent()
        //        .RateThisSession();

        //    new LoginPage()
        //        .EnterCredentials("xtc@xamarin.com", "fake")
        //        .TapLogin();

        //    page.RateThisSession()
        //        .VerifyStarsIncrementally()
        //        .SubmitReview()
        //        .FeedbackReceived();
        //}        

        //[Test]
        //public void RateSessionSignedIn()
        //{
        //    SignIn();

        //    new SessionsPage()
        //        .InvestigateFirstSession();

        //    new SessionsDetailsPage()
        //        .VerifyContentPresent()
        //        .RateThisSession()
        //        .VerifyStarsIncrementally()
        //        .SubmitReview()
        //        .FeedbackReceived();
        //}

        [Test]
        public void NewTest()
        {
            app.Screenshot("First Load");
            app.Tap(x => x.Text("Not Now"));
            app.Screenshot("Clicked Not Now");
            app.Tap(x => x.Marked("OK"));
            app.Screenshot("Opened drawer");
            app.Tap(x => x.Text("Sessions"));
            app.Screenshot("Loaded sessions list");
            app.Tap(x => x.Text("Everyone can create beautiful apps with material design"));
            app.Screenshot("Selected session");
            app.Tap(x => x.Text("Head of Marketing, IBM"));
            app.Screenshot("Selected speaker");
            app.Tap(x => x.Class("ImageButton"));
            app.Screenshot("Back to session detail");
            app.ScrollDownTo("Rate this Session");
            app.Screenshot("Scrolled to Rate this Session button");
            app.Tap(x => x.Text("Rate this Session"));
            app.Screenshot("Clicked Rate this Session");
            app.WaitForElement(x => x.Class("ImageButton"));
            app.Tap(x => x.Class("ImageButton"));
            app.Screenshot("Clicked back");
        }




        //public void SignIn()
        //{
        //    if (OnAndroid)
        //    {
        //        new FeedPage()
        //            .NavigateTo("Settings");

        //        new SettingsPage()
        //            .TapSignIn();

        //        new LoginPage()
        //            .EnterCredentials("xtc@xamarin.com", "fake")
        //            .TapLogin();

        //        new SettingsPage()
        //            .ConfirmedLoggedIn()
        //            .NavigateTo("Sessions");
        //    }
        //    if (OniOS)
        //    {
        //        new FeedPage()
        //            .NavigateTo("Info");

        //        new InfoPage()
        //            .TapSignIn();

        //        new LoginPage()
        //            .EnterCredentials("xtc@xamarin.com", "fake")
        //            .TapLogin();

        //        new InfoPage()
        //            .ConfirmedLoggedIn()
        //            .NavigateTo("Sessions");
        //    }
        //}
    }
}

