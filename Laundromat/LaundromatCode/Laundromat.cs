using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundromat
{
    class Laundromat
    {
        static void Main(string[] args)
        {
            TouchScreen screen = new TouchScreen();
            TerminalProxy terminal = new TerminalProxy();
            SystemController controller = new SystemController();
            controller.plugInputDevice(screen);
            controller.plugPaymentDevice(terminal);

            controller.addDevice(new Washer());
            controller.addDevice(new Dryer());
            controller.addDevice(new Iron());
            controller.addDevice(new VendingMachine());

            List<Service> services = screen.getAvailalbleServices().ToList();
            screen.processServices(services.GetRange(8, 2));
        }
    }
}
