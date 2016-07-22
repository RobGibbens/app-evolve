using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinEvolve.DataObjects;
using XamarinEvolve.Clients.Portable;
using FormsToolkit;
using XLabs.Platform.Device;

namespace XamarinEvolve.Clients.UI
{
    public partial class SessionDetailsPage : ContentPage
    {
        SessionDetailsViewModel ViewModel => vm ?? (vm = BindingContext as SessionDetailsViewModel);
        SessionDetailsViewModel vm;
        public SessionDetailsPage(Session session, IDevice device)
        {
            InitializeComponent();


            FavoriteButtonAndroid.Clicked += (sender, e) => {
                Device.BeginInvokeOnMainThread (() => FavoriteIconAndroid.Grow ());
            };
            FavoriteButtoniOS.Clicked += (sender, e) => {
                Device.BeginInvokeOnMainThread (() => FavoriteIconiOS.Grow ());
            };

            ListViewSpeakers.ItemSelected += async (sender, e) => 
                {
                    var speaker = ListViewSpeakers.SelectedItem as Speaker;
                    if(speaker == null)
                        return;
                    
                    var speakerDetails = new SpeakerDetailsPage(vm.Session.Id, device);

                    speakerDetails.Speaker = speaker;
                    App.Logger.TrackPage(AppPage.Speaker.ToString(), speaker.FullName);
                    await NavigationService.PushAsync(Navigation, speakerDetails);
                    ListViewSpeakers.SelectedItem = null;
                };


			ButtonRate.Clicked += async (sender, e) =>
			{
				var title = this.ViewModel?.Session?.Title;
				Xamarin.Insights.Track("Rate Session", "SessionTitle", title);

				if (DemoHelper.ShouldThrowException 
				    //&& (device.Name == "iPhone 5S GSM" || device.Name == "iPhone 6") 
				    //&& device.FirmwareVersion == "9.3"
				   )
				{
					try
					{
						throw new NotSupportedException();
					}
					catch (Exception ex)
					{
						Xamarin.Insights.Report(ex);
						throw;
					}

				}

                    if(!Settings.Current.IsLoggedIn)
                    {
                        DependencyService.Get<ILogger>().TrackPage(AppPage.Login.ToString(), "Feedback");
                        MessagingService.Current.SendMessage(MessageKeys.NavigateLogin);
                        return;
                    }
                    await NavigationService.PushModalAsync(Navigation, new EvolveNavigationPage(new FeedbackPage(ViewModel.Session)));
            };
            BindingContext = new SessionDetailsViewModel(Navigation, session, device); 
            ViewModel.LoadSessionCommand.Execute(null);

        }

        void ListViewTapped (object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;
            if (list == null)
                return;
            list.SelectedItem = null;
        }

           

        void MainScroll_Scrolled (object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY > SessionDate.Y)
                Title = ViewModel.Session.ShortTitle;
            else
                Title = "Session Details";
        }

        protected override void OnAppearing()
        {
			var title = this.ViewModel?.Session?.Title;
			Xamarin.Insights.Track("SessionDetailsPage", new Dictionary<string, string> {
				{"SessionTitle", title }
			});

			base.OnAppearing();
            MainScroll.Scrolled += MainScroll_Scrolled;
            ListViewSpeakers.ItemTapped += ListViewTapped;


            var count = ViewModel?.Session?.Speakers?.Count ?? 0;
            var adjust = Device.OS != TargetPlatform.Android ? 1 : -count + 1;
            if((ViewModel?.Session?.Speakers?.Count ?? 0) > 0)
                ListViewSpeakers.HeightRequest = (count * ListViewSpeakers.RowHeight) - adjust;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainScroll.Scrolled -= MainScroll_Scrolled;
            ListViewSpeakers.ItemTapped -= ListViewTapped;
        }

        protected override  void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            vm = null;

            ListViewSpeakers.HeightRequest = 0;



        }
    }
}

