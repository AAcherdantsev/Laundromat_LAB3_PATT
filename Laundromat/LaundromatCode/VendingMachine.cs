using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat {
	public class VendingMachine : IDevice
	{
		private Dictionary<Service, OperationMode> modes;

		private VendingMachineMode currentMode;

		private static int idCounter = 0;

		public VendingMachine()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			modes = new Dictionary<Service, OperationMode>();
			services = new List<Service>();
			addService(new ProductSelling(id, 20, "Кондиционер для белья \"Коричневый запах весны\""), new VendingMachineMode("Кондиционер", 1));
			addService(new ProductSelling(id, 30, "Стиральный порошок \"Белая радость\""), new VendingMachineMode("Порошок", 1));
		}

		public virtual String id
		{
			get
			{
				Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
				return "V" + idCounter.ToString(); 
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
			currentMode = (VendingMachineMode) modes[service];
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
