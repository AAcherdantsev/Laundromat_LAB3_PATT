using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laundromat
{
	public abstract class Service
	{
		public virtual String serviceName
		{
			get;
			set;
		}

		public virtual uint price
		{
			get;
			protected set;
		}

		public virtual String deviceId
		{
			get;
			protected set;
		}

		public virtual String discription
        {
			get;
			protected set;
        }
	}
}
