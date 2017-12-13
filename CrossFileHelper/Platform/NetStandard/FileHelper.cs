using CrossFileHelper.Abstractions;
using CrossFileHelper.Entities;
using CrossFileHelper.Platform.Common;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Platform
{
	/// <summary>
	/// File helper implementation for .NET Standard
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

		public Task<FileData> PickFile()
		{
			throw new NotImplementedException();
		}
	}
}
