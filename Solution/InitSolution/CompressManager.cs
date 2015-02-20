using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCompress.Archive;
using SharpCompress.Common;
using UtilsLocal;
using UtilsSharedPortable;


namespace InitSolution
{
	public class CompressManager
	{
		public void Decompress(Stream archiveStream, string targetDirPath)
		{
			var archive = ArchiveFactory.Open(archiveStream);
			Decompress_Core(targetDirPath, archive);
		}

		public void Decompress(string archivePath, string targetDirPath)
		{
			var archive = ArchiveFactory.Open(archivePath);
			Decompress_Core(targetDirPath, archive);
		}

		private void Decompress_Core(string targetDirPath, IArchive archive)
		{
			var sb = new StringBuilder();
			sb.Append("Decompressed at: ").Append(DateTime.Now.ToString("yyyy MM dd")).Append(", ").AppendLine(DateTime.Now.ToString("T"))
				.Append("Base Directory: ").AppendLine(targetDirPath)
				.AppendLine("Content:").AppendLine();

			Action<IArchiveEntry> decompress =
				(entry) =>
				{
					entry.WriteToDirectory(targetDirPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
					sb.AppendLine(entry.FilePath);
				};

			foreach (var entry in archive.Entries.Where(entry => entry.IsDirectory))
				decompress(entry);

			foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
				decompress(entry);

			sb.AppendLine("---------");

			File.AppendAllText(Paths.InitSolution_log, sb.ToString());
		}
	}
}
