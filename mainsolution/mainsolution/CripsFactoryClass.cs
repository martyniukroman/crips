﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace mainsolution {

    struct CripLocation {
        public int x { set; get; }
        public int y { set; get;}
    }

     abstract class CripsAboveClass {
        
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
    }

    class CripWorker : CripsAboveClass {

        public int Cepacity { set; get; }

        public CripWorker() {

            Indeficator = IndeficatorCounter;

            Location.X = 50;
            Location.Y = 50;

            Hp = 300;
            Speed = 50;
            Cepacity = 100;

            ElipseModel = new Ellipse();
        }

    }

}
