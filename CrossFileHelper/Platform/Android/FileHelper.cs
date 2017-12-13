using Android.App;
using Android.Content;
using CrossFileHelper.Abstractions;
using CrossFileHelper.Entities;
using CrossFileHelper.Platform.Android;
using CrossFileHelper.Platform.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using AndroidRuntime = Android.Runtime;

namespace CrossFileHelper.Platform
{
	/// <summary>
	/// File helper implementation for android
	/// </summary>
	[AndroidRuntime.Preserve(AllMembers = true)]
	class FileHelper : IFileHelper
	{
		private readonly Context _context;
		private int requestId;
		private TaskCompletionSource<FileData> _completionSource;

		public FileHelper()
		{
			_context = Application.Context;
		}

		public Task<System.IO.Stream> GetFileReadStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileReadStreamAsync(filePath);
		}

		public Task<System.IO.Stream> GetFileWriteStreamAsync(string filePath)
		{
			return FileHelperUtility.Instance.GetFileWriteStreamAsync(filePath);
		}

		public async Task<FileData> PickFile()
		{
			var media = await TakeMediaAsync("file/*", Intent.ActionGetContent);

			return media;
		}

		private int GetRequestId()
		{
			var id = requestId;
			if (requestId == int.MaxValue)
				requestId = 0;
			else
				requestId++;

			return id;
		}

		private Task<FileData> TakeMediaAsync(string type, string action)
		{
			var id = GetRequestId();

			var ntcs = new TaskCompletionSource<FileData>(id);

			if (Interlocked.CompareExchange(ref _completionSource, ntcs, null) != null)
				throw new InvalidOperationException("Only one operation can be active at a time");

			var pickerIntent = new Intent(this._context, typeof(FilePickerActivity));
			pickerIntent.SetFlags(ActivityFlags.NewTask);

			this._context.StartActivity(pickerIntent);

			EventHandler<FilePickerEventArgs> handler = null;
			EventHandler<EventArgs> cancelledHandler = null;

			handler = (s, e) =>
			{
				var tcs = Interlocked.Exchange(ref _completionSource, null);

				FilePickerActivity.FilePicked -= handler;

				tcs?.SetResult(new FileData(e.FilePath, e.FileName, () => System.IO.File.OpenRead(e.FilePath)));
			};

			cancelledHandler = (s, e) =>
			{
				var tcs = Interlocked.Exchange(ref _completionSource, null);

				FilePickerActivity.FilePickCancelled -= cancelledHandler;

				tcs?.SetResult(null);
			};

			FilePickerActivity.FilePickCancelled += cancelledHandler;
			FilePickerActivity.FilePicked += handler;


			return _completionSource.Task;
		}
	}
}
