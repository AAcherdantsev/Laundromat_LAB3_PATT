using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundromat
{
    class ProductSelling : Service
    {
		public ProductSelling(String id, uint price, String discriptionText)
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
				return "Продажа средств для стирки"; 
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
