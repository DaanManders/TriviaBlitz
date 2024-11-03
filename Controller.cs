using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class Controller : Form
    {
        DataTable DataTable = null;
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Database101;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private List<Answer> Answers;
        private List<Question> RemainingQuestions;
        private bool IsRegularQuizMode = true;
        private int QuestionIndex = 0;
        private int elapsedTimeInSeconds = 0;
        private bool AnswerLocked = false;
        private int remainingTimeInSeconds = 80;
        private int CorrectAnswersCount = 0;
        private int SpecialCorrectAnswersCount = 0;
        private bool IsSpecialQuizMode = false;
        private int PlayerScore = 0;
        private bool FiftyFiftyUsed = false;
        private bool SkipUsed = false;


        private readonly SoundPlayer CorrectSound = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Correct.wav");
        private readonly SoundPlayer IncorrectSound = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Incorrect.wav");
        private readonly SoundPlayer PowerUp = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/50.wav");
        private readonly SoundPlayer Special = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Special.wav");

        private const string SpecialQuestion = "Special Question: What is C#?";
        private readonly List<Answer> SpecialAnswers = new List<Answer>
        {
            new Answer { Title = "Extremely Boring", Status = true },
            new Answer { Title = "Fun", Status = false },
            new Answer { Title = "Very Fun", Status = false },
            new Answer { Title = "Extremely Fun", Status = false }
        };

        private bool SpecialQuestionDisplayed = false;
        private int SpecialQuestionScore = 200;

        public Controller()
        {
            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            tbcNavigationDman.Appearance = TabAppearance.FlatButtons;
            tbcNavigationDman.SizeMode = TabSizeMode.Fixed;
            tbcNavigationDman.ItemSize = new Size(0, 1);
            rbtHomeDman.Checked = true;

            tmrSpecialQuizDman.Interval = 1000;
            tmrSpecialQuizDman.Tick -= tmrSpecialQuizDman_Tick;
            tmrSpecialQuizDman.Tick += tmrSpecialQuizDman_Tick;

            tmrQuizDman.Interval = 1000;
            tmrQuizDman.Tick -= tmrQuizDman_Tick;
            tmrQuizDman.Tick += tmrQuizDman_Tick;
        }



        private void HandleNavigation(object sender, EventArgs e)
        {
            if (sender == rbtHomeDman)
                tbcNavigationDman.SelectedTab = tbpHomeDman;
            else if (sender == rbtRankingDman)
                tbcNavigationDman.SelectedTab = tbpRankingDman;
        }

        private void btnExitDman_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuitDman_Click(object sender, EventArgs e)
        {
            tbcNavigationDman.SelectedTab = tbpHomeDman;

            tbpQuizDman.BackColor = Color.Transparent;

            pnlNavigationDman.BackColor = Color.Red;
            pnlStatisticsDman.BackColor = Color.DarkGray;

            btnFiftyFiftyDman.BackColor = Color.DarkRed;
            btnSkipQuestionDman.BackColor = Color.DarkRed;
            btnQuitDman.BackColor = Color.Red;

            btnAnswerOneDman.BackColor = Color.Red;
            btnAnswerTwoDman.BackColor = Color.DarkRed;
            btnAnswerThreeDman.BackColor = Color.Red;
            btnAnswerFourDman.BackColor = Color.DarkRed;

            btnSkipQuestionDman.Enabled = true;
            btnFiftyFiftyDman.Enabled = true;

            ResetGame();
        }

        public void FillDataTable(string Query)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                using (DataTable = new DataTable("Questions"))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                        Adapter.Fill(DataTable);
                    }
                }
            }
        }

        private void btnStartGameDman_Click(object sender, EventArgs e)
        {
            rbtRankingDman.Enabled = false;
            rbtHomeDman.Enabled = false;
            tbcNavigationDman.SelectedTab = tbpQuizDman;
            SpecialQuestionDisplayed = false;
            SkipUsed = false;
            btnSkipQuestionDman.Visible = true;
            StartGame();
        }

        public void StartGame()
        {
            IsRegularQuizMode = true;
            tmrSpecialQuizDman.Stop();
            QuestionIndex = 0;
            CorrectAnswersCount = 0;
            PlayerScore = 0;
            FiftyFiftyUsed = false;
            btnFiftyFiftyDman.Visible = true;
            SkipUsed = false;
            lblScoreDman.Text = PlayerScore.ToString();
            RemainingQuestions = GetQuestionsFromDatabase();
            remainingTimeInSeconds = 80;
            tmrQuizDman.Start();
            GenerateQuestions();
        }

        public void GenerateQuestions()
        {
            if (IsSpecialQuizMode)
            {
                if (SpecialCorrectAnswersCount < 10)
                {
                    if (QuestionIndex >= RemainingQuestions.Count)
                    {
                        QuestionIndex = 0;
                    }

                    Question currentQuestion = RemainingQuestions[QuestionIndex];
                    lblQuestionDman.Text = currentQuestion.Title;
                    lblMetaDman.Text = currentQuestion.Description;

                    Answers = GetAnswersForQuestion(currentQuestion.Id);
                    ResetAnswerButtons();

                    if (Answers.Count > 0)
                    {
                        ShuffleAnswers(Answers);
                        DisplayAnswers(Answers);
                    }
                }
                else
                {
                    MessageBox.Show("Congratulations! You've completed the special quiz by answering 10 questions correctly!");
                    tbcNavigationDman.SelectedTab = tbpHomeDman;
                    ResetGame();
                }
            }
            else
            {
                if (QuestionIndex < RemainingQuestions.Count)
                {
                    Question currentQuestion = RemainingQuestions[QuestionIndex];
                    lblQuestionDman.Text = currentQuestion.Title;
                    lblMetaDman.Text = currentQuestion.Description;

                    Answers = GetAnswersForQuestion(currentQuestion.Id);
                    ResetAnswerButtons();

                    if (Answers.Count > 0)
                    {
                        ShuffleAnswers(Answers);
                        DisplayAnswers(Answers);
                    }
                }
                else
                {
                    MessageBox.Show("Congratulations! You've answered all questions.");
                    tbcNavigationDman.SelectedTab = tbpHomeDman;
                    ResetGame();
                }
            }
        }


        private void DisplaySpecialQuestion()
        {
            btnSkipQuestionDman.Enabled = false;
            btnFiftyFiftyDman.Enabled = false;
            Special.Play();

            SpecialQuestionDisplayed = true;
            lblQuestionDman.Text = SpecialQuestion;
            lblMetaDman.Text = "This is a special question!";

            ResetAnswerButtons();
            DisplayAnswers(SpecialAnswers);

            tbpQuizDman.BackColor = Color.BurlyWood;

            pnlNavigationDman.BackColor = Color.Sienna;
            pnlStatisticsDman.BackColor = Color.Sienna;

            btnFiftyFiftyDman.BackColor = Color.Chocolate;
            btnSkipQuestionDman.BackColor = Color.Chocolate;
            btnQuitDman.BackColor = Color.Sienna;

            btnAnswerOneDman.BackColor = Color.Sienna;
            btnAnswerTwoDman.BackColor = Color.Chocolate;
            btnAnswerThreeDman.BackColor = Color.Sienna;
            btnAnswerFourDman.BackColor = Color.Chocolate;
        }

        private void ResetGame()
        {
            IsSpecialQuizMode = false;
            rbtRankingDman.Enabled = true;
            rbtHomeDman.Enabled = true;
            RemainingQuestions = GetQuestionsFromDatabase();
            tbcNavigationDman.SelectedTab = tbpHomeDman;

            tmrSpecialQuizDman.Stop();
            elapsedTimeInSeconds = 0;
            UpdateTimerDisplay();

            tmrQuizDman.Stop();
            remainingTimeInSeconds = 80;
            UpdateTimerDisplay();
        }


        private List<Question> GetQuestionsFromDatabase()
        {
            List<Question> Questions = new List<Question>();
            string Query = "SELECT TOP 40 Id, Title, Description FROM Questions ORDER BY NEWID()";
            FillDataTable(Query);

            foreach (DataRow Row in DataTable.Rows)
            {
                Questions.Add(new Question
                {
                    Id = Convert.ToInt32(Row["Id"]),
                    Title = Row["Title"].ToString(),
                    Description = Row["Description"].ToString()
                });
            }
            return Questions;
        }

        private List<Answer> GetAnswersForQuestion(int QuestionId)
        {
            List<Answer> Answers = new List<Answer>();
            string Query = $"SELECT Title, Status FROM Answers WHERE Question_Id = {QuestionId}";
            FillDataTable(Query);

            foreach (DataRow Row in DataTable.Rows)
            {
                Answers.Add(new Answer
                {
                    Title = Row["Title"].ToString(),
                    Status = Convert.ToBoolean(Row["Status"])
                });
            }
            return Answers;
        }

        private void ShuffleQuestions(List<Question> Questions)
        {
            Random Random = new Random();
            Questions.Sort((x, y) => Random.Next(-1, 2));
        }

        private void ShuffleAnswers(List<Answer> answers)
        {
            Random Random = new Random();
            answers.Sort((x, y) => Random.Next(-1, 2));
        }

        private void DisplayAnswers(List<Answer> Answers)
        {
            if (Answers.Count >= 4)
            {
                btnAnswerOneDman.Text = Answers[0].Title;
                btnAnswerTwoDman.Text = Answers[1].Title;
                btnAnswerThreeDman.Text = Answers[2].Title;
                btnAnswerFourDman.Text = Answers[3].Title;

                btnAnswerOneDman.Click -= AnswerButton_Click;
                btnAnswerTwoDman.Click -= AnswerButton_Click;
                btnAnswerThreeDman.Click -= AnswerButton_Click;
                btnAnswerFourDman.Click -= AnswerButton_Click;

                btnAnswerOneDman.Click += AnswerButton_Click;
                btnAnswerTwoDman.Click += AnswerButton_Click;
                btnAnswerThreeDman.Click += AnswerButton_Click;
                btnAnswerFourDman.Click += AnswerButton_Click;
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Answer selectedAnswer = null;

                if (button == btnAnswerOneDman)
                    selectedAnswer = Answers[0];
                else if (button == btnAnswerTwoDman)
                    selectedAnswer = Answers[1];
                else if (button == btnAnswerThreeDman)
                    selectedAnswer = Answers[2];
                else if (button == btnAnswerFourDman)
                    selectedAnswer = Answers[3];

                if (selectedAnswer != null)
                {
                    CheckAnswer(selectedAnswer);
                }
            }
        }

        private void CheckAnswer(Answer SelectedAnswer)
        {
            if (AnswerLocked) return;
            AnswerLocked = true;

            bool isCorrect = SelectedAnswer.Status;

            if (isCorrect)
            {
                CorrectSound.Play();
                MessageBox.Show("Correct Answer!");

                CorrectAnswersCount++;
                QuestionIndex++;
                GenerateQuestions();

                if (IsRegularQuizMode)
                {
                    PlayerScore += 100;
                    lblScoreDman.Text = PlayerScore.ToString();
                    remainingTimeInSeconds += 5;
                }
                else
                {
                    PlayerScore += 1;
                    lblScoreDman.Text = PlayerScore.ToString();
                }
            }
            else
            {
                IncorrectSound.Play();
                MessageBox.Show("Incorrect Answer! Moving to the next question.");

                if (IsRegularQuizMode)
                {
                    remainingTimeInSeconds -= 5;
                    PlayerScore -= 50;
                    lblScoreDman.Text = PlayerScore.ToString();
                }
                else
                {
                    elapsedTimeInSeconds += 5;
                }

                if (IsRegularQuizMode && remainingTimeInSeconds <= 0)
                {
                    tmrQuizDman.Stop();
                    MessageBox.Show("Time's up! Game over.");
                    ResetGame();
                }
                else
                {
                    UpdateTimerDisplay();
                    QuestionIndex++;
                    GenerateQuestions();
                }
            }

            AnswerLocked = false;
        }


        private void ResetAnswerButtons()
        {
            AnswerLocked = false;
            btnAnswerOneDman.Visible = true;
            btnAnswerTwoDman.Visible = true;
            btnAnswerThreeDman.Visible = true;
            btnAnswerFourDman.Visible = true;
        }

        private void btnFiftyFiftyDman_Click(object sender, EventArgs e)
        {
            if (FiftyFiftyUsed || Answers == null || Answers.Count < 4)
                return;

            PowerUp.Play();

            FiftyFiftyUsed = true;
            btnFiftyFiftyDman.Visible = false;

            List<Button> answerButtons = new List<Button> { btnAnswerOneDman, btnAnswerTwoDman, btnAnswerThreeDman, btnAnswerFourDman };
            List<int> wrongAnswerIndexes = new List<int>();

            for (int i = 0; i < Answers.Count; i++)
            {
                if (!Answers[i].Status)
                    wrongAnswerIndexes.Add(i);
            }

            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int indexToHide = wrongAnswerIndexes[random.Next(wrongAnswerIndexes.Count)];
                answerButtons[indexToHide].Visible = false;
                wrongAnswerIndexes.Remove(indexToHide);
            }
        }

        private void btnSkipQuestionDman_Click(object sender, EventArgs e)
        {
            if (SkipUsed)
            {
                btnSkipQuestionDman.Visible = false;
                return;
            }

            SkipUsed = true;
            QuestionIndex++;

            btnSkipQuestionDman.Visible = false;

            if (QuestionIndex < RemainingQuestions.Count)
            {
                GenerateQuestions();

                PowerUp.Play();
                btnSkipQuestionDman.Visible = false;
            }
            else
            {
                MessageBox.Show("You've reached the end of the quiz.");
                ResetGame();
            }
        }

        private void btnSpecialQuizDman_Click(object sender, EventArgs e)
        {
            IsRegularQuizMode = false;
            tmrQuizDman.Stop();
            rbtRankingDman.Enabled = false;
            rbtHomeDman.Enabled = false;

            tbcNavigationDman.SelectedTab = tbpQuizDman;
            QuestionIndex = 0;
            SpecialCorrectAnswersCount = 0;
            PlayerScore = 0;
            FiftyFiftyUsed = false;
            SkipUsed = false;
            IsSpecialQuizMode = true;
            lblScoreDman.Text = PlayerScore.ToString();

            RemainingQuestions = GetQuestionsFromDatabase();
            elapsedTimeInSeconds = 0;
            tmrSpecialQuizDman.Start();

            GenerateQuestions();
        }

        private void tmrSpecialQuizDman_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;
            UpdateTimerDisplay();
        }

        private void tmrQuizDman_Tick(object sender, EventArgs e)
        {
            if (remainingTimeInSeconds > 0)
            {
                remainingTimeInSeconds--;
                UpdateTimerDisplay();
            }
            else
            {
                tmrQuizDman.Stop();
                MessageBox.Show("Time's up! Game over.");
                ResetGame();
            }
        }

        private void UpdateTimerDisplay()
        {
            TimeSpan time;
            if (IsRegularQuizMode)
            {
                time = TimeSpan.FromSeconds(remainingTimeInSeconds);
            }
            else
            {
                time = TimeSpan.FromSeconds(elapsedTimeInSeconds);
            }
            lblTimeDman.Text = $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Answer
    {
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
