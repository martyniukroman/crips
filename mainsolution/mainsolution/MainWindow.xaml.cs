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
        Ellipse ElipseTmp;
        CripsAboveClass CripTmp = new CripWorker();
        int Counter = 0;

        public MainWindow() {
            InitializeComponent();

            //CripWorker test = new CripWorker();
           // mainelipse = test.ElipseModel;

        }

        private void button_Click(object sender, RoutedEventArgs e) {

            ElipseTmp = new Ellipse();

            //CripsAboveClass TESTCRIPTMP = CripTmp.Clone() as CripDefender; // kostil

            ElipseTmp = CripTmp.ElipseModel;
            ElipseTmp.Width = 50;
            ElipseTmp.Height = 50;

            Elipses.Add(ElipseTmp);
            Counter++;

            MessageBox.Show(Counter.ToString());

            Canvas.SetTop(Elipses[Counter - 1], 10*Counter);
            Canvas.SetLeft(Elipses[Counter - 1], 10*Counter);
            CanvasMain.Children.Add(Elipses[Counter - 1]);
        }
    }
}
