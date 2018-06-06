using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace mainsolution {

    struct CripLocation {
        public int x { set; get; }
        public int y { set; get;}
    }

     abstract public class CripsAboveClass{
        
        public int Hp { set; get; }     
        public int Speed { set; get; }

        public Point Location = new Point();
        public Ellipse ElipseModel { set; get; }

        public int Indeficator { set; get; }
        public static int IndeficatorCounter = 0;

        //todo async public void MoveTo();

        public void MoveTo(Point Destenation) {
            if (this.Location.X > Destenation.X) {
                this.Location.X++;
            }
            if (this.Location.X < Destenation.X) {
                this.Location.X--;
            }
            if (this.Location.Y > Destenation.Y) {
                this.Location.Y++;
            }
            if (this.Location.Y < Destenation.Y) {
                this.Location.Y--;
            }
        }

        public CripsAboveClass(){
            IndeficatorCounter++;
        }
        public Ellipse GetEllipse() {
            Ellipse e = new Ellipse();

            e.Fill = ElipseModel.Fill.Clone();
            e.Stroke = ElipseModel.Stroke.Clone() ;

            e.StrokeThickness = ElipseModel.StrokeThickness;
            e.StrokeDashArray = ElipseModel.StrokeDashArray.Clone();
            e.StrokeDashCap = ElipseModel.StrokeDashCap;
            return e;
        }
    }

    /*
     

        <Ellipse Width="50" Height="50" Fill="HotPink"
        StrokeThickness="4" StrokeDashArray="2"
        Stroke="DarkOrchid" StrokeDashCap="Round" />

        <Ellipse Width="50" Height="50" Fill="RoyalBlue"
        StrokeThickness="8" StrokeDashArray="2"
        Stroke="DodgerBlue" StrokeDashCap="Triangle" />

        <Ellipse Width="50" Height="50" Fill="MediumSeaGreen"
        StrokeThickness="5" StrokeDashArray="2"
        Stroke="LightSeaGreen" StrokeDashCap="Flat" />
     
    */

    class CripWorker : CripsAboveClass {

        public int Cepacity { set; get; }
        public int Absorbed { set; get; }

        public CripWorker() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Absorbed = 0;
            Hp = 200;
            Speed = 50;
            Cepacity = 50;

            ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.HotPink);
            ElipseModel.Stroke = new SolidColorBrush(Colors.DarkOrchid);

            ElipseModel.StrokeThickness = 4;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Round;
        }

        public override string ToString() {
            return "Worker";
        }

    }

    class CripSolder : CripsAboveClass {

        public int Attack { set; get; }

        public CripSolder() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Hp = 200;
            Speed = 50;
            Attack = 50;

            ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.RoyalBlue);
            ElipseModel.Stroke = new SolidColorBrush(Colors.DodgerBlue);

            ElipseModel.StrokeThickness = 8;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Triangle;
        }

        public override string ToString() {
            return "Solder";
        }

    }

    class CripDefender : CripsAboveClass {

        public int Attack { set; get; }

        public CripDefender() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Hp = 200;
            Speed = 50;
            Attack = 50;

            ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.MediumSeaGreen);
            ElipseModel.Stroke = new SolidColorBrush(Colors.LightSeaGreen);

            ElipseModel.StrokeThickness = 5;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Triangle;
        }

        public override string ToString() {
            return "Defender";
        }

    }

}
