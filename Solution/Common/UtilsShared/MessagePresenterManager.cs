using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using UtilsSharedPortable;

namespace UtilsShared
{
	public static class MessagePresenterManager
	{
		#region Console

		public static void WireToConsole()
		{
			MessagePresenter.WriteEvent += Console.Write;
			MessagePresenter.WriteLineEvent += Console.WriteLine;
			MessagePresenter.WriteLineSeparatorEvent += WriteLineSeparatorConsoleMethod;
			MessagePresenter.WriteExceptionEvent += Helpers.WriteWithInnerMessagesRed;
			MessagePresenter.WriteErrorEvent += WriteRed;
		}

		public static void DetachFromConsole()
		{
			MessagePresenter.WriteEvent -= Console.Write;
			MessagePresenter.WriteLineEvent -= Console.WriteLine;
			MessagePresenter.WriteLineSeparatorEvent -= WriteLineSeparatorConsoleMethod;
			MessagePresenter.WriteExceptionEvent -= Helpers.WriteWithInnerMessagesRed;
			MessagePresenter.WriteErrorEvent -= WriteRed;
		}

		private static void WriteLineSeparatorConsoleMethod()
		{
			Console.WriteLine("--------------------------");
		}

		private static void WriteRed(string msg)
		{
			GeneralFunctions.WithConsoleColor(ConsoleColor.Red, () => Console.WriteLine(msg));
		}

		#endregion
	
		#region RichTextBox

		public static void WireToRichTextBox(RichTextBox richTextBox, Dispatcher Dispatcher)
		{
			MessagePresenter.WriteEvent +=
				s => Dispatcher.Invoke(
					() =>
					{
						richTextBox.AppendText(s);
						richTextBox.ScrollToEnd();
					});

			MessagePresenter.WriteLineEvent +=
				s => Dispatcher.Invoke(
					() =>
					{
						richTextBox.AppendText(s);
						richTextBox.AppendText(Environment.NewLine);
						richTextBox.ScrollToEnd();
					});

			MessagePresenter.WriteLineSeparatorEvent +=
				() => Dispatcher.Invoke(
					() =>
					{
						richTextBox.AppendText("------------------");
						richTextBox.AppendText(Environment.NewLine);
						richTextBox.ScrollToEnd();
					});

			MessagePresenter.WriteExceptionEvent +=
				e => Dispatcher.Invoke(() => WriteLogRed(e.Message, richTextBox));

			MessagePresenter.WriteErrorEvent += 
				s => Dispatcher.Invoke(() => WriteLogRed(s, richTextBox));
		}

		private static void WriteLogRed(string msg, RichTextBox richTextBox)
		{
			var textRange = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
			textRange.Text = msg;
			textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);

			textRange = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
			textRange.Text = " ";
			textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);

			richTextBox.AppendText(Environment.NewLine);
			richTextBox.ScrollToEnd();
		}

		#endregion

		#region StringWriter

		public static void WireToStringWriter(StringWriter stringWriter)
		{
			MessagePresenter.WriteEvent += stringWriter.Write;
			MessagePresenter.WriteLineEvent += stringWriter.WriteLine;
			MessagePresenter.WriteLineSeparatorEvent += () => stringWriter.WriteLine("--------------------------");
			MessagePresenter.WriteErrorEvent += stringWriter.WriteLine;
			MessagePresenter.WriteExceptionEvent += e => stringWriter.Write(e.Message);
			
			// unfortunately, this method is not thread safe
			//MessagePresenter.WriteExceptionEvent +=
			//	e =>
			//	{
			//		// saving the original
			//		var consoleOut = Console.Out;

			//		// delegating to ours
			//		Console.SetOut(stringWriter);

			//		// here there are recursive methods implemented to seek InnerExceptions
			//		// with this Console.Out delegating trick we can get them by calling this
			//		e.WriteWithInnerMessagesRed();

			//		// setting back the original
			//		Console.SetOut(consoleOut);
			//	};
		}

		#endregion

	}
}
