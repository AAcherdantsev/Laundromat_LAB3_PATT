using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laundromat
{
    class VendingMachineMode : OperationMode
    {
        private Thread processing;

        private void run()
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            Console.WriteLine("Выдача продукта " + productName);
        }

        public VendingMachineMode(String productName, int amount)
        {
            Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            this.productName = productName;
            this.amount = amount;
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

        private String productName;

        private int amount;
    }
}
