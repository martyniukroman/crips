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
        //Ellipse ElipseTmp;
        CripWorker CripWorkerTmp = new CripWorker();
        int Counter = 0;

        public MainWindow() {
            InitializeComponent();

            CripWorker test = new CripWorker();
           // mainelipse = test.ElipseModel;

        }

        private void button_Click(object sender, RoutedEventArgs e) {

            Ellipse ElipseTmp;
            ElipseTmp = new Ellipse();
                        //ElipseTmp = CripWorkerTmp.ElipseModel;


            Ellipse ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.Plum);
            ElipseModel.Stroke = new SolidColorBrush(Colors.SkyBlue);

            ElipseModel.StrokeThickness = 4;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Round;
            ElipseModel.Height = 50;
            ElipseModel.Width = 50;
            //Elipses.Add(ElipseTmp);
            Counter++;

           // MessageBox.Show(Counter.ToString());

            Canvas.SetTop(ElipseModel, 10*Counter);
            Canvas.SetLeft(ElipseModel, 10*Counter);
            CanvasMain.Children.Add(ElipseModel);
        }
    }
}
