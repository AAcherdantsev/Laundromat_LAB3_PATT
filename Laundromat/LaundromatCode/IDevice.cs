using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public interface IDevice
	{
		void startWorking(Service service);

		void stopWorking();

		bool isAvailable();

		String getDiscription(String serviceName);

		List<Service> services
		{
			get;
		}

		String id
		{
			get;
		}
	}
}
