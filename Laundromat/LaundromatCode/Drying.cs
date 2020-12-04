using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class Drying : Service
	{
		public Drying(String id, uint price, String discriptionText)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			deviceId = id;
			this.price = price;
			discription = discriptionText;
		}

		public override uint price
		{
			get;
			protected set;
		}

		public override String serviceName
		{
			get 
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return "Сушка"; 
			}
		}

		public override String deviceId
		{
			get;
			protected set;
		}

		public override String discription
		{
			get;
			protected set;
		}
	}
}
