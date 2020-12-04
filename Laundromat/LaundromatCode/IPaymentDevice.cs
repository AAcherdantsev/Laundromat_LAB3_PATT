using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat {
	public interface IPaymentDevice
	{
		void pay(Payment payment);
	}
}

