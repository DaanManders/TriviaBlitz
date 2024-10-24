using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class Controller : Form
    {
        #region Controller Form Variable(s).
        DataTable DataTable = null; // Initialize DataTable.

        // Connection String used to Establish a Connection to a SQL Server Database.
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Database101;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        int Count = 0; // Number of Rows Retrieved from the Database.
        int Row = 0; // Current Row Index within a DataTable.

        // Store a Collection of Answer(s) associated with the Question(s).
        private List<Answer> Answers;

        // Keep Track of the Current Question being Displayed in the Quiz.
        private int QuestionIndex = 0;
        #endregion

        public Controller()
        {
            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            #region TabControl Appearance.
            tbcNavigationDman.Appearance = TabAppearance.FlatButtons;
            tbcNavigationDman.SizeMode = TabSizeMode.Fixed;
            tbcNavigationDman.ItemSize = new Size(0, 1);
            rbtHomeDman.Checked = true;
            #endregion
        }

        private void HandleNavigation(object sender, EventArgs e)
        {
            #region Radio Buttons Navigation.
            if (sender == rbtHomeDman)
            {
                // Change Selected Tab.
                tbcNavigationDman.SelectedTab = tbpHomeDman;
            }
            else if (sender == rbtRankingDman)
            {
                // Change Selected Tab.
                tbcNavigationDman.SelectedTab = tbpRankingDman;
            }
            #endregion
        }

        #region Exit Application.
        private void btnExitDman_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Quit Game.
        private void btnQuitDman_Click(object sender, EventArgs e)
        {
            tbcNavigationDman.SelectedTab = tbpHomeDman;
        }
        #endregion

        public void FillDataTable(string Query)
        {
            #region Open(s) SQL Connection.
            // Ensures that the Connection is Properly Disposed.
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                // Checks if the Connection is Currently Closed.
                if (Connection.State == ConnectionState.Closed)
                {
                    // Opens the Database Connection.
                    Connection.Open();
                }

                #region Ensure DataTable.
                // Ensure that the DataTable Object is Disposed of when it goes out of Scope.
                using (DataTable = new DataTable("Questions"))
                {
                    // Create a new SQL Command Object.
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        // Bridge between the SQL Command & DataTable.
                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                        Adapter.Fill(DataTable); // Execute(s) SQL Command.
                    }
                }
                #endregion
            }
            #endregion
        }

        private void btnStartGameDman_Click(object sender, EventArgs e)
        {
            #region Disable User Interactions.
            rbtRankingDman.Enabled = false; // Disable(s) "Ranking" Radio Button.
            rbtHomeDman.Enabled = false; // Disable(s) "Home" Radio Button.

            // Redirect to the Quiz Tabpage.
            tbcNavigationDman.SelectedTab = tbpQuizDman;
            #endregion

            StartGame();
        }

        public void StartGame()
        {
            #region Set Question Index.
            QuestionIndex = 0;
            #endregion

            GenerateQuestions();
        }

        public void GenerateQuestions()
        {
            #region Generate & Display Questions.
            List<Question> Questions = GetQuestionsFromDatabase();

            if (Questions.Count > 0)
            {
                #region Shuffle Question(s) & Display.
                ShuffleQuestions(Questions); // Shuffle Question List.

                // Display First Question of the List on Form.
                lblQuestionDman.Text = Questions[QuestionIndex].Title;
                lblMetaDman.Text = Questions[QuestionIndex].Description;
                
                // Get Question Answers from Questions.
                Answers = GetAnswersForQuestion(Questions[QuestionIndex].Id);
                #endregion

                ResetAnswerButtons();

                #region Shuffle Answer(s).
                if (Answers.Count > 0)
                {
                    ShuffleAnswers(Answers);
                    DisplayAnswers(Answers);
                }
                #endregion
            }
            #endregion
        }

        private List<Question> GetQuestionsFromDatabase()
        {
            #region Retrieved Question Object(s).
            List<Question> Questions = new List<Question>();
            #endregion

            #region Define(s) a SQL Query to select All Field(s) from the Questions DataTable.
            string Query = "SELECT Id, Title, Description FROM Questions";
            #endregion

            FillDataTable(Query);

            #region Each Row represents a Question Fetched from the Database.
            foreach (DataRow Row in DataTable.Rows)
            {
                Question question = new Question
                {
                    Id = Convert.ToInt32(Row["Id"]),
                    Title = Row["Title"].ToString(),
                    Description = Row["Description"].ToString()
                };
                Questions.Add(question);
            }
            return Questions;
            #endregion
        }

        private List<Answer> GetAnswersForQuestion(int QuestionId)
        {
            #region Retrieved Answer Object(s).
            List<Answer> Answers = new List<Answer>();
            #endregion

            #region Define(s) a SQL Query to select All Field(s) from the Answers DataTable.
            string Query = $"SELECT Title, Status FROM Answers WHERE Question_Id = {QuestionId}";
            #endregion

            FillDataTable(Query);

            #region Each Row represents a Answer Fetched from the Database.
            foreach (DataRow Row in DataTable.Rows)
            {
                Answer Answer = new Answer
                {
                    Title = Row["Title"].ToString(),
                    Status = Convert.ToBoolean(Row["Status"])
                };
                Answers.Add(Answer);
            }
            return Answers;
            #endregion
        }

        #region Shuffle(s) Questions & Answers.
        private void ShuffleQuestions(List<Question> Questions)
        {
            #region Shuffle Question List.
            Random Random = new Random();
            Questions.Sort((x, y) => Random.Next(-1, 2));
            #endregion
        }

        private void ShuffleAnswers(List<Answer> answers)
        {
            #region Shuffle Answer List.
            Random Random = new Random();
            answers.Sort((x, y) => Random.Next(-1, 2));
            #endregion
        }
        #endregion

        #region Display(s) Shuffled Questions & Answers.
        private void DisplayAnswers(List<Answer> Answers)
        {
            if (Answers.Count >= 4)
            {
                #region Display(s) Shuffled Answers in Buttons.
                btnAnswerOneDman.Text = Answers[0].Title;
                btnAnswerTwoDman.Text = Answers[1].Title;
                btnAnswerThreeDman.Text = Answers[2].Title;
                btnAnswerFourDman.Text = Answers[3].Title;
                #endregion

                #region Check(s) Answer on Click.
                btnAnswerOneDman.Click += (s, e) => CheckAnswer(Answers[0]);
                btnAnswerTwoDman.Click += (s, e) => CheckAnswer(Answers[1]);
                btnAnswerThreeDman.Click += (s, e) => CheckAnswer(Answers[2]);
                btnAnswerFourDman.Click += (s, e) => CheckAnswer(Answers[3]);
                #endregion
            }
        }
        #endregion

        private void CheckAnswer(Answer SelectedAnswer)
        {
            #region Checks Clicked Answer.
            // If Answer is Correct, Move On.
            if (SelectedAnswer.Status)
            {
                QuestionIndex++; // Increase Question List Index.
                GenerateQuestions(); // Generate Next Question.
            }
            else
            {
                #region Handle(s) Clicked Button.
                // Check(s) which Button has been Pressed.
                Button ClickedButton = GetButtonByAnswer(SelectedAnswer);

                if (ClickedButton != null)
                {
                    ClickedButton.Visible = false; // Hide Clicked Answer.
                    MessageBox.Show("Incorrect Answer!");
                }
                #endregion
            }
            #endregion
        }

        private Button GetButtonByAnswer(Answer SelectedAnswer)
        {
            #region Compare(s) Answer and Button.
            if (SelectedAnswer.Title == btnAnswerOneDman.Text)
                return btnAnswerOneDman;
            if (SelectedAnswer.Title == btnAnswerTwoDman.Text)
                return btnAnswerTwoDman;
            if (SelectedAnswer.Title == btnAnswerThreeDman.Text)
                return btnAnswerThreeDman;
            if (SelectedAnswer.Title == btnAnswerFourDman.Text)
                return btnAnswerFourDman;
            return null;
            #endregion
        }

        #region Unhide All Answer(s).
        private void ResetAnswerButtons()
        {
            btnAnswerOneDman.Visible = true;
            btnAnswerTwoDman.Visible = true;
            btnAnswerThreeDman.Visible = true;
            btnAnswerFourDman.Visible = true;
        }
        #endregion
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
