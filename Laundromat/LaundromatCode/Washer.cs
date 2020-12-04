using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class Washer : IDevice
	{
		private Dictionary<Service, OperationMode> modes;

		private WasherMode currentMode;

		private static int idCounter = 0;

		public Washer()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			modes = new Dictionary<Service, OperationMode>();
			services = new List<Service>();
			addService(new Washing(id, 100, "Стирка быстрая, обычная, с отжимом"), new WasherMode(1, 900, 80, false, true));
			addService(new Washing(id, 100, "Стирка быстрая, обычная, без отжима"), new WasherMode(1, 900, 80, false, false));
			addService(new Washing(id, 100, "Стирка быстрая, деликатная"), new WasherMode(1, 600, 60, true, false));
			addService(new Washing(id, 150, "Стирка средней длительности, обычная, с отжимом"), new WasherMode(2, 900, 80, false, true));
			addService(new Washing(id, 150, "Стирка средней длительности, обычная, без отжима"), new WasherMode(2, 900, 80, false, false));
			addService(new Washing(id, 150, "Стирка средней длительности, деликатная"), new WasherMode(2, 600, 60, true, false));
			addService(new Washing(id, 200, "Стирка долгая, обычная, с отжимом"), new WasherMode(3, 900, 80, false, true));
			addService(new Washing(id, 200, "Стирка долгая, обычная, без отжима"), new WasherMode(3, 900, 80, false, false));
			addService(new Washing(id, 200, "Стирка долгая, деликатная"), new WasherMode(3, 600, 60, true, false));
		}

		public virtual String id
		{
			get
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return "W" + idCounter.ToString(); 
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
			currentMode = (WasherMode) modes[service];
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
