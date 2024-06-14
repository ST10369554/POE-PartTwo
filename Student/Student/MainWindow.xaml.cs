using System.Windows;

namespace StudentDetails
{
    // Main window class for the application
    public partial class MainWindow : Window
    {
        // Constructor initializes the components of the window
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Submit button click event
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the values entered by the user
            string studentName = txtStudentName.Text;
            string studentSurname = txtStudentSurname.Text;
            string studentNumber = txtStudentNumber.Text;

            // Display the entered student details in the TextBlock
            txtStudentDetails.Text = $"Student Name: {studentName}\nStudent Surname: {studentSurname}\nStudent Number: {studentNumber}";
        }
    }
}