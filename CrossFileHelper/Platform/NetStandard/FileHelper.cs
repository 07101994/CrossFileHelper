using CrossFileHelper.Abstractions;
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
			throw new NotImplementedException();
		}

		public Task<Stream> GetFileWriteStreamAsync(string filePath)
		{
			throw new NotImplementedException();
		}
	}
}
