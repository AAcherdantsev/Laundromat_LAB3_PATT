using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat {
	public interface IInputDevice
	{
		void processServices(IEnumerable<Service> services);

		IEnumerable<Service> getAvailalbleServices();

		void displayPaymentInformation(Payment payment);

		void plugToController(Func<IEnumerable<Service>> getServicesDelegate, Action<IEnumerable<Service>> processServicesDelegate);

	}
}
