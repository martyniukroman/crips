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

        List<Ellipse> Ellipses = new List<Ellipse>();
        List<CripsAboveClass> Crips = new List<CripsAboveClass>();

        int Counter = 0;

        public MainWindow() {
            InitializeComponent();

            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);

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

           // CripTmp.ElipseModel.MouseEnter += ElipseModel_MouseEnter;
            CripTmp.ElipseModel.MouseDown += ElipseModel_MouseEnter;

            Ellipses.Add(ElipseTmp); // adding to elipses list
            Crips.Add(CripTmp); // adding to crips list

            CanvasMain.Children.Add(Ellipses.Last()); // showing our elips
            Canvas.SetTop(Ellipses.Last(), 10 * Counter * 5); // set position
            Canvas.SetLeft(Ellipses.Last(), 10 * Counter * 5); // set positon

            this.Title += CripTmp.Indeficator;
        }

        private void ElipseModel_MouseEnter(object sender, MouseEventArgs e) {

           int index = Ellipses.IndexOf((sender as Ellipse));

            LabelType.Content = Crips[index].ToString();
            LabelHp.Content = "Hp: " + Crips[index].Hp;
            LabelSpeed.Content = "Speed: " + Crips[index].Speed;


            if (Crips[index] is CripWorker) {
                LabelSpecial.Content = "Absorbed: " + (Crips[index] as CripWorker).Absorbed + " | " + (Crips[index] as CripWorker).Cepacity;
            }
            if (Crips[index] is CripSolder) {
                LabelSpecial.Content = "Attack: " + (Crips[index] as CripSolder).Attack;
            }
            if (Crips[index] is CripDefender) {
                LabelSpecial.Content = "Attack: " + (Crips[index] as CripDefender).Attack;
            }


            
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

        private void ThemeWhite_Click(object sender, RoutedEventArgs e) {
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        private void ThemeDark_Click(object sender, RoutedEventArgs e) {
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("DarkTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }




        //finish
    }
}
