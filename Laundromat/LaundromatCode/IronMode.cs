using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laundromat
{
    class IronMode : OperationMode
    {
        private Thread processing;

        private void run()
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            DateTime finishTime = DateTime.Now.AddSeconds(time);
            while (DateTime.Now < finishTime)
            {

            }
            Console.WriteLine("Время глажки окончено");
        }

        public IronMode(int time)
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            this.time = time;
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

        private int time = 10; 
    }
}
