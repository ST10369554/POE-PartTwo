using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //get instance of external class
        private E_Cook_Recipe Reci_Cook = new E_Cook_Recipe();

        public MainWindow()
        {
            InitializeComponent();
        }


        //event handler for capturing
        private void capture(object sender, RoutedEventArgs e)
        {

            //open the capture page
            landing_page.Visibility = Visibility.Hidden;
            capturing.Visibility = Visibility.Visible;

            display_all.Visibility = Visibility.Hidden;


           


        }

        //display event handler
        private void display(object sender, RoutedEventArgs e)
        {
            //open the display page
            landing_page.Visibility = Visibility.Hidden;
            capturing.Visibility = Visibility.Hidden;

            display_all.Visibility = Visibility.Visible;

            //display all the data
            add_all.Items.Clear();

            //add from the display method in external class
            add_all.Items.Add(Reci_Cook.displays() );
        }

        //saving the data 
        private void save(object sender, RoutedEventArgs e)
        {
            //get all the values from the user
            string name = recipe_name.Text;
            string quantity = recipe_quantity.Text;
            string measurement = recipe_measurement.Text;
            string food_groups = food_group.Text;

            //check the variables if they are not empty
            if (name.Equals("") || quantity.Equals("") || measurement.Equals("") ||  food_groups.Equals("") )
            {

                //display a message
                MessageBox.Show("     Error Message !! \n\n All fields are" +
                    "required !!\n\n");

            }
            else{


                //pass the varibales to store in the generics
                string message =   Reci_Cook.saves(name , quantity , measurement , food_groups);

                MessageBox.Show("Message !!\n\n" + message);
                //clear the fields 
                recipe_name.Clear();
                recipe_quantity.Clear();
                recipe_measurement.Clear();

            }




        }



    }
}