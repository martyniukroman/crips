using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public List<Ellipse> Ellipses = new List<Ellipse>();
        public List<CripsAboveClass> Crips = new List<CripsAboveClass>();
        public CripsAboveClass SelectedCrip;
        public int WorkersCounter = 0;
        public int SoldersCounter = 0;
        public int DefendersCounter = 0;
        public int Resourses = 0;

        int Counter = 0;

        public MainWindow() {
            InitializeComponent();

            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);

            //CripWorker test = new CripWorker();
            // mainelipse = test.ElipseModel;

            //TimerCallback Tm = new TimerCallback(TimersAction);
           // Timer timer = new Timer(Tm, SelectedCrip, 2000, 2000);
            
        }

        public void SpawnCrip(CripsAboveClass CripTypeChild) {

            CripsAboveClass CripTmp = CripTypeChild; // setting CripType from caller
            Ellipse ElipseTmp = new Ellipse(); // Highlighting memory for elips crip model
            Counter++; 

            ElipseTmp = CripTmp.ElipseModel; //setting new crip model to tmp elipse
            ElipseTmp.Width = 50; //set width
            ElipseTmp.Height = 50; //set hight

            // CripTmp.ElipseModel.MouseEnter += ElipseModel_MouseEnter;
            CripTmp.ElipseModel.MouseLeftButtonDown += ElipseModel_MouseEnter;
            CripTmp.ElipseModel.MouseRightButtonDown += ElipseModel_MouseRightButtonDown;

            Ellipses.Add(ElipseTmp); // adding to elipses list
            Crips.Add(CripTmp); // adding to crips list

            CanvasMain.Children.Add(Ellipses.Last()); // showing our elips
            Canvas.SetTop(Ellipses.Last(), 10 * Counter * 5); // set position
            Canvas.SetLeft(Ellipses.Last(), 10 * Counter * 5); // set positon

            this.Title += CripTmp.Indeficator;

            Task.Run(() => {
                while (true) {
                    Thread.Sleep(10);
                    TimersAction(null);
                }
            });
        }

        private void ElipseModel_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {

            if (SelectedCrip is CripWorker) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.DarkOrchid);
            }
            if (SelectedCrip is CripSolder) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.DodgerBlue);
            }
            if (SelectedCrip is CripDefender) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.LightSeaGreen);
            }
  
            SelectedCrip = null;
            SliderChange.Value = SliderChange.Minimum;
            LabelHpToCepacityPrew.Content = "50 / 10";

            LabelType.Content = "Type";
            LabelHp.Content = "Hp";
            LabelSpecial.Content = "Special";
            LabelSpeed.Content = "Speed";

            // Preview Ellipse
            EllipsePreview.Fill = new SolidColorBrush(Colors.LightGray);
            EllipsePreview.Stroke = new SolidColorBrush(Colors.Gray);

            EllipsePreview.StrokeThickness = 8;
            EllipsePreview.StrokeDashArray = new DoubleCollection() { 2 };
            EllipsePreview.StrokeDashCap = PenLineCap.Triangle;
            //

        }

        private void ElipseModel_MouseEnter(object sender, MouseEventArgs e) {

            

            if (SelectedCrip is CripWorker) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.DarkOrchid);
            }
            if (SelectedCrip is CripSolder) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.DodgerBlue);
            }
            if (SelectedCrip is CripDefender) {
                SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.LightSeaGreen);
            }

            int index = Ellipses.IndexOf((sender as Ellipse));

            SelectedCrip = Crips[index];

            LabelType.Content = SelectedCrip.ToString();
            LabelHp.Content = "Hp: " + SelectedCrip.Hp;
            LabelSpeed.Content = "Speed: " + SelectedCrip.Speed;


            if (SelectedCrip is CripWorker) {
                LabelSpecial.Content = "Absorbed: " + (SelectedCrip as CripWorker).Absorbed + "/" + (SelectedCrip as CripWorker).Cepacity;
            }
            if (SelectedCrip is CripSolder) {
                LabelSpecial.Content = "Attack: " + (SelectedCrip as CripSolder).Attack;
            }
            if (SelectedCrip is CripDefender) {
                LabelSpecial.Content = "Attack: " + (SelectedCrip as CripDefender).Attack;
            }

            SliderChange.Value = SelectedCrip.Speed;

            // Preview Ellipse
            EllipsePreview.Fill = SelectedCrip.ElipseModel.Fill.Clone();
            EllipsePreview.Stroke = SelectedCrip.ElipseModel.Stroke.Clone();

            EllipsePreview.StrokeThickness = SelectedCrip.ElipseModel.StrokeThickness;
            EllipsePreview.StrokeDashArray = SelectedCrip.ElipseModel.StrokeDashArray.Clone();
            EllipsePreview.StrokeDashCap = SelectedCrip.ElipseModel.StrokeDashCap;
            //

            SelectedCrip.ElipseModel.Stroke = new SolidColorBrush(Colors.Gold);


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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            /*

            if (SelectedCrip != null) {

                int max = 50;

                SelectedCrip.Hp = max - Convert.ToInt32((sender as Slider).Value) + 150;
                SelectedCrip.Speed = Convert.ToInt32((sender as Slider).Value);

                LabelHpToCepacityPrew.Content = SelectedCrip.Hp + " / " + SelectedCrip.Speed;
            }
            else {
                //LabelHpToCepacityPrew.Content = "200 / 50";
            }

        */

        }

        public void TimersAction(object obj) {

            try {
                this.Dispatcher.Invoke(() => {
                    move();
                });
            }
            catch (Exception ex) {

            }


        }

        public void button_Click(object sender, RoutedEventArgs e) {

            move();

        }

        public void move() {
            if (SelectedCrip != null) {
                //MessageBox.Show("as");
                Canvas.SetTop(SelectedCrip.ElipseModel, SelectedCrip.Location.X++);
                Canvas.SetLeft(SelectedCrip.ElipseModel, SelectedCrip.Location.Y++);
            }
        } 



        //finish
    }
}
