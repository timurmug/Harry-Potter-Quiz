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
	public partial class SecondTestPage : PopupPage
    {
        public static int CountCorrect;
        string result = "";
        int qindex;
        string correctAnswerString;

        public SecondTestPage(QuestionV2 question, int q)
		{
			InitializeComponent ();
            qindex = ++q;
            questionLabel.Text = question.question;
            questionImage.Source = question.imageSource;
            correctAnswerString = question.answer;

            char[] charArr = correctAnswerString.ToCharArray();

            Random random = new Random();
            for (int i = 0; i < charArr.Count(); i++)
            {
                int j = random.Next(i + 1);
                var temp = charArr[j];
                charArr[j] = charArr[i];
                charArr[i] = temp;
            }
            foreach (char c in charArr)
            {
                CustomButton2 button = new CustomButton2
                {
                    Text = c.ToString(),
                    HeightRequest = 35,
                    WidthRequest = 35,
                     Margin=new Thickness(2.5),
                    BackgroundColor=Color.FromHex("#ffeed2")
                };
                buttonsFlexLayout.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as CustomButton2;
            var newbutton = new CustomButton2
            {
                Text = button.Text,
                HeightRequest = 35,
                WidthRequest = 35,
                Margin=new Thickness(2.5),
                BackgroundColor=Color.Peru
            };
            newbutton.Clicked += (s2, e2) =>
            {
                RemoveButtonInResult(newbutton,button);
            };
            button.BackgroundColor = Color.Transparent;
            button.Text = "";
            button.IsEnabled = false;

            resultFlexLayout.Children.Add(newbutton);
            result += newbutton.Text;
            ChangeResult(true);
        }

        void RemoveButtonInResult(CustomButton2 resultbutton, CustomButton2 answerbutton)
        {
            resultFlexLayout.Children.Remove(resultbutton);
            answerbutton.HeightRequest = 35;
            answerbutton.WidthRequest = 35;
            answerbutton.Margin = new Thickness(2.5);
            answerbutton.BackgroundColor = Color.FromHex("#ffeed2");
            answerbutton.Text = resultbutton.Text;
            answerbutton.IsEnabled = true;
            ChangeResult(false);
            
        }

        async void ChangeResult(bool isAdd)
        {
            if (isAdd)
            {
                if (result == correctAnswerString)
                {
                    CountCorrect++;
                    foreach (CustomButton2 c in resultFlexLayout.Children)
                    {
                        c.BorderColor = Color.LimeGreen;
                        c.BackgroundColor = Color.LimeGreen;
                    }
                    backButton.IsEnabled = false;
                    await gridContent.FadeTo(0, 500);
                    if (qindex < MainPage.secondList.Count)
                        await PopupNavigation.Instance.PushAsync(new SecondTestPage(MainPage.secondList[qindex], qindex));
                    else
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        await PopupNavigation.Instance.PushAsync(new PopUpInEnd(2));
                    }
                }
                else if (result.Count()== correctAnswerString.Count())
                {
                    try
                    {
                        if (App.IsVibrationOn)
                            Vibration.Vibrate(TimeSpan.FromSeconds(0.1));
                    }
                    catch (Exception ex) { }
                    foreach (CustomButton2 c in resultFlexLayout.Children)
                    {
                        c.BorderColor = Color.FromHex("A52A2A");
                        c.BackgroundColor = Color.FromHex("A52A2A");
                    }
                    backButton.IsEnabled = false;
                    await gridContent.FadeTo(0, 500);
                    if (qindex < MainPage.secondList.Count)
                        await PopupNavigation.Instance.PushAsync(new SecondTestPage(MainPage.secondList[qindex], qindex));
                    else
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        await PopupNavigation.Instance.PushAsync(new PopUpInEnd(2));
                    }
                }
            }
            else
            {
                result = "";
                foreach (CustomButton2 c in resultFlexLayout.Children)
                {
                    result += c.Text;
                }
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await gridContent.FadeTo(0, 250);
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}