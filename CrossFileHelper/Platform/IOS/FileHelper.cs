using CrossFileHelper.Abstractions;
using CrossFileHelper.Entities;
using CrossFileHelper.Platform.Common;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Platform
{
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

		public Task<FileData> PickFile()
		{
			throw new System.NotImplementedException();
		}
	}
}
