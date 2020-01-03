using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.PopUps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Hint : PopupPage
	{
		public Hint (string answer)
		{
			InitializeComponent ();

            Random random = new Random();
            int rnd = random.Next(6);
            switch (rnd)
            {
                case 0: image.Source = "granger2.png"; break;
                case 1: image.Source = "Ginny.png"; break;
                case 2: image.Source = "nevill.png"; break;
                case 3:
                    image.Source = "polumna.png";
                    frame.BackgroundColor = Color.FromHex("#083765");
                    phraseLabel.TextColor = Color.FromHex("#dacbb7");
                    break;
                case 4: image.Source = "ron.png"; break;
                case 5: image.Source = "twins.png"; break;
            }

            string[] textArray = answer.Split(new char[] { ' ' });
            if (textArray.Length > 1)
            {
                if (rnd == 5 && textArray.Length == 2)
                {
                    phraseLabel.Text = "Слов столько же, сколько и нас. Подсказка \"";
                    foreach (var t in textArray)
                        phraseLabel.Text += t.ToUpper()[0] + "..." + t[t.Length - 1] + " ";
                    phraseLabel.Text = phraseLabel.Text.TrimEnd();
                    phraseLabel.Text += "\"";
                }
                else
                {
                    switch (random.Next(2))
                    {
                        case 0:
                            phraseLabel.Text = "Так, тут " + textArray.Length + " слова. Ответ \"";
                            foreach (var t in textArray)
                                phraseLabel.Text += t.ToUpper()[0] + "..." + t[t.Length - 1] + " ";
                            phraseLabel.Text = phraseLabel.Text.TrimEnd();
                            phraseLabel.Text += "\"";
                            break;
                        case 1:
                            phraseLabel.Text = "Ответ \"";
                            foreach (var t in textArray)
                                phraseLabel.Text += t.ToUpper()[0] + "..." + t[t.Length - 1] + " ";
                            phraseLabel.Text = phraseLabel.Text.TrimEnd();
                            phraseLabel.Text += "\". Определенно, здесь " + textArray.Length + " слова.";
                            break;
                    }
                }
            }
            else
            {
                switch (random.Next(2))
                {
                    case 0:
                        phraseLabel.Text += "Хмм... Думаю, ответ \"" + answer.ToUpper()[0] + 
                            "..." + answer[answer.Length - 1] + "\". " + answer.Length;
                        switch (answer.Length)
                        {
                            case 1: phraseLabel.Text += " буква."; break;
                            case 2: case 3: case 4: phraseLabel.Text += " буквы."; break;
                            case 5: case 6: case 7: case 8: case 9: case 10:
                            case 11: case 12: case 13: case 14: case 15:
                                phraseLabel.Text += " букв."; break;
                        }
                        break;
                    case 1:
                        phraseLabel.Text += "В слове " + answer.Length;
                        switch (answer.Length)
                        {
                            case 1: phraseLabel.Text += " буква."; break;
                            case 2: case 3: case 4: phraseLabel.Text += " буквы."; break;
                            case 5: case 6: case 7:case 8: case 9:
                            case 10:case 11:case 12:case 13:case 14: case 15:
                                phraseLabel.Text += " букв."; break;
                        }
                        phraseLabel.Text +=" Точно! Ответ \"" + answer.ToUpper()[0] +
                            "..." + answer[answer.Length - 1] + "\".";
                        break;
                }
               

            }
        }
	}
}