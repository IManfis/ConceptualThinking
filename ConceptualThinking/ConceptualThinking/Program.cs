using System;
using System.Windows.Forms;
using ConceptualThinking.Model;
using ConceptualThinking.Student;

namespace ConceptualThinking
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new ConceptualThinkingContext())
            {
                if (!context.Database.Exists())
                {
                    context.Users.Add(new Users { Name = "admin", Group = 0, Password = "admin" });

                    context.Settings.Add(new Settings { Name = "Предъявлений1", Value = "20" });
                    context.Settings.Add(new Settings { Name = "Предъявлений2", Value = "20" });
                    context.Settings.Add(new Settings
                    {
                        Name = "Теория", 
                        Value = "          Понятийное мышление - это такое мышление,  пользуясь  которым  человек в процессе  решения  задачи  обращается  к  понятиям,   выполняет   действия  в  уме, непосредственно не имея дела с опытом, получаемым при помощи органов чувств.\n" +
                                "          Понятийное    мышление    нередко    называют    также    отвлеченным,    или абстрактным   мышлением,   хотя   это   не  совсем так: абстрактный (отвлеченный) характер может иметь не только понятное, но и образное мышление.\n" +
                                "          Понятийное   мышление   в  сравнении  с  наглядно-действенным  и  наглядно-образным  мышлением  -  более  поздний  этап  развития  мышления  как  в  истории человечества (в филогенезе), так и в процессе развития конкретного человека (в его онтогенезе).  Понятийное мышление не врожденно. Впрочем, некоторые простейшие логические конструкции у человека являются, похоже, врожденными.\n" +
                                "          Понятийное  мышление не развивается само по себе, оно развивается у детей в школьном  возрасте  (сначала в простейших формах) на основе их практического и наглядно-чувственного опыта."
                    });

                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Война", SeriesNotion = "(самолет, пушки, сражение, ружья, солдаты)", CorrectWord1 = "сражение", CorrectWord2 = "солдаты" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Чтение", SeriesNotion = "(глаза, книга, картина, печать, слово)", CorrectWord1 = "глаза", CorrectWord2 = "слово" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Сад", SeriesNotion = "(растения, садовник, собака, забор, земля)", CorrectWord1 = "растения", CorrectWord2 = "земля" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Сарай", SeriesNotion = "(сеновал, лошади, крыша, стены)", CorrectWord1 = "крыша", CorrectWord2 = "стены" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Река", SeriesNotion = "(берег, рыба, рыболов, тина, вода)", CorrectWord1 = "берег", CorrectWord2 = "вода" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Город", SeriesNotion = "(автомобиль, здание, толпа, улица, велосипед)", CorrectWord1 = "здание", CorrectWord2 = "улица" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Куб", SeriesNotion = "(углы, чертеж, сторона, камень, дерево)", CorrectWord1 = "углы", CorrectWord2 = "сторона" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Деление", SeriesNotion = "(делимое, карандаш, делитель, бумага)", CorrectWord1 = "делимое", CorrectWord2 = "делитель" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Игра", SeriesNotion = "(карты, игроки, штрафы, наказание, правила)", CorrectWord1 = "игроки", CorrectWord2 = "правила" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Кольцо", SeriesNotion = "(диаметр, алмаз, проба, круглость, печать)", CorrectWord1 = "диаметр", CorrectWord2 = "круглость" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Газета", SeriesNotion = "(правда, приложение, телеграмма, бумага, любовь, текст, редактор)", CorrectWord1 = "текст", CorrectWord2 = "редактор" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Книга", SeriesNotion = "(рисунок, война, бумага, любовь, текст)", CorrectWord1 = "бумага", CorrectWord2 = "текст" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Пение", SeriesNotion = "(звон, искусство, голос, аплодисменты, мелодия)", CorrectWord1 = "голос", CorrectWord2 = "мелодия" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Землетрясение", SeriesNotion = "(пожар, смерть, колебание, почва, шум)", CorrectWord1 = "колебание", CorrectWord2 = "почва" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Библиотека", SeriesNotion = "(город, книги, лекции, музыка, читатели)", CorrectWord1 = "книги", CorrectWord2 = "читатели" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Лес", SeriesNotion = "(лист, яблоня, охотник, дерево, волк)", CorrectWord1 = "лист", CorrectWord2 = "дерево" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Спорт", SeriesNotion = "(медаль, оркестр, состязание, победа, стадион)", CorrectWord1 = "состязание", CorrectWord2 = "победа" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Больница", SeriesNotion = "(помещение, сад, врач, радио, больные)", CorrectWord1 = "врач", CorrectWord2 = "больные" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Любовь", SeriesNotion = "(розы, чувство, человек, город, природа)", CorrectWord1 = "чувство", CorrectWord2 = "человек" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Патриотизм", SeriesNotion = "(город, друзья, родина, семья, человек)", CorrectWord1 = "родина", CorrectWord2 = "человек" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Факультет", SeriesNotion = "(кафедра, декан, здание, студент, улица)", CorrectWord1 = "декан", CorrectWord2 = "студент" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Оружие", SeriesNotion = "(танки, самолеты, хлопушки, пушки, железо)", CorrectWord1 = "танки", CorrectWord2 = "пушки" });
                    context.Experiment1Data.Add(new Experiment1Data { InitialNotion = "Овощи", SeriesNotion = "(огурец, свекла, арбуз, морковь, яблоко)", CorrectWord1 = "свекла", CorrectWord2 = "морковь" });

                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Испуг—бегство", CorrectAnswer = "причина — следствие" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Месть — поджог", CorrectAnswer = "род — вид" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Физика — наука", CorrectAnswer = "синонимы" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Десять — число", CorrectAnswer = "часть — целое" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Правильно — верно", CorrectAnswer = "синонимы" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Плакать — реветь", CorrectAnswer = "часть — целое" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Грядка — огород", CorrectAnswer = "антонимы" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Глава — роман", CorrectAnswer = "степень" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Пара — два", CorrectAnswer = "часть — целое" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Покой — движение", CorrectAnswer = "антонимы" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Слово — фраза", CorrectAnswer = "причина — следствие" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Смелость — геройство", CorrectAnswer = "род — вид" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Бодрый — вялый", CorrectAnswer = "степень" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Обман — недоверие", CorrectAnswer = "часть — целое" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Свобода — воля", CorrectAnswer = "антонимы" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Прохлада — мороз", CorrectAnswer = "степень" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Страна — город	", CorrectAnswer = "причина — следствие" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Пение — искусство", CorrectAnswer = "степень" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Похвала — брань", CorrectAnswer = "род — вид" });
                    context.Experiment2Data.Add(new Experiment2Data { PairNotions = "Тумбочка — шкаф", CorrectAnswer = "степень" });

                    context.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
