using System.IO;
using System.Threading.Tasks;
using CrossFileHelper.Abstractions;
using CrossFileHelper.Platform.Common;

namespace CrossFileHelper.Platform
{
	/// <summary>
	/// File helper implementation for UWP
	/// </summary>
	class FileHelper : IFileHelper
	{
		public Task<Stream> GetFileReadStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileReadStreamAsync(filePath);
		}

		public Task<Stream> GetFileWriteStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileWriteStreamAsync(filePath);
		}
	}
}
