using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Scheduler;

namespace WindowsPhone.Common.BackgroundAgent
{
	public class PeriodicAgentStarter
	{
		private PeriodicTask _periodicTask;
		private const string PeriodicTaskName = "BookteraAgent";
		public bool AgentsAreEnabled = true;

		public void StartPeriodicAgent()
		{
			// Variable for tracking enabled status of background agents for this app.
			AgentsAreEnabled = true;

			// Obtain a reference to the period task, if one exists
			_periodicTask = ScheduledActionService.Find(PeriodicTaskName) as PeriodicTask;

			// If the task already exists and background agents are enabled for the
			// application, you must remove the task and then add it again to update 
			// the schedule
			if(_periodicTask != null)
			{
				RemoveAgent(PeriodicTaskName);
			}

			_periodicTask = new PeriodicTask(PeriodicTaskName);

			// The description is required for periodic agents. This is the string that the user
			// will see in the background services Settings page on the device.
			_periodicTask.Description = "Booktera másodlagos csempe képek frissítése. ";

			// Place the call to Add in a try block in case the user has disabled agents
			try
			{
				ScheduledActionService.Add(_periodicTask);

				// If debugging is enabled, use LaunchForTest to launch the agent in 5s.
				ScheduledActionService.LaunchForTest(PeriodicTaskName, TimeSpan.FromSeconds(5));
			}
			catch(InvalidOperationException e)
			{
				if(e.Message.Contains("BNS Error: The action is disabled"))
				{
					MessageBox.Show("Background agents for this application have been disabled by the user.");
					AgentsAreEnabled = false;
				}
				if(e.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
				{
					// No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
				}
			}
			catch(SchedulerServiceException)
			{
				// No user action required.
			}

		}

		private void RemoveAgent(string name)
		{
			try
			{
				ScheduledActionService.Remove(name);
			}
			catch(Exception)
			{
			}
		}

	}
}
