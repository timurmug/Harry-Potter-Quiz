using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Quiz.QuizzesPages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Settings;

namespace Quiz
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        //иконка и картинки для меню в фотошопе
        //тест на драг анд дроп  
        //тест правильную последовательность
        public static List<QuestionV1> firstList;
        public static List<QuestionV2> secondList;
        public static List<QuestionV1> thirdList;
        public static List<QuestionV4> fourthList;
        public static List<QuestionV5> fifthList;
        public static List<QuestionV6> sixthList;
        string[] musicFiles;

        public MainPage()
        {
            InitializeComponent();

            firstList = new List<QuestionV1>
            {
                new QuestionV1("Сколько детей было в семье Уизли?","7","8","5","6"),
                new QuestionV1("Какое животное изображено на гербе Когтеврана?","орел","лев","кентавр","змея"),
                new QuestionV1("Во что превратился боггарт проффесора Люпина?","Луну","Детементора","Снегга","Паука"),
                new QuestionV1("Патронус Гарри Поттера","олень","заяц","лось","кошка"),
                new QuestionV1("Заклинание Алохомора...","открывает двери",
                "выталкивает человека из воды","замораживает человека","убирает препятствие"),
                new QuestionV1("Как звали лучшего друга близнецов Уизли?","Ли Джордан","Оливер Вуд",
                "Симус Финниган","Сэдрик Диггори"),
                new QuestionV1("Крестный Гарри","Сириус Блэк","Римус Люпин",
                "Вернон Дурсль","Рубеус Хагрид"),
                new QuestionV1("Где Хагрид прячет обломок своей палочки?","в зонтике","в кармане",
                "в горшочке","в кольце"),
                new QuestionV1("Какие существа запряжены в кареты в Хогвартсе?","фестралы",
                "гиппогрифы","единороги","кентавры"),
                new QuestionV1("Сердцевина палочки Гарри","перо феникса","волос вейлы",
                "сердечная жила дракона","волос единорога"),
            };

            secondList = new List<QuestionV2>
            {
                new QuestionV2("Кто сыграл роль Гарри Поттера?", "Дэниэл Рэдклифф","harrypotter.jpg"),
                new QuestionV2("Талисман какого факультета барсук?", "Пуффендуй","coatofarms.jpg"),
                new QuestionV2("На гербе какого факультета изображена змея?", "Слизерин","coatofarms.jpg"),
                new QuestionV2("Призрак факультета Когтевран?", "Серая Дама","elena.jpg"),
                new QuestionV2("Существо, известное как \"король змей\"", "Василиск","vasilisk.jpg"),
                new QuestionV2("Тюрьма, созданная Грин-де-Вальдом", "Нурменгард","devald.jpg"),
                new QuestionV2("Заклинание защитной магии, отбивающее нападение противника", "Протего","protego.jpg"),
                new QuestionV2("Какое заклинание лишает воли и заставляет делать все, что угодно?", "Империо","imperio.jpg"),
                new QuestionV2("Что было на восьмом этаже Хогвартса?", "Выручай-комната","room.jpg"),
                new QuestionV2("Какой государственный орган часто фигурировал в мире Гарри Поттера?", "Министерство","ministry.jpg"),
           };

            thirdList = new List<QuestionV1>
            {
                new QuestionV1("Как звали одного из сыновей Гарри?","Альбус","Рубеус","Артур","Томас"),
                new QuestionV1("Чем торговал магазин \"Флориш и Блоттс\"?","школьными учебниками","сливочным пивом","метлами","темными артефактами"),
                new QuestionV1("Что завещал Дамблдор Гермионе?","сказки Барда Бидля","мантию","снитч","делюминатор"),
                new QuestionV1("Кто или что распределяло учеников на факультеты Хогвартса?","волшебная шляпа","заколдованный кубок","жребий","директор"),
                new QuestionV1("Как звали лучшего друга Дадли?","Пирс","Питер","Патрик","Пол"),
                new QuestionV1("Какой крестраж был уничтожен первым?","Дневник","Чаша","Кольцо","Диадема"),
                new QuestionV1("Как звали родителей Северуса Снегга?","Тобиас и Эйлин","Том и Лина","Джеймс и Лили","Фрэнк и Алиса"),
                new QuestionV1("Кто сменил Фаджа на посту?","Руфус Скримджер","Кингсли Бруствер","Долорес Амбридж","Пий Толстоватый"),
                new QuestionV1("Чары, применяющиеся как для причинения беспорядка в мыслях человека, так и для нарушения работы различных магических предметов.","Конфундус","Финита","Круцио","Криодос"),
                new QuestionV1("В волшебном мире больше известен как Лорд Волан-де-Морт.","Том Реддл","Северус Снегг","Салазар Слизерин","Марволо Мракс"),
                new QuestionV1("Финальная битва Второй магической войны, в которой сошлись все силы, сражавшиеся на стороне Волан-де-Морта, и силы, сражавшиеся против него","Битва за Хогвартс","Сражение в Министерстве магии","Битва в Запретном Лесу","Сражение за Хогсмид"),
                new QuestionV1("Была ближайшей помощницей лорда Волан-де-Морта и одним из его крестражей, созданным после убийства Берты Джоркинс.","Нагайна","Беллатриса","Норбертта","Рокала"),
            };

            fourthList = new List<QuestionV4>
            {
                new QuestionV4("Название четвертой книги: \"Гарри Поттер и ...\"","кубок огня"),
                new QuestionV4("Имя лучшего друга Альбуса Поттера","скорпиус"),
                new QuestionV4("Камень, который изредка можно найти в желудке козы, очень ценен, является сильным противоядием","безоар"),
                new QuestionV4("Заклинание, зажигающее огонёк света на конце волшебной палочки","люмос"),
                new QuestionV4("Имя автора книги \"Фантастические звери и места их обитания\"","ньют"),
                new QuestionV4("Фамилия преподавателя защиты от Темных искусств, которого назначил министр магии","амбридж"),
                new QuestionV4("Должность волшебника в министерстве магии, который специализируется на борьбе с тёмными магами","мракоборец"),
            };

            fifthList = new List<QuestionV5>
            {
                new QuestionV5("В скольких фильмах была экранизирована серия романов о Гарри Поттере","8","7","6","9","10","5","2","0"),
                new QuestionV5("Феникс Альбуса Дамблдора","Фоукс","Фикс","Фадж","Фраунс","Фенрир","Финиус","Фокус","Фенестр"),
                new QuestionV5("Домашний эльф Гарри Поттера","Кикимер","Добби","Похлеба","Винки","Хуки","Ямбо","Питтс","Кукенр"),
                new QuestionV5("Cущество, в спокойном состоянии похожее на прекрасную обворожительную женщину","Вейла","Феникс","Гиппогриф","Оборотень","Эльф","Гоблин","Вампир","Акромантул"),
                new QuestionV5("Сколько двойников Гарри отправилось из дома на Тисовой улице?","6","7","8","5","4","3","11","9"),
                new QuestionV5("Акромантул, которого приручил Хагрид","Арагог","Горара","Арахус","Грег","Мосаг","Твир","Аршеус","Арагорн"),
                new QuestionV5("Кто следит за чистотой и порядком в коридорах Хогвартса?","Аргус Филч","Северус Снег","Долорес Амбридж","Минерва Макгонагалл","Альбус Дамблдор","Гарри Поттер","Гораций Слизнорт","Живоглот"),
                new QuestionV5("Заместитель директора Школы Чародейства и Волшебства \"Хогвартс\"","Минерва Макгонагалл","Северус Снег","Долорес Амбридж","Аргус Филч","Альбус Дамблдор","Гораций Слизнорт","Филиус Флитвик","Помона Стебль"),
                new QuestionV5("Организация, основанная Альбусом Дамблдором для борьбы с лордом Волан-де-Мортом","Орден Феникса","Отряд Дамблдора","Министерство магии","Мракоборцы","Мародёры","Визенгамот","Пожирателями Смерти","Хогвартс"),
                new QuestionV5("Какая тварь была в кабинете Люпина, когда Гарри впервые оказался там?","Водяной чёрт","Боггарт","Дементор","Оборотень","Эльф","Акромантул","Гиппогриф","Вейла"),
            };

            sixthList = new List<QuestionV6>
            {
                new QuestionV6("Северус Снег был влюблен в Лили Эванс",true),
                new QuestionV6("Хозяин бузинной палочки после Дамблдора — Северус Снег",false),
                new QuestionV6("Пожиратели смерти — сообщество любимцев Горация Слизнорта,",false),
                new QuestionV6("Амортенция — очень мощное приворотное зелье",true),
                new QuestionV6("Отец Драко Малфоя — Абраксас Малфой",false),
                new QuestionV6("Лже-Грозным глазом Грюмом был Питер Петтигрю",false),
                new QuestionV6("Родители Невилла находятся в Больнице Святого Мунго",true),
                new QuestionV6("Жена Гарри Поттера — Джинни Уизли",true),
                new QuestionV6("Сердцевина палочки Гарри — сердечная жила дракона",false),
                new QuestionV6("Клювокрыл — гиппогриф, осужденный на казнь, но сбежавший с Сириусом Блэком благодаря Гарри и Гермионе ",true)
            };

            musicFiles = new string[]
            {
                "John Williams - Prologue.mp3",
                "John Williams - Entry Into the Great Hall and the Banquet.mp3",
                "John Williams - Harrys Wondrous World.mp3",
                "John Williams - Hogwarts Forever and the Moving Stairs.mp3",
                "John Williams - Mr. Longbottom Flies.mp3",
                "John Williams - The Norwegian Ridgeback and a Change of Season.mp3"
            };

            if (App.IsMusicOn)
            {
                musicImage.Source = "music.png";
                for (int i = 0; i < musicFiles.Length; i++)
                {
                    int j = random.Next(i + 1);
                    var temp = musicFiles[j];
                    musicFiles[j] = musicFiles[i];
                    musicFiles[i] = temp;
                }
                DependencyService.Get<IAudio>().PlayAudioFiles(musicFiles);
            }
            else
                musicImage.Source = "musicOFF.png";

            if (App.IsVibrationOn)
                vibrationImage.Source = "vibration.png";
            else
                vibrationImage.Source = "vibrationOFF.png";
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < firstList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = firstList[j];
                firstList[j] = firstList[i];
                firstList[i] = temp;
            }
            FirstTestPage.CountCorrect = 0;
            await PopupNavigation.Instance.PushAsync(new FirstTestPage(firstList[0], 0));
        }

        private async void Start2_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < secondList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = secondList[j];
                secondList[j] = secondList[i];
                secondList[i] = temp;
            }
            SecondTestPage.CountCorrect = 0;
            await PopupNavigation.Instance.PushAsync(new SecondTestPage(secondList[0],0));
        }

        private async void Start3_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < thirdList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = thirdList[j];
                thirdList[j] = thirdList[i];
                thirdList[i] = temp;
            }
            ThirdTestPage.CountCorrect = 0;
            ThirdTestPage.CountMistakes = 0;
            await PopupNavigation.Instance.PushAsync(new ThirdTestPage(thirdList[0], 0));
        }

        private async void Start4_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < fourthList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = fourthList[j];
                fourthList[j] = fourthList[i];
                fourthList[i] = temp;
            }
            FourthTestPage.CountCorrect = 0;
            await PopupNavigation.Instance.PushAsync(new FourthTestPage(fourthList[0], 0));
        }

        private async void Start5_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < fifthList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = fifthList[j];
                fifthList[j] = fifthList[i];
                fifthList[i] = temp;
            }
            FifthTestPage.CountCorrect = 0;
            FifthTestPage.CountHelp = 0;
            await PopupNavigation.Instance.PushAsync(new FifthTestPage(fifthList[0],0));
        }

        private async void Start6_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < sixthList.Count; i++)
            {
                int j = random.Next(i + 1);
                var temp = sixthList[j];
                sixthList[j] = sixthList[i];
                sixthList[i] = temp;
            }
            SixthTestPage.CountCorrect = 0;
            await PopupNavigation.Instance.PushAsync(new SixthTestPage(sixthList[0],0));
        }

        private void Music_Tapped(object sender, EventArgs e)
        {
            if (App.IsMusicOn)
            {
                App.IsMusicOn = false;
                musicImage.Source = "musicOFF.png";
                DependencyService.Get<IAudio>().StopPlaying();
            }
            else
            {
                App.IsMusicOn = true;
                musicImage.Source = "music.png";
                for (int i = 0; i < musicFiles.Length; i++)
                {
                    int j = random.Next(i + 1);
                    var temp = musicFiles[j];
                    musicFiles[j] = musicFiles[i];
                    musicFiles[i] = temp;
                }
                DependencyService.Get<IAudio>().PlayAudioFiles(musicFiles);
            }
            CrossSettings.Current.AddOrUpdateValue("IsMusicOn", App.IsMusicOn);
        }

        private void Vibration_Tapped(object sender, EventArgs e)
        {
            if (App.IsVibrationOn)
            {
                App.IsVibrationOn = false;
                vibrationImage.Source = "vibrationOFF.png";
            }
            else
            {
                App.IsVibrationOn = true;
                vibrationImage.Source = "vibration.png";
            }
            CrossSettings.Current.AddOrUpdateValue("IsVibrationOn", App.IsVibrationOn);
        }
    }
}
