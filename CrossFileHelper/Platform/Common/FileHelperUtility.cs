using System;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Platform.Common
{
	public class FileHelperUtility
    {
		private FileHelperUtility() { }

		private static Lazy<FileHelperUtility> _instance = new Lazy<FileHelperUtility>(() => new FileHelperUtility());

		public static FileHelperUtility Instance
		{
			get { return _instance.Value; }
		}

		public Task<Stream> GetFileReadStreamAsync(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open);
			return Task<System.IO.Stream>.Factory.StartNew(() => fileStream);
		}

		public Task<System.IO.Stream> GetFileWriteStreamAsync(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
			return Task<System.IO.Stream>.Factory.StartNew(() => fileStream);
		}
	}
}
