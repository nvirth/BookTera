﻿using System;
using System.Threading;
using log4net;
using UtilsSharedPortable;

namespace UtilsLocal.Log
{
	public class BookteraLogger
	{
		private ILog _logger;
		private const string USERNAME_LOGENTRY = "User";
		private const string MAIN_TITLE = "BookTera";

		public BookteraLogger(string name = null)
		{
			name = name ?? MAIN_TITLE;

			_logger = LogManager.GetLogger(name);
			log4net.Config.XmlConfigurator.Configure();
		}

		public void AddUserIdentityToLog(Exception e)
		{
			var userName = Thread.CurrentPrincipal.Identity.Name;
			userName = string.IsNullOrWhiteSpace(userName) ? "(unauthenticed)" : userName;

			e.AddData(USERNAME_LOGENTRY, userName);
		}

		public void LogException(string msg, Exception e, object data = null)
		{
			MessagePresenter.WriteError(msg);
			if(data != null)
			{
				var dataSerialized = data.SerializeToLog();
				MessagePresenter.WriteError(dataSerialized);
				e.AddData(dataSerialized);
			}
			MessagePresenter.WriteException(e);
			Error(msg, e);


			//if(data != null)
			//	foreach(var d in data)
			//	{
			//		MessagePresenter.WriteError(d.SerializeToLog());
			//		e.AddLogData(d);
			//	}
		}

		public void LogError(string msg, object data = null)
		{
			MessagePresenter.WriteError(msg);
			if(data != null)
			{
				var dataSerialized = data.SerializeToLog();
				MessagePresenter.WriteError(dataSerialized);
				msg += Environment.NewLine + dataSerialized;
			}
			Error(msg);
		}

		#region ILog Adapter

		private void Debug(object message)
		{
			_logger.Debug(message);
		}

		private void Debug(object message, Exception exception)
		{
			AddUserIdentityToLog(exception);
			_logger.Debug(message, exception);
		}

		private void Info(object message)
		{
			_logger.Info(message);
		}

		private void Info(object message, Exception exception)
		{
			AddUserIdentityToLog(exception);
			_logger.Info(message, exception);
		}

		private void Warn(object message)
		{
			_logger.Warn(message);
		}

		private void Warn(object message, Exception exception)
		{
			AddUserIdentityToLog(exception);
			_logger.Warn(message, exception);
		}

		private void Error(object message)
		{
			_logger.Error(message);
		}

		private void Error(object message, Exception exception)
		{
			AddUserIdentityToLog(exception);
			_logger.Error(message, exception);
		}

		private void Fatal(object message)
		{
			_logger.Fatal(message);
		}

		private void Fatal(object message, Exception exception)
		{
			AddUserIdentityToLog(exception);
			_logger.Fatal(message, exception);
		}

		#endregion

	}
}