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
    public partial class FourthTestPage : PopupPage
    {
        public static int CountCorrect = 0;
        int qindex;
        string correctAnswerString;

        public FourthTestPage(QuestionV4 question, int q)
        {
            InitializeComponent();
            qindex = ++q;
            questionLabel.Text = question.question;
            correctAnswerString = question.answer;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            answerEntry.Focus();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void AnswerEntry_Completed(object sender, EventArgs e)
        {
            backButton.IsEnabled = false;
            if (answerEntry.Text.ToLower() == correctAnswerString)
            {
                CountCorrect++;
                answerEntry.TextColor = Color.LimeGreen;
            }
               else
            {
                try
                {
                    if (App.IsVibrationOn)
                        Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                }
                catch (Exception ex) { }
                answerEntry.TextColor = Color.FromHex("A52A2A");
            }


            await gridContent.FadeTo(0, 750);
            if (qindex < MainPage.fourthList.Count)
                await PopupNavigation.Instance.PushAsync(new FourthTestPage(MainPage.fourthList[qindex], qindex));
            else
            {
                await PopupNavigation.Instance.PopAllAsync();
                await PopupNavigation.Instance.PushAsync(new PopUpInEnd(4));
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Hint(correctAnswerString));
        }
    }
}