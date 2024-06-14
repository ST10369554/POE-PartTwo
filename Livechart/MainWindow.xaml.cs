using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Livechart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //hold count for the PieChart percentages
        int one = 0;
        int two = 0;
        int three = 0;
        int four = 0;
        int five = 0;
        int six = 0;
        int seven = 0;
        int eight = 0;
        List<string> filter_name = new List<string>();


        //automic proparties for series collection of the pie-chart data collection
        public SeriesCollection SeriesCollection { get; private set; }
        public MainWindow()
        {

            //add food_groups
            filter_name.Add("Vegetables and Fruits");
            filter_name.Add("Dry beans ,Peas, Lentils and Soya");
            filter_name.Add("Chicken, Fish, Meat and Eggs");
            filter_name.Add("Milk and Dairy products");
            filter_name.Add("Fats and Oil");
            filter_name.Add("Starchy food");
            filter_name.Add("Water");


            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //alterate through filter hold filter_names generics
            for (int u = 0; u < filter_name.Count; u++)
            {


                //compare to assign percentage of them all if found
                if (filter_name[u].Contains("Vegetables and Fruits"))
                {

                    one += 14;
                }
                else if (filter_name[u].Contains("Dry beans ,Peas, Lentils and Soya"))
                {

                    two += 12;
                }
                else if (filter_name[u].Contains("Chicken, Fish, Meat and Eggs"))
                {
                    three += 1;
                }
                else if (filter_name[u].Contains("Milk and Dairy products"))
                {
                    four += 6;
                }
                else if (filter_name[u].Contains("Fats and Oil"))
                {
                    five += 8;
                }
                else if (filter_name[u].Contains("Water"))
                {
                    six += 10;
                }
                else if (filter_name[u].Contains("Starchy food"))
                {
                    seven += 11;
                }
               
                }
            


            //adding to series collections
            SeriesCollection = new SeriesCollection
            {
                //new series, to add all categories of food groups

                new PieSeries
                {
                    Title = "Vegetables and Fruits",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(one) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Dry beans ,Peas, Lentils and Soya",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(two) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chicken, Fish, Meat and Eggs",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(three) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Milk and Dairy products",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(four)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Fats and Oil",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(five)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Water",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(six)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Starchy",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(seven)},
                    DataLabels = true
                },
               

            };

            //add the content into the pie chart
            DataContext = this;


            //reset values of counting
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;
            seven = 0;
            eight = 0;
        }
    }
}