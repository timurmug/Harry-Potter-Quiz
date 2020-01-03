using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.QuizzesPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SixthTestPage : PopupPage
    {
        public static int CountCorrect = 0;
        int qindex;
        bool IsItTrue;

        public SixthTestPage (QuestionV6 question,int q)
		{
			InitializeComponent ();

            qindex = ++q;
            IsItTrue = question.IsItTrue;
            questionLabel.Text = question.question;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            backButton.IsEnabled = false;
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    {
                        await titleLabel.FadeTo(0, 250);
                        await title2Label.FadeTo(0, 250);
                        await contentStackLayout.TranslateTo(0, e.TotalY);
                        break;
                    }

                case GestureStatus.Completed:
                    {
                        if (contentStackLayout.TranslationY < 0)
                        {
                            if (IsItTrue)
                            {
                                //questionLabel.IsVisible=false;
                                frame.BorderColor = Color.Transparent;
                                questionLabel.TextColor = Color.Black;
                                frame.BackgroundColor = Color.LimeGreen;
                                CountCorrect++;
                            }
                            else
                            {
                                //questionLabel.IsVisible = false;
                                frame.BorderColor = Color.Transparent;
                                questionLabel.TextColor = Color.Black;
                                try
                                {
                                    if (App.IsVibrationOn)
                                        Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                                }
                                catch (Exception ex) { }
                                frame.BackgroundColor = Color.FromHex("A52A2A");
                            }
                        }
                        if (contentStackLayout.TranslationY > 0)
                        {
                            if (IsItTrue)
                            {
                                //questionLabel.IsVisible = false;
                                frame.BorderColor = Color.Transparent;
                                questionLabel.TextColor = Color.Black;
                                try
                                {
                                    if (App.IsVibrationOn)
                                        Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                                }
                                catch (Exception ex) { }
                                frame.BackgroundColor = Color.FromHex("A52A2A");
                            }
                            else
                            {
                                //questionLabel.IsVisible = false;
                                frame.BorderColor = Color.Transparent;
                                questionLabel.TextColor = Color.Black;
                                frame.BackgroundColor = Color.LimeGreen;
                                CountCorrect++;
                            }
                        }
                        await gridContent.FadeTo(0, 750);
                        if (qindex < MainPage.sixthList.Count)
                            await PopupNavigation.Instance.PushAsync(new SixthTestPage(MainPage.sixthList[qindex], qindex));
                        else
                        {
                            await PopupNavigation.Instance.PopAllAsync();
                            await PopupNavigation.Instance.PushAsync(new PopUpInEnd(6));
                        }
                        break;
                    }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Instructions6test());
        }
    }
}