using Android.Media;
using CrossFileHelper.Abstractions;
using CrossFileHelper.Platform.Common;
using System.IO;
using System.Threading.Tasks;

namespace CrossFileHelper.Platform
{
	/// <summary>
	/// File helper implementation for android
	/// </summary>
	class FileHelper : IFileHelper
	{
		public Task<System.IO.Stream> GetFileReadStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileReadStreamAsync(filePath);
		}

		public Task<System.IO.Stream> GetFileWriteStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileWriteStreamAsync(filePath);
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
