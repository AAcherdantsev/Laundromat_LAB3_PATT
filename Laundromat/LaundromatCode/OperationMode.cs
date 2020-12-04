using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public abstract class OperationMode
	{
		public virtual void turnOn()
		{
			throw new System.NotImplementedException();
		}

		public virtual void turnOff()
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isBusy
        {
			get;
        }
	}
}
