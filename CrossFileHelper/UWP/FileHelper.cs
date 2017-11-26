using System.IO;
using System.Threading.Tasks;
using CrossFileHelper.Abstractions;

namespace CrossFileHelper.UWP
{
	/// <summary>
	/// File helper implementation for UWP
	/// </summary>
	class FileHelper : IFileHelper
	{
		public Task<Stream> GetFileReadStreamAsync(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Open);
			return Task<Stream>.Factory.StartNew(() => fileStream);
		}

		public Task<Stream> GetFileWriteStreamAsync(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
			return Task<Stream>.Factory.StartNew(() => fileStream);
		}
	}
}
