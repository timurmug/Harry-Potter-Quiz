using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.QuizzesPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpInEnd : PopupPage
	{
		public PopUpInEnd (int testInt)
		{
			InitializeComponent ();
            if (testInt == 1)
            {
                SetImage(MainPage.firstList.Count, FirstTestPage.CountCorrect);
            }
            else if (testInt == 2)
                SetImage(MainPage.secondList.Count, SecondTestPage.CountCorrect);
            else if (testInt == 31)
            {
                frame.BackgroundColor = Color.FromHex("#004c29");
                Random random = new Random();
                switch (random.Next(2))
                {
                    case 0:
                        titleLabel.Text = "Жизни закончились.";
                        image.Source = "volandemort.png";
                        break;
                    case 1:
                        titleLabel.Text = "Ты не смог воспользоваться своими шансами.";
                        image.Source = "bellatrisa.png";
                        image.Margin = 0;
                        break;
                }
                resultLabel.Text = "Всего " +ThirdTestPage.CountCorrect + " из " + MainPage.thirdList.Count;
            }
            else if (testInt == 32)
                SetImage(MainPage.thirdList.Count, ThirdTestPage.CountCorrect);
            else if (testInt == 4)
                SetImage(MainPage.fourthList.Count, FourthTestPage.CountCorrect);
            else if (testInt == 5)
                SetImage(MainPage.fifthList.Count, FifthTestPage.CountCorrect);
            else if (testInt == 6)
                SetImage(MainPage.sixthList.Count, SixthTestPage.CountCorrect);

        }

        void SetImage(int all,int correct)
        {
            Random random = new Random();
            int percentCorrect = 100 / all * correct;

            if (percentCorrect <= 40)
            {
                frame.BackgroundColor = Color.FromHex("#004c29");
                switch (random.Next(2))
                {
                    case 0:
                        titleLabel.Text = "Плохо, мистер Поттер.";
                        image.Source = "snape.png";
                        break;
                    case 1:
                        titleLabel.Text = "В Министерстве такие работники не нужны.";
                        image.Source = "umbridge.png";
                        image.Margin = 0;
                        break;
                }
                if (percentCorrect == 0)
                    resultLabel.Text = "Все ответы неверны.";
                else
                    resultLabel.Text = "Только " + correct + " из " + all;
            }
            else if (percentCorrect > 40 && percentCorrect <=70)
            {
                frame.BackgroundColor = Color.FromHex("#820000");
                titleLabel.TextColor = Color.FromHex("#ffd2b4");
                resultLabel.TextColor = Color.FromHex("#ffd2b4");
                switch (random.Next(2))
                {
                    case 0:
                        titleLabel.Text = "Твои родители гордились бы тобой!";
                        image.Source = "black.png";
                        break;
                    case 1:
                        titleLabel.Text = "Неплохо, Гарри!";
                        image.Source = "hagrid.png";
                        break;
                }
                resultLabel.Text = "Правильно " + correct + " из " + all;
            }
            else if (percentCorrect > 70 && percentCorrect<=100)
            {
                frame.BackgroundColor = Color.FromHex("#820000");
                titleLabel.TextColor = Color.FromHex("#ffd2b4");
                resultLabel.TextColor = Color.FromHex("#ffd2b4");
                switch (random.Next(2))
                {
                    case 0:
                        titleLabel.Text = "Я верил в тебя!";
                        image.Source = "lupin.png";
                        break;
                    case 1:
                        titleLabel.Text = "Отлично, мистер Поттер.";
                        image.Source = "mcgonagall.png";
                        break;
                }
                if (percentCorrect == 100)
                    resultLabel.Text = "Все ответы были верными.";
                else
                    resultLabel.Text = "Почти все было правильно (" + correct + "/" + all+")";
            }
        }
    }
}