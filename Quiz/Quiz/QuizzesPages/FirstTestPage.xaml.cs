using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstTestPage : PopupPage
	{
        public static int CountCorrect = 0;
        int qindex;
        string correctAnswerString;

		public FirstTestPage(QuestionV1 question,int q)
		{
			InitializeComponent();
            qindex = ++q;
            questionLabel.Text = question.question;
            correctAnswerString = question.correct;

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = random.Next(i + 1);
                string temp = question.answeres[j];
                question.answeres[j] = question.answeres[i];
                question.answeres[i] = temp;
            }
            answer1.Text = question.answeres[0];
            answer2.Text = question.answeres[1];
            answer3.Text = question.answeres[2];
            answer4.Text = question.answeres[3];

        }

        private async void Answer_Clicked(object sender, EventArgs e)
        {
            buttonsGrid.IsEnabled = false;
            backButton.IsEnabled = false;
            var button = sender as Button;
            if (button.Text == correctAnswerString)
            {
                CountCorrect++;
                button.BackgroundColor = Color.LimeGreen;
            }
            else
            {
                try
                {
                    if (App.IsVibrationOn)
                        Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                }
                catch (Exception ex) { }
                button.BackgroundColor = Color.FromHex("A52A2A");
            }
            
            await gridContent.FadeTo(0, 500);
            if (qindex < MainPage.firstList.Count)
                await PopupNavigation.Instance.PushAsync(new FirstTestPage(MainPage.firstList[qindex], qindex));
            else
            {
                await PopupNavigation.Instance.PopAllAsync();
                await PopupNavigation.Instance.PushAsync(new PopUpInEnd(1));
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}