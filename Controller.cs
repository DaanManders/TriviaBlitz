using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class Controller : Form
    {
        #region Project APPR TriviaBlitz.

        #region Variable(s) Used In Project.

        #region DataTable Variable(s) Used.
        DataTable DataTable = null; // Assign DataTable.
        #endregion

        #region String Variable(s) Used.
        // Connection String Localhost SQL Express.
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Database101;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        #endregion

        #region List Variable(s) Used.
        private List<Question> RemainingQuestions; // Array for Remaining Questions.
        private List<Answer> Answers; // Array for Answers.
        #endregion

        #region Boolean Variable(s) Used.
        private bool SpecialQuestionDisplayed = false; // Check for Special Question.
        private bool SkipUsed = false; // Check for Used Skip Question Ability.
        private bool FiftyFiftyUsed = false; // Check for Used 50/50 Ability.
        private bool IsSpecialQuizMode = false; // Check for Special Quiz.
        private bool IsRegularQuizMode = true; // Check for Regular Quiz.
        private bool AnswerLocked = false; // Check for Locked Answers.
        #endregion

        #region Integer Variable(s) Used.
        private int RemainingTimeInSeconds = 80; // Regular Quiz Time In Seconds.
        private int SpecialCorrectAnswersCount = 0; // Special Quiz Answer Count.
        private int ElapsedTimeInSeconds = 0; // Special Quiz Time In Seconds.
        private int CorrectAnswersCount = 0; // Regular Quiz Answer Count.
        private int SpecialQuestionScore = 200; // Special Question Score.
        private int QuestionIndex = 0; // Question List Index.
        private int PlayerScore = 0; // Score of the User.
        #endregion

        #region Audio File Variable(s) Used.
        private readonly SoundPlayer CorrectSound = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Correct.wav");
        private readonly SoundPlayer IncorrectSound = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Incorrect.wav");
        private readonly SoundPlayer PowerUp = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/50.wav");
        private readonly SoundPlayer Special = new SoundPlayer("C:\\Users\\gebruiker\\Documents\\APPR - Applicatie Programmeren\\L3P1\\APPR_TriviaBlitz_22SD_Dman\\Audio/Special.wav");
        #endregion

        #region Special Question Attribute(s).
        private const string SpecialQuestion = "Special Question: What is C#?"; // Special Question Title.
        private readonly List<Answer> SpecialAnswers = new List<Answer> // Assign List.
        {
            // Special Question Answer(s).
            new Answer { Title = "Extremely Boring", Status = true },
            new Answer { Title = "Fun", Status = false },
            new Answer { Title = "Very Fun", Status = false },
            new Answer { Title = "Extremely Fun", Status = false }
        };
        #endregion

        #endregion

        public Controller()
        {
            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            #region Handle Controller Form Load.

            #region Controller Form Design Setting(s).
            tbcNavigationDman.Appearance = TabAppearance.FlatButtons;
            tbcNavigationDman.SizeMode = TabSizeMode.Fixed;
            tbcNavigationDman.ItemSize = new Size(0, 1);
            rbtHomeDman.Checked = true;
            #endregion

            #region Setup Special Quiz Timer.
            tmrSpecialQuizDman.Interval = 1000; // Set 1000ms Interval.
            tmrSpecialQuizDman.Tick -= tmrSpecialQuizDman_Tick; // Deselect Special Timer.
            tmrSpecialQuizDman.Tick += tmrSpecialQuizDman_Tick; // Select Special Timer.
            #endregion

            #region Setup Regular Quiz Timer.
            tmrQuizDman.Interval = 1000; // Set 1000ms Interval.
            tmrQuizDman.Tick -= tmrQuizDman_Tick; // Deselect Regular Timer.
            tmrQuizDman.Tick += tmrQuizDman_Tick; // Select Regular Timer.
            #endregion

            #endregion
        }

        #region Handle Form Navigation.

        private void HandleNavigation(object sender, EventArgs e)
        {
            if (sender == rbtHomeDman)
                // Navigate to TriviaBlitz Home.
                tbcNavigationDman.SelectedTab = tbpHomeDman;

            else if (sender == rbtRankingDman)
                // Navigate to TriviaBlitz Ranking.
                tbcNavigationDman.SelectedTab = tbpRankingDman;
        }

        #endregion

        #region Handle Application Exit.

        private void btnExitDman_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Handle Quit Game.

        private void btnQuitDman_Click(object sender, EventArgs e)
        {
            tbcNavigationDman.SelectedTab = tbpHomeDman;

            btnSkipQuestionDman.Enabled = true;
            btnFiftyFiftyDman.Enabled = true;

            ResetThemeColors();
            ResetGame();
        }

        #endregion

        #region Reset Controller Form Theme Color(s).

        public void ResetThemeColors()
        {
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
        }

        #endregion

        public void FillDataTable(string Query)
        {
            #region Fill DataTable.
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                // Checks DataTable Connection.
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                using (DataTable = new DataTable("Questions"))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                        Adapter.Fill(DataTable); // Fill DataTable.
                    }
                }
            }
            #endregion
        }

        #region Start Game.

        private void btnStartGameDman_Click(object sender, EventArgs e)
        {
            rbtRankingDman.Enabled = false;
            rbtHomeDman.Enabled = false;

            tbcNavigationDman.SelectedTab = tbpQuizDman;

            SpecialQuestionDisplayed = false;

            SkipUsed = false;

            btnSkipQuestionDman.Visible = true;
            StartGame(); // Start Game.
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

            RemainingTimeInSeconds = 80;
            tmrQuizDman.Start();

            GenerateQuestions();
        }

        #endregion

        #region Generate Questions.

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
                    ResetAnswerButtons(); // Reset Buttons.

                    if (Answers.Count > 0)
                    {
                        // Shuffle Answers.
                        ShuffleAnswers(Answers);
                        DisplayAnswers(Answers);
                    }
                }
                else
                {
                    MessageBox.Show("Congratulations! You've completed the special quiz by answering 10 questions correctly!");
                    tbcNavigationDman.SelectedTab = tbpHomeDman;
                    ResetGame(); // Reset.
                }
            }
            else
            {
                if (QuestionIndex < RemainingQuestions.Count)
                {
                    if (!SpecialQuestionDisplayed && QuestionIndex > 1 && QuestionIndex < 20)
                    {
                        // Randomly Decide whether to Show the Special Question.
                        if (new Random().Next(0, 5) == 0) // 20% Chance to Display the Special Question.
                        {
                            DisplaySpecialQuestion();
                            return; // Exit to Prevent showing Another Question.
                        }
                    }

                    Question CurrentQuestion = RemainingQuestions[QuestionIndex];
                    lblQuestionDman.Text = CurrentQuestion.Title;
                    lblMetaDman.Text = CurrentQuestion.Description;

                    Answers = GetAnswersForQuestion(CurrentQuestion.Id);
                    ResetAnswerButtons(); // Reset Buttons.

                    if (Answers.Count > 0)
                    {
                        // Shuffle Answers.
                        ShuffleAnswers(Answers);
                        DisplayAnswers(Answers);
                    }
                }
                else
                {
                    MessageBox.Show("Congratulations! You've answered all questions.");
                    tbcNavigationDman.SelectedTab = tbpHomeDman;
                    ResetGame(); // Reset.
                }
            }
        }

        #endregion

        #region Display Special Question.

        private void DisplaySpecialQuestion()
        {
            btnSkipQuestionDman.Enabled = false;
            btnFiftyFiftyDman.Enabled = false;
            Special.Play(); // Play Audio.

            SpecialQuestionDisplayed = true;
            lblQuestionDman.Text = SpecialQuestion;
            lblMetaDman.Text = "This is a special question!";

            ResetAnswerButtons(); // Reset Question Answers.
            DisplayAnswers(SpecialAnswers);

            SpecialQuestionColors(); // Add Special Theme.
        }

        #endregion

        #region Special Question Colors.

        public void SpecialQuestionColors()
        {
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

        #endregion

        #region Reset Game.

        private void ResetGame()
        {
            IsSpecialQuizMode = false;

            rbtRankingDman.Enabled = true;
            rbtHomeDman.Enabled = true;

            RemainingQuestions = GetQuestionsFromDatabase();

            tbcNavigationDman.SelectedTab = tbpHomeDman;

            tmrSpecialQuizDman.Stop();
            ElapsedTimeInSeconds = 0;
            UpdateTimerDisplay();

            tmrQuizDman.Stop(); // Stop Timer.
            RemainingTimeInSeconds = 80;
            UpdateTimerDisplay();
        }

        #endregion

        #region Handle DataTable to Object(s).

        private List<Question> GetQuestionsFromDatabase()
        {
            #region Get Questions from DataTable.
            List<Question> Questions = new List<Question>(); // Assign new List.
            string Query = "SELECT TOP 40 Id, Title, Description FROM Questions ORDER BY NEWID()";
            FillDataTable(Query); // Execute Query.

            foreach (DataRow Row in DataTable.Rows)
            {
                Questions.Add(new Question
                {
                    Id = Convert.ToInt32(Row["Id"]), // Assign Result to Variable.
                    Title = Row["Title"].ToString(), // Assign Result to Variable.
                    Description = Row["Description"].ToString() // Same Here.
                });
            }
            return Questions; // Return Object.
            #endregion
        }

        private List<Answer> GetAnswersForQuestion(int QuestionId)
        {
            #region Get Answers from DataTable.
            List<Answer> Answers = new List<Answer>(); // Assign new List.
            string Query = $"SELECT Title, Status FROM Answers WHERE Question_Id = {QuestionId}";
            FillDataTable(Query); // Execute Query.

            foreach (DataRow Row in DataTable.Rows)
            {
                Answers.Add(new Answer
                {
                    Title = Row["Title"].ToString(), // Assign Result to Variable.
                    Status = Convert.ToBoolean(Row["Status"]) // Same Here.
                });
            }
            return Answers; // Return Object.
            #endregion
        }

        #endregion

        #region Shuffle Quiz List(s).

        #region Shuffle Questions.

        private void ShuffleQuestions(List<Question> Questions)
        {
            Random Random = new Random(); // Randomize Questions.
            Questions.Sort((x, y) => Random.Next(-1, 2));
        }

        #endregion

        #region Shuffle Question Answers.

        private void ShuffleAnswers(List<Answer> Answers)
        {
            Random Random = new Random(); // Randomize Question Answers.
            Answers.Sort((x, y) => Random.Next(-1, 2));
        }

        #endregion

        #endregion

        #region Handle Quiz Answers.

        private void DisplayAnswers(List<Answer> Answers)
        {
            #region Display Question Answers.
            if (Answers.Count >= 4)
            {
                // Display DataTable Answers.
                btnAnswerOneDman.Text = Answers[0].Title;
                btnAnswerTwoDman.Text = Answers[1].Title;
                btnAnswerThreeDman.Text = Answers[2].Title;
                btnAnswerFourDman.Text = Answers[3].Title;

                // Deselect Click Event.
                btnAnswerOneDman.Click -= AnswerButton_Click;
                btnAnswerTwoDman.Click -= AnswerButton_Click;
                btnAnswerThreeDman.Click -= AnswerButton_Click;
                btnAnswerFourDman.Click -= AnswerButton_Click;

                // Select Click Event.
                btnAnswerOneDman.Click += AnswerButton_Click;
                btnAnswerTwoDman.Click += AnswerButton_Click;
                btnAnswerThreeDman.Click += AnswerButton_Click;
                btnAnswerFourDman.Click += AnswerButton_Click;
            }
            #endregion
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            #region Handle Answer Click.
            if (sender is Button Button)
            {
                Answer SelectedAnswer = null;

                // Assign First Answer Button.
                if (Button == btnAnswerOneDman)
                    SelectedAnswer = Answers[0];

                // Assign Second Answer Button.
                else if (Button == btnAnswerTwoDman)
                    SelectedAnswer = Answers[1];

                // Assign Third Answer Button.
                else if (Button == btnAnswerThreeDman)
                    SelectedAnswer = Answers[2];

                // Assign Fourth Answer Button.
                else if (Button == btnAnswerFourDman)
                    SelectedAnswer = Answers[3];

                if (SelectedAnswer != null)
                {
                    // Checks Selected Button.
                    CheckAnswer(SelectedAnswer);
                }
            }
            #endregion
        }

        #region Check Answer Eventhandler.

        private void CheckAnswer(Answer SelectedAnswer)
        {
            if (AnswerLocked) return;
            AnswerLocked = true;

            // Check if the Answer is Correct.
            bool isCorrect = SelectedAnswer.Status;

            // Handle Special Question.
            if (lblQuestionDman.Text == SpecialQuestion)
            {
                if (isCorrect)
                {
                    CorrectSound.Play(); // Play Audio.
                    MessageBox.Show("Correct Answer!");

                    CorrectAnswersCount++;
                    QuestionIndex++;

                    PlayerScore += 200; // Award 200 Points.
                    lblScoreDman.Text = PlayerScore.ToString();

                    ResetThemeColors();

                    btnFiftyFiftyDman.Enabled = true;
                    btnSkipQuestionDman.Enabled = true;

                    if (CorrectAnswersCount == RemainingQuestions.Count)
                    {
                        MessageBox.Show("Congratulations! You've answered all questions correctly!");
                        ResetGame(); // Reset Game.
                    }
                    else
                    {
                        GenerateQuestions();
                    }
                }
                else
                {
                    IncorrectSound.Play(); // Play Audio
                    MessageBox.Show("Incorrect Answer! No score added for this special question.");

                    QuestionIndex++;

                    GenerateQuestions();

                    ResetThemeColors();

                    btnFiftyFiftyDman.Enabled = true;
                    btnSkipQuestionDman.Enabled = true;
                }
            }
            else
            {
                if (isCorrect)
                {
                    CorrectSound.Play(); // play Audio.
                    MessageBox.Show("Correct Answer!");

                    CorrectAnswersCount++;
                    QuestionIndex++;

                    if (IsRegularQuizMode)
                    {
                        PlayerScore += 100; // Add Score.
                        lblScoreDman.Text = PlayerScore.ToString();
                        RemainingTimeInSeconds += 5; // Add Time.
                    }

                    if (IsSpecialQuizMode)
                    {
                        SpecialCorrectAnswersCount++; // Increase Count.
                        lblScoreDman.Text = (SpecialCorrectAnswersCount).ToString();
                    }

                    if (CorrectAnswersCount == RemainingQuestions.Count)
                    {
                        MessageBox.Show("Congratulations! You've answered all questions correctly!");
                        ExecuteQuery("INSERT INTO [dbo].[Leaderboard] ([Username], [Score]) VALUES (N'" + "Test" + "', N'" + PlayerScore + "')");
                        ResetGame(); // Reset Game.
                    }
                    else
                    {
                        GenerateQuestions();
                    }
                }
                else
                {
                    IncorrectSound.Play(); // Play Audio.
                    MessageBox.Show("Incorrect Answer! Moving to the next question.");

                    if (IsRegularQuizMode)
                    {
                        PlayerScore -= 50; // Subtract Score.
                        lblScoreDman.Text = PlayerScore.ToString();

                        RemainingTimeInSeconds -= 5; // Subtract Time.
                        UpdateTimerDisplay(); // Update.

                        if (PlayerScore < 0)
                        {
                            PlayerScore = 0; // Can't go Negative.
                            lblScoreDman.Text = PlayerScore.ToString();
                        }
                    }

                    if (IsSpecialQuizMode)
                    {
                        ElapsedTimeInSeconds += 5; // Add Time.
                        UpdateTimerDisplay();

                        lblScoreDman.Text = (SpecialCorrectAnswersCount).ToString();
                    }

                    QuestionIndex++;

                    if (QuestionIndex < RemainingQuestions.Count)
                    {
                        GenerateQuestions();
                    }
                    else
                    {
                        MessageBox.Show("You've reached the end of the quiz.");
                        ResetGame();
                    }
                }
            }
        }

        #endregion

        #region Reset Question Answer Button(s).

        private void ResetAnswerButtons()
        {
            AnswerLocked = false;

            btnAnswerOneDman.Visible = true;
            btnAnswerTwoDman.Visible = true;
            btnAnswerThreeDman.Visible = true;
            btnAnswerFourDman.Visible = true;
        }

        #endregion

        #endregion

        #region Handle Special Quiz Button.

        private void btnSpecialQuizDman_Click(object sender, EventArgs e)
        {
            IsRegularQuizMode = false; // Set Regular Mode to False.
            IsSpecialQuizMode = true; // Set Special Mode to True.

            rbtRankingDman.Enabled = false;
            rbtHomeDman.Enabled = false;

            tmrQuizDman.Stop(); // Stop Regular Timer.
            ElapsedTimeInSeconds = 0; // Reset Timer.
            tmrSpecialQuizDman.Start(); // Start.

            tbcNavigationDman.SelectedTab = tbpQuizDman;

            QuestionIndex = 0;
            SpecialCorrectAnswersCount = 0;
            RemainingQuestions = GetQuestionsFromDatabase();

            FiftyFiftyUsed = false; // Reset 50/50 Ability.
            SkipUsed = false; // Reset Skip Ability.

            PlayerScore = 0; // Reset Player Score.
            lblScoreDman.Text = PlayerScore.ToString();

            GenerateQuestions();
        }

        #endregion

        #region Project Special Ability Setting(s).

        #region Handle 50/50 Ability. 

        private void btnFiftyFiftyDman_Click(object sender, EventArgs e)
        {
            // Checks if 50/50 Ability was Used.
            if (FiftyFiftyUsed || Answers == null || Answers.Count < 4)
                return;

            PowerUp.Play(); // Play Audio.

            btnFiftyFiftyDman.Visible = false;
            FiftyFiftyUsed = true;

            // Assigns Question Answers to List.
            List<Button> AnswerButtons = new List<Button> { btnAnswerOneDman, btnAnswerTwoDman, btnAnswerThreeDman, btnAnswerFourDman };
            List<int> WrongAnswerIndexes = new List<int>(); // Generate Wrong Answer Indexes.

            for (int i = 0; i < Answers.Count; i++)
            {
                if (!Answers[i].Status)
                    // Adds Index to Wrong Answers.
                    WrongAnswerIndexes.Add(i);
            }

            Random Random = new Random();

            for (int i = 0; i < 2; i++)
            {
                // Randomizes the Wrong Answer Index(s).
                int IndexToHide = WrongAnswerIndexes[Random.Next(WrongAnswerIndexes.Count)];
                AnswerButtons[IndexToHide].Visible = false; // Hide(s) Wrong Answers.
                WrongAnswerIndexes.Remove(IndexToHide);
            }
        }

        #endregion

        #region Handle Skip Question Ability.

        private void btnSkipQuestionDman_Click(object sender, EventArgs e)
        {
            if (SkipUsed)
            {
                btnSkipQuestionDman.Visible = false;
                return; // Return Variable.
            }

            SkipUsed = true;
            QuestionIndex++;

            btnSkipQuestionDman.Visible = false;

            // Handle(s) Question Index due Skip Ability.
            if (QuestionIndex < RemainingQuestions.Count)
            {
                GenerateQuestions();

                btnSkipQuestionDman.Visible = false;
                PowerUp.Play(); // Play Audio.
            }
            else
            {
                MessageBox.Show("You've reached the end of the quiz.");
                ResetGame(); // Reset.
            }
        }

        #endregion

        #endregion

        #region Project Timer Setting(s).

        #region Special Quiz Timer Setting(s).

        private void tmrSpecialQuizDman_Tick(object sender, EventArgs e)
        {
            ElapsedTimeInSeconds++; // Count Up the Timer.
            UpdateTimerDisplay(); // Update Display.
        }

        #endregion

        #region Regular Quiz Timer Setting(s).

        private void tmrQuizDman_Tick(object sender, EventArgs e)
        {
            if (RemainingTimeInSeconds > 0)
            {
                RemainingTimeInSeconds--; // Count Down the Timer.
                UpdateTimerDisplay(); // Change Display.
            }
            else
            {
                tmrQuizDman.Stop(); // Stop Timer.
                MessageBox.Show("Time's up! Game over.");
                ResetGame(); // Reset Game.
            }
        }

        #endregion

        #region Update Time(s) Display.

        private void UpdateTimerDisplay()
        {
            // Represent Timer Interval.
            TimeSpan Time;

            if (IsRegularQuizMode)
            {
                // If User is Playing Regular Quiz Mode.
                Time = TimeSpan.FromSeconds(RemainingTimeInSeconds);
            }
            else
            {
                // If User is Playing Special Quiz Mode.
                Time = TimeSpan.FromSeconds(ElapsedTimeInSeconds);
            }

            // Update Timer Label.
            lblTimeDman.Text = $"{Time.Minutes:D2}:{Time.Seconds:D2}";
        }

        #endregion

        #endregion

        #endregion
    }

    #region Project Classes Used.

    #region Public Question Class.

    public class Question
    {
        public int Id { get; set; } // Set Question Id.

        public string Title { get; set; } // Set Question Title.

        public string Description { get; set; } // Set Question Description.
    }

    #endregion

    #region Public Answer Class.

    public class Answer
    {
        public string Title { get; set; } // Set Answer Title.

        public bool Status { get; set; } // Set Answer Status.
    }

    #endregion

    #endregion
}