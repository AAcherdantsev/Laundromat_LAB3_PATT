using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat {
	public class SystemController
	{
		private List<IDevice> devices;

		private IInputDevice inputDevice;

		private IPaymentDevice paymentDevice;

		private void runDevice(String deviceId, Service service)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			getDevice(deviceId).startWorking(service);
		}

		private IDevice getDevice(String deviceId)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			return devices.Find(device => device.id == deviceId);
		}

		private void configureModes()
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			throw new System.NotImplementedException();
		}

		private void placePayment(IEnumerable<Service> services)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			try 
			{ 
				paymentDevice.pay(new Payment(services, "By cash"));
				foreach (Service service in services)
					runDevice(service.deviceId, service);
			}
            catch (Exception)
            {
					
            }

		}

        public SystemController()
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			devices = new List<IDevice>();
		}

		public void plugInputDevice(IInputDevice device)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			inputDevice = device;
			device.plugToController(getAvailableServices, placePayment);
		}

		public void plugPaymentDevice(IPaymentDevice device)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			paymentDevice = device;
			//device.plugToController();
		}

		public IEnumerable<Service> getAvailableServices()
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			List<Service> serviceList = new List<Service>();
			IDevice[] availableDevices = devices.Where(device => device.isAvailable()).ToArray();
			foreach (IDevice device in availableDevices)
				serviceList.AddRange(device.services);
			return serviceList;
		}

		public void addDevice(IDevice device)
        {
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			devices.Add(device);
        }

		public void eraseDevice(String id)
		{
			Console.WriteLine(this.GetType() + "_" + this.GetHashCode() + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
			devices.Remove(devices.Find(device => device.id == id));
		}
	}
}
