using System;

using PegaRPA.Agent.States;

namespace PegaRPA.Agent
{
	internal class TransitionStateEventArgs : EventArgs
	{
		internal State NextState { get; }

		internal TransitionStateEventArgs(State nextState) => NextState = nextState;
	}
}
