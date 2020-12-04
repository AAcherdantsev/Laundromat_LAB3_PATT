using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public class Dryer : IDevice
	{
		private Dictionary<Service, OperationMode> modes;

		private DryerMode currentMode;

		private static int idCounter = 0;

		public Dryer()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()"); modes = new Dictionary<Service, OperationMode>();
			services = new List<Service>();
			addService(new Drying(id, 70, "Сушка в сушильной машинке, 30 минут, низкая темереатура"), new DryerMode(40, 30));
			addService(new Drying(id, 125, "Сушка в сушильной машинке, 60 минут, низкая темереатура"), new DryerMode(40, 60));
			addService(new Drying(id, 150, "Сушка в сушильной машинке, 90 минут, низкая темереатура"), new DryerMode(40, 90));
			addService(new Drying(id, 70, "Сушка в сушильной машинке, 30 минут, высокая темереатура"), new DryerMode(60, 30));
			addService(new Drying(id, 125, "Сушка в сушильной машинке, 60 минут, высокая темереатура"), new DryerMode(60, 60));
			addService(new Drying(id, 150, "Сушка в сушильной машинке, 90 минут, высокая темереатура"), new DryerMode(60, 90));
		}

		public virtual String id
		{
			get
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return "D" + idCounter.ToString(); 
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
			currentMode = (DryerMode) modes[service];
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
