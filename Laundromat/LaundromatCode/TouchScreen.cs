using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class TouchScreen : IInputDevice
	{
		private Func<IEnumerable<Service>> servicesGetter;

		private Action<IEnumerable<Service>> servicesProcesser;

		public TouchScreen()
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
		}

		public virtual void processServices(IEnumerable<Service> services)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			servicesProcesser(services);
		}

		public virtual IEnumerable<Service> getAvailalbleServices()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			if (servicesGetter == null)
				throw new Exception("Touchscreen is not plugged in");
			return servicesGetter();
		}

		public virtual void displayPaymentInformation(Payment payment)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			throw new System.NotImplementedException();
		}

		public void plugToController(Func<IEnumerable<Service>> getServicesDelegate, Action<IEnumerable<Service>> processServicesDelegate)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			servicesGetter = getServicesDelegate;
			servicesProcesser = processServicesDelegate;
        }
	}
}
