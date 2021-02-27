using System;
using System.ComponentModel;
using System.Linq;

namespace PegaRPA.Agent.States
{
	internal abstract class State
	{
		private readonly BackgroundWorker _backgroundWorker;

		private readonly StateArgs _stateArgs;

		private EventHandler<TransitionStateEventArgs> _transitioning;
		internal event EventHandler<TransitionStateEventArgs> Transitioning
		{
			add
			{
				if (_transitioning == null || !_transitioning.GetInvocationList().Contains(value))
				{
					_transitioning += value;
				}
			}
			remove { _transitioning -= value; }
		}

		protected bool CancellationPending => _backgroundWorker.CancellationPending;
		protected StateCancellationReasons CancellationReason { get; private set; }

		internal abstract string ShortDescription { get; }

		#region Constructor(s)
		internal State(StateArgs stateArgs)
		{
			if (stateArgs == null) { throw new ArgumentException(nameof(stateArgs)); }

			_stateArgs = stateArgs;

			_backgroundWorker = new BackgroundWorker()
			{
				WorkerReportsProgress = false,
				WorkerSupportsCancellation = true
			};

			_backgroundWorker.DoWork += BackgroundWorker_DoWork;
			_backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
		}
		#endregion Constructor(s)

		#region Event Handlers
		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			throw new NotImplementedException();
		}
		#endregion Event Handlers

		#region Internal Methods

		#endregion Internal Methods

		#region Protected Methods
		protected abstract State DoWork(StateArgs stateArgs);

		protected void TriggerStateTransition(State nextState) => _transitioning?.Invoke(this, new TransitionStateEventArgs(nextState));
		#endregion Protected Methods

		#region Private Methods
		private void Completed(bool cancelled, Exception error, object result) => TriggerStateTransition((State)result);
		#endregion Private Methods
	}
}
