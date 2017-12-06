using CrossFileHelper.Abstractions;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Android
{
	/// <summary>
	/// File helper implementation for android
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

		//public async Task<string> PickFileAsync(string mimeType)
		//{
		//	if (!(await RequestStoragePermission()))
		//	{
		//		throw new FilePermissionException(Permission.Storage);
		//	}
		//	var media = await PickFileAsync(mimeType, Intent.ActionPick, null);

		//	if (options == null)
		//		options = new PickMediaOptions();

		//	//check to see if we picked a file, and if so then try to fix orientation and resize
		//	if (!string.IsNullOrWhiteSpace(media?.Path))
		//	{
		//		try
		//		{
		//			var originalMetadata = new ExifInterface(media.Path);

		//			if (options.RotateImage)
		//			{
		//				await FixOrientationAndResizeAsync(media.Path, options, originalMetadata);
		//			}
		//			else
		//			{
		//				await ResizeAsync(media.Path, options.PhotoSize, options.CompressionQuality, options.CustomPhotoSize, originalMetadata);
		//			}
		//			if (options.SaveMetaData && IsValidExif(originalMetadata))
		//			{
		//				try
		//				{
		//					originalMetadata?.SaveAttributes();
		//				}
		//				catch (Exception ex)
		//				{
		//					Console.WriteLine($"Unable to save exif {ex}");
		//				}
		//			}

		//			originalMetadata?.Dispose();
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine("Unable to check orientation: " + ex);
		//		}
		//	}

		//	return media;
		//}
	}
}
