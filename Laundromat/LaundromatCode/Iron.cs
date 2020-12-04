using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class Iron : IDevice
	{
		private Dictionary<Service, OperationMode> modes;

		private IronMode currentMode;

		private static int idCounter = 0;

		public Iron()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			modes = new Dictionary<Service, OperationMode>();
			services = new List<Service>();
			addService(new Ironing(id, 100, "Глажка утюгом, 15 минут"), new IronMode(15));
			addService(new Ironing(id, 150, "Глажка утюгом, 30 минут"), new IronMode(30));
			addService(new Ironing(id, 170, "Глажка утюгом, 60 минут"), new IronMode(60));
		}

		public virtual String id
		{
			get
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return "I" + idCounter.ToString(); 
			}
		}

		public void addService(Service service, OperationMode relatedMode)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			modes[service] = relatedMode;
			services.Add(service);
		}

		public virtual void startWorking(Service service)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			currentMode = (IronMode) modes[service];
			currentMode.turnOn();
		}

		public virtual void stopWorking()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			currentMode = null;
		}

		public virtual bool isAvailable()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			if (currentMode != null)
				return !currentMode.isBusy;
			else
				return true;
		}

		public virtual List<Service> services
		{
			get;
			private set;
		}

		public virtual String getDiscription(String serviceName)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			return services.Find(service => service.serviceName == serviceName).discription;
		}

	}
}