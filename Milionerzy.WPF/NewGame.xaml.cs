using Milionerzy.Logic;
using Milionerzy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milionerzy.WPF
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : UserControl
    {
        private Game game;
        private int selectedAnswer = -1;
        private bool gameContinue = true;
        private string name;
        public NewGame(string name)
        {
            InitializeComponent();
            this.name = name;
            List<Question> q = RWQuestions.loadQuestions();
            game = new Game(q);
            loadQuestion(game.getQuestion());
            changeColorLabel(0);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Message message = new Message();
            if (message.ShowDialog() == true)
            {
                int money = game.endOfGame(false);
                MessagePeople m = new MessagePeople();
                m.message.Text = "Gratulacje " + name + "!!!";
                m.message.Text += "\n Wygrałeś: " + money + " zł";
                m.ShowDialog();
                MainWindow.mainPanel.Children.Clear();
                MainWindow.mainPanel.Children.Add(new Menu(name));
                RWResults.writeResults(name, money);
            }

        }
        private void loadQuestion(Question question)
        {
            quest.Content = question.Content;
            A.Content = "A: " + question.Answers[0];
            B.Content = "B: " + question.Answers[1];
            C.Content = "C: " + question.Answers[2];
            D.Content = "D: " + question.Answers[3];
        }
        private void Answer(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            ClearButtons();
            ((Button)sender).Style = (Style)this.TryFindResource("RoundedButtonStyle2");
            ((Button)sender).Foreground = (Brush)bc.ConvertFrom("#002F7F");
            if (((Button)sender).Name == "A")
                selectedAnswer = 0;
            if (((Button)sender).Name == "B")
                selectedAnswer = 1;
            if (((Button)sender).Name == "C")
                selectedAnswer = 2;
            if (((Button)sender).Name == "D")
                selectedAnswer = 3;

        }
        private void ClearButtons()
        {
            var bc = new BrushConverter();
            A.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            B.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            C.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            D.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            A.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            B.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            C.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            D.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            if (selectedAnswer != -1)
            {
                ClearButtons();
                gameContinue = game.checkAnswer(selectedAnswer);
                selectedAnswer = -1;
                if (gameContinue == true)
                {
                    if (game.currentLevel == 12)
                    {
                        int money = game.endOfGame(false);
                        MessagePeople m = new MessagePeople();
                        m.message.Text = "Gratulacje " + name + "!!!";
                        m.message.Text += "\n Wygrałeś: " + money + " zł";
                        m.ShowDialog();
                        RWResults.writeResults(name, money);
                        MainWindow.mainPanel.Children.Clear();
                        MainWindow.mainPanel.Children.Add(new Menu(name));
                        return;
                    }
                    loadQuestion(game.getQuestion());
                    changeColorLabel(game.currentLevel);
                    A.IsEnabled = true;
                    B.IsEnabled = true;
                    C.IsEnabled = true;
                    D.IsEnabled = true;
                }
                else
                {
                    int money = game.endOfGame(true);
                    MessagePeople m = new MessagePeople();
                    m.message.Text = "Niestety " + name + ", to zła odpowiedź.";
                    m.message.Text += "\n Wygrałeś: " + money + " zł";
                    m.ShowDialog();
                    RWResults.writeResults(name, money);
                    MainWindow.mainPanel.Children.Clear();
                    MainWindow.mainPanel.Children.Add(new Menu(name));
                }
            }
            else
            {
                MessageBox.Show("Prosze zaznaczyc odpowiedz");
            }
        }

        private void changeColorLabel(int number)
        {
            var bc = new BrushConverter();
            if (number > 0)
            {
                ((Label)gridLabel.FindName("label" + (number - 1))).Background = (Brush)bc.ConvertFrom("#002F7F");
                ((Label)gridLabel.FindName("label" + (number - 1))).Foreground = (Brush)bc.ConvertFrom("#DBBC2E");

            }
            ((Label)gridLabel.FindName("label" + number)).Background = (Brush)bc.ConvertFrom("Gold");
            ((Label)gridLabel.FindName("label" + number)).Foreground = (Brush)bc.ConvertFrom("#002F7F");
        }

        private void fityfifty(object sender, RoutedEventArgs e)
        {
            if (game.fiftyFifty == false)
            {
                fiftyfiftybutton.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/bin/debug/not50.jpg")));
                A.Content = string.Empty;
                B.Content = string.Empty;
                C.Content = string.Empty;
                D.Content = string.Empty;
                game.fiftyFiftyFunction();
                var reject1 = game.getQuestion().Reject1;
                var reject2 = game.getQuestion().Reject2;
                if (reject1 == 0 && reject2 == 1)
                {
                    A.IsEnabled = false;
                    B.IsEnabled = false;
                    C.Content = "C: " + game.getQuestion().Answers[2];
                    D.Content = "D: " + game.getQuestion().Answers[3];
                }
                if (reject1 == 0 && reject2 == 2)
                {
                    A.IsEnabled = false;
                    B.Content = "B: " + game.getQuestion().Answers[1];
                    C.IsEnabled = false;
                    D.Content = "D: " + game.getQuestion().Answers[3];
                }
                if (reject1 == 0 && reject2 == 3)
                {
                    A.IsEnabled = false;
                    B.Content = "B: " + game.getQuestion().Answers[1];
                    C.Content = "C: " + game.getQuestion().Answers[2];
                    D.IsEnabled = false;
                }
                if (reject1 == 1 && reject2 == 2)
                {
                    A.Content = "A: " + game.getQuestion().Answers[0];
                    B.IsEnabled = false;
                    C.IsEnabled = false;
                    D.Content = "D: " + game.getQuestion().Answers[3];
                }
                if (reject1 == 1 && reject2 == 3)
                {
                    A.Content = "A: " + game.getQuestion().Answers[0];
                    B.IsEnabled = false;
                    C.Content = "C: " + game.getQuestion().Answers[2];
                    D.IsEnabled = false;
                }
                if (reject1 == 2 && reject2 == 3)
                {
                    A.Content = "A: " + game.getQuestion().Answers[0];
                    B.Content = "B: " + game.getQuestion().Answers[1];
                    C.IsEnabled = false;
                    D.IsEnabled = false;
                }
            }
        }

        private void changeQuestion(object sender, RoutedEventArgs e)
        {
            if (game.changeQuestion == false)
            {
                refreshbutton.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/bin/debug/notrefresh.jpg")));
                game.changeQuestionFunction();
                loadQuestion(game.getQuestion());
            }
        }

        private void peopleQuestion(object sender, RoutedEventArgs e)
        {
            if (game.publicQuestion == false)
            {
                peoplebutton.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/bin/debug/notpeople.jpg")));
                int[] publicAnswer = game.publicQuestionFunction();
                MessagePeople m = new MessagePeople();
                m.message.Text = "A: " + publicAnswer[0] + "%";
                m.message.Text += "\nB: " + publicAnswer[1] + "%";
                m.message.Text += "\nC: " + publicAnswer[2] + "%";
                m.message.Text += "\nD: " + publicAnswer[3] + "%";
                m.ShowDialog();

            }
        }
    }
}
