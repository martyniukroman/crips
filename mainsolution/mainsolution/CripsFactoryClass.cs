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

     abstract public class CripsAboveClass : ICloneable{
        
        public int Hp { set; get; }     
        public int Speed { set; get; }

        public Point Location = new Point();
        public Ellipse ElipseModel { set; get; }

        public int Indeficator { set; get; }
        public static int IndeficatorCounter = 0;

        //todo async public void MoveTo();

        public CripsAboveClass(){
            IndeficatorCounter++;
        }

        public object Clone() {

            IndeficatorCounter++;

            return new CripDefender() {

                Hp = this.Hp,
                Speed = this.Speed,
                ElipseModel = this.ElipseModel,
                Indeficator = IndeficatorCounter,
                Location = this.Location,

            };
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

    class CripWorker : CripsAboveClass , ICloneable {

        public int Cepacity { set; get; }

        public CripWorker() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

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

        public object Clone() {

            IndeficatorCounter++;

            return new CripWorker() {

                Hp = this.Hp,
                Speed = this.Speed,
                Cepacity = this.Cepacity,
                ElipseModel = this.ElipseModel,
                Indeficator = IndeficatorCounter,
                Location = this.Location,        

            };
        }
    }

    class CripSolder : CripsAboveClass, ICloneable {

        public int Attack { set; get; }

        public CripSolder() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Hp = 150;
            Speed = 50;
            Attack = 100;

            ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.RoyalBlue);
            ElipseModel.Stroke = new SolidColorBrush(Colors.DodgerBlue);

            ElipseModel.StrokeThickness = 8;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Triangle;
        }

        public object Clone() {

            IndeficatorCounter++;

            return new CripSolder() {

                Hp = this.Hp,
                Speed = this.Speed,
                Attack = this.Attack,
                ElipseModel = this.ElipseModel,
                Indeficator = IndeficatorCounter,
                Location = this.Location,

            };
        }
    }

    class CripDefender : CripsAboveClass, ICloneable {

        public int Attack { set; get; }

        public CripDefender() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Hp = 100;
            Speed = 100;
            Attack = 100;

            ElipseModel = new Ellipse();

            ElipseModel.Fill = new SolidColorBrush(Colors.MediumSeaGreen);
            ElipseModel.Stroke = new SolidColorBrush(Colors.LightSeaGreen);

            ElipseModel.StrokeThickness = 5;
            ElipseModel.StrokeDashArray = new DoubleCollection() { 2 };
            ElipseModel.StrokeDashCap = PenLineCap.Flat;
        }

        public object Clone() {

            IndeficatorCounter++;

            return new CripDefender() {

                Hp = this.Hp,
                Speed = this.Speed,
                Attack = this.Attack,
                ElipseModel = this.ElipseModel,
                Indeficator = IndeficatorCounter,
                Location = this.Location,

            };
        }
    }

}
