using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class Payment
	{
		private IEnumerable<Service> goods;
		
		public Payment(IEnumerable<Service> goods, String paymentType)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			this.paymentType = paymentType;
			this.goods = goods;
        }

		public virtual double total
		{
			get 
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return goods.Sum(product => product.price); 
			}
		}

		public virtual String paymentType
		{
			get;
			private set;
		}

	}
}
