using System.IO;
using System.Threading.Tasks;
using CrossFileHelper.Abstractions;
using CrossFileHelper.Entities;
using CrossFileHelper.Platform.Common;
using Windows.Storage.AccessCache;
using System;

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

		public async Task<FileData> PickFile()
		{
			var picker = new Windows.Storage.Pickers.FileOpenPicker
			{
				ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
				SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
			};
			picker.FileTypeFilter.Add("*");

			var file = await picker.PickSingleFileAsync();
			if (null == file)
				return null;

			StorageApplicationPermissions.FutureAccessList.Add(file);
			return new FileData(file.Path, file.Name, () => File.OpenRead(file.Path));
		}
	}
}
