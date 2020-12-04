using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Laundromat {
	public class Terminal : IPaymentDevice
	{
		public virtual void pay(Payment payment)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			if (payment.paymentType == "By cash")
			{
				payByCash(payment.total);
				giveChange();
			}
			else if (payment.paymentType == "By credit card")
				payByCreditCard(payment);
			else throw new Exception("Wrong payment method");

			printTheReceipt(payment);
		}

		protected virtual void payByCash(double total)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
		}

		protected virtual void payByCreditCard(Payment payment)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
		}

		protected virtual void printTheReceipt(Payment payment)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			String path = @"receipts\\\" + (DateTime.Now.Date.ToString().Remove(10) + 
				DateTime.Now.TimeOfDay.ToString() + ".txt").Replace('/', '.').Replace(':', '.');
			FileStream receipt = File.Create(path);
			receipt.Close();
		}

		protected virtual void giveChange()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
		}
	}
}
