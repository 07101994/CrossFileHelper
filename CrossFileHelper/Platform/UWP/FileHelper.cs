using System.IO;
using System.Threading.Tasks;
using CrossFileHelper.Abstractions;
using CrossFileHelper.Entities;
using Windows.Storage.AccessCache;
using System;
using Windows.Storage;

namespace CrossFileHelper.Platform
{
	/// <summary>
	/// File helper implementation for UWP
	/// </summary>
	class FileHelper : IFileHelper
	{
		public async Task<Stream> GetFileReadStreamAsync(string filePath)
		{
			StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
			StorageFile sampleFile = await storageFolder.GetFileAsync(filePath);
			return await sampleFile.OpenStreamForReadAsync();
		}

		public async Task<Stream> GetFileWriteStreamAsync(string filePath)
		{
			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			StorageFile saveFile = await localFolder.CreateFileAsync(filePath, CreationCollisionOption.ReplaceExisting);
			return await saveFile.OpenStreamForWriteAsync();
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
			return new FileData(file.Path, file.Name, () => File.OpenRead(file.Path), null, await file.OpenStreamForReadAsync());
		}
	}
}
