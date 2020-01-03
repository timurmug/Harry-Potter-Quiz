using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.QuizzesPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FifthTestPage : PopupPage
    {
        public static int CountCorrect = 0;
        public static int CountHelp = 0;

        int qindex;
        QuestionV5 Question;

        public FifthTestPage (QuestionV5 question,int q)
		{
			InitializeComponent ();

            Question = question;
            qindex = ++q;
            questionLabel.Text = question.question;

            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                int j = random.Next(i + 1);
                string temp = question.answeres[j];
                question.answeres[j] = question.answeres[i];
                question.answeres[i] = temp;
            }

            foreach (Button button in buttonsGrid.Children)
            {
                button.Text = question.answeres[buttonsGrid.Children.IndexOf(button)];
            }

            //answer1.Text = question.answeres[0];
            //answer2.Text = question.answeres[1];
            //answer3.Text = question.answeres[2];
            //answer4.Text = question.answeres[3];
            //answer5.Text = question.answeres[4];
            //answer6.Text = question.answeres[5];
            //answer7.Text = question.answeres[6];
            //answer8.Text = question.answeres[7];

            if (CountHelp < 3)
                helpLabel.IsVisible = true;
            else
                helpLabel.IsVisible = false;
        }

        private async void Answer_Clicked(object sender, EventArgs e)
        {
            buttonsGrid.IsEnabled = false;
            backButton.IsEnabled = false;
            var button = sender as Button;
            if (button.Text == Question.correct)
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
            if (qindex < MainPage.fifthList.Count)
                await PopupNavigation.Instance.PushAsync(new FifthTestPage(MainPage.fifthList[qindex], qindex));
            else
            {
                await PopupNavigation.Instance.PopAllAsync();
                await PopupNavigation.Instance.PushAsync(new PopUpInEnd(5));
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            buttonsGrid.IsEnabled = false;
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (CountHelp < 3)
            {
                CountHelp++;
                await helpLabel.FadeTo(0, 250);
                var halfanswers = Question.deletehalfAnswers();
                foreach (Button button in buttonsGrid.Children)
                {
                    if (button.Text != halfanswers[0]
                        && button.Text != halfanswers[1]
                        && button.Text != halfanswers[2]
                        && button.Text != halfanswers[3])
                    {
                        await button.FadeTo(0, 250);
                        button.IsEnabled = false;
                    }
                }
            }
        }
    }
}