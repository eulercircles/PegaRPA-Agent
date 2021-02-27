using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegaRPA.Agent
{
	internal enum StateCancellationReasons
	{
		RequestingExit,
		RequestingReset,
		RequestingIdle
	}
}
