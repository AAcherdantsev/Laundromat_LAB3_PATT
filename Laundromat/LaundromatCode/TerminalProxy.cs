using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat {
	public class TerminalProxy : IPaymentDevice
	{
		private IPaymentDevice terminal;

		private void log(Payment payment)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
		}

        public TerminalProxy()
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			terminal = new Terminal();
        }

		public virtual void pay(Payment payment)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			log(payment);
			terminal.pay(payment);
		}
	}
}
