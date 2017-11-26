using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Abstractions
{
	/// <summary>
	/// File helper interface
	/// </summary>
	public interface IFileHelper
    {
		/// <summary>
		/// Get file write stream async
		/// </summary>
		/// <param name="filePath">Path of file to write</param>
		/// <returns>Stream</returns>
		Task<Stream> GetFileWriteStreamAsync(string filePath);

		/// <summary>
		/// Get file read stream async
		/// </summary>
		/// <param name="filePath">Path of file to read</param>
		/// <returns>Stream</returns>
		Task<Stream> GetFileReadStreamAsync(string filePath);
    }
}
