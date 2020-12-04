using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laundromat
{
    class WasherMode : OperationMode
    {
        private Thread processing;

        private void run()
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            DateTime finishTime;
            switch (soilingLevel)
            {
                case 1:
                    finishTime = DateTime.Now.AddSeconds(30);
                    break;
                case 2:
                    finishTime = DateTime.Now.AddSeconds(60);
                    break;
                case 3:
                    finishTime = DateTime.Now.AddSeconds(90);
                    break;
                default:
                    throw new Exception("Wrong soiling level value");
            }


            while (DateTime.Now < finishTime)
            {
                
            }
            Console.WriteLine("Стирка окончена");
        }

        public WasherMode(int soilingLevel, int maxSpeed, int temperature, bool delicate, bool spin)
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            this.soilingLevel = soilingLevel;
            this.maxSpeed = maxSpeed;
            this.temperature = temperature;
            this.delicate = delicate;
            this.spin = spin;
            processing = new Thread(new ThreadStart(run));
        }

        public override void turnOn()
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            processing.Start();
        }

        public override void turnOff()
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            processing.Abort();
        }

        public override bool isBusy
        {
            get 
            {
                Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
                return processing.IsAlive; 
            }
        }

        private int soilingLevel = 3;

        private int maxSpeed = 900;

        private int temperature = 60;

        private bool delicate = false;

        private bool spin = true;

    }
}
