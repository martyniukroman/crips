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

namespace mainsolution {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Ellipse> Elipses = new List<Ellipse>();
        List<CripsAboveClass> Crips = new List<CripsAboveClass>();

        int Counter = 0;

        public MainWindow() {
            InitializeComponent();

            //CripWorker test = new CripWorker();
           // mainelipse = test.ElipseModel;

        }

        public void SpawnCrip(CripsAboveClass CripTypeChild) {

            CripsAboveClass CripTmp = CripTypeChild; // setting CripType from caller
            Ellipse ElipseTmp = new Ellipse(); // Highlighting memory for elips crip model
            Counter++; 

            ElipseTmp = CripTmp.ElipseModel; //setting new crip model to tmp elipse
            ElipseTmp.Width = 50; //set width
            ElipseTmp.Height = 50; //set hight

            Elipses.Add(ElipseTmp); // adding to elipses list
            Crips.Add(CripTmp); // adding to crips list

            CanvasMain.Children.Add(Elipses.Last()); // showing our elips
            Canvas.SetTop(Elipses.Last(), 10 * Counter); // set position
            Canvas.SetLeft(Elipses.Last(), 10 * Counter); // set positon

        }

        private void SpawnWorker_Click(object sender, RoutedEventArgs e) {
            SpawnCrip(new CripWorker());
        }

        private void SpawnSolder_Click(object sender, RoutedEventArgs e) {
            SpawnCrip(new CripSolder());
        }

        private void SpawnDefender_Click(object sender, RoutedEventArgs e) {
            SpawnCrip(new CripDefender());
        }





        //finish
    }
}
