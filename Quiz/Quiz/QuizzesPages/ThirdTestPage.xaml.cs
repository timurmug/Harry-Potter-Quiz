using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.QuizzesPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThirdTestPage : PopupPage
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public static int CountCorrect = 0;
        public static int CountMistakes = 0;
        int timer = 0;
        int qindex;
        string correctAnswerString;

        public ThirdTestPage (QuestionV1 question, int q)
		{
			InitializeComponent ();

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

            CancellationToken token = cts.Token;
            DisplayTimeAsync(token);

            if (CountMistakes == 1)
                (livesStackLayout.Children[0] as Image).IsVisible=false;
            else if (CountMistakes == 2)
            {
                (livesStackLayout.Children[0] as Image).IsVisible = false;
                (livesStackLayout.Children[1] as Image).IsVisible = false;
            }
        }
        
        async void DisplayTimeAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if ((timer < 8))
                {
                    timerButton.Text = timer.ToString();
                    timer++;
                    await Task.Delay(1000);
                }
                else
                {
                    buttonsGrid.IsEnabled = false;
                    try
                    {
                        if (App.IsVibrationOn)
                            Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                    }
                    catch (Exception ex) { }
                    (livesStackLayout.Children[CountMistakes] as Image).IsVisible = false;
                    CountMistakes++;
                    await gridContent.FadeTo(0, 500);

                    if (CountMistakes < 3)
                    {
                        await PopupNavigation.Instance.PushAsync(new ThirdTestPage(MainPage.thirdList[qindex], qindex));
                    }
                    else
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        await PopupNavigation.Instance.PushAsync(new PopUpInEnd(31));
                    }
                    cts.Cancel();
                }
            }
        }

        private async void Answer_Clicked(object sender, EventArgs e)
        {
            cts.Cancel();
            buttonsGrid.IsEnabled = false;
            backButton.IsEnabled = false;
            var button = sender as Button;
            if (button.Text == correctAnswerString)
            {
                CountCorrect++;
                button.BackgroundColor = Color.LimeGreen;
                await gridContent.FadeTo(0, 500);
                if (qindex < MainPage.thirdList.Count)
                    await PopupNavigation.Instance.PushAsync(new ThirdTestPage(MainPage.thirdList[qindex], qindex));
                else
                {
                    await PopupNavigation.Instance.PopAllAsync();
                    await PopupNavigation.Instance.PushAsync(new PopUpInEnd(32));
                }
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
                (livesStackLayout.Children[CountMistakes] as Image).IsVisible = false;
                CountMistakes++;
                await gridContent.FadeTo(0, 500);

                if (qindex < MainPage.thirdList.Count)
                {
                    if (CountMistakes < 3)
                        await PopupNavigation.Instance.PushAsync(new ThirdTestPage(MainPage.thirdList[qindex], qindex));
                    else
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        await PopupNavigation.Instance.PushAsync(new PopUpInEnd(31));
                    }
                }
                else
                {
                    await gridContent.FadeTo(0, 500);
                    await PopupNavigation.Instance.PopAllAsync();
                    await PopupNavigation.Instance.PushAsync(new PopUpInEnd(32));
                }
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            cts.Cancel();
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}