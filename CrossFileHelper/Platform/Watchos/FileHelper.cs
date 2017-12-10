using CrossFileHelper.Abstractions;
using CrossFileHelper.Platform.Common;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Platform
{
	public class FileHelper : IFileHelper
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
