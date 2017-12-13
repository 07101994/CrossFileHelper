using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System;
using AndroidNet = Android.Net;
using AndroidContent = Android.Content;
using Android.Provider;
using CrossFileHelper.Entities;

namespace CrossFileHelper.Platform.Android
{
	[Activity(ConfigurationChanges = AndroidContent.PM.ConfigChanges.Orientation | AndroidContent.PM.ConfigChanges.ScreenSize)]
	[Preserve(AllMembers = true)]
	public class FilePickerActivity : Activity
	{
		private Context context;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			context = Application.Context;


			var intent = new Intent(Intent.ActionGetContent);
			intent.SetType("*/*");

			intent.AddCategory(Intent.CategoryOpenable);
			try
			{
				StartActivityForResult(Intent.CreateChooser(intent, "Select file"), 0);
			}
			catch (Exception exAct)
			{
				Console.Write(exAct);
			}
		}

		protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Canceled)
			{
				// Notify user file picking was cancelled.
				OnFilePickCancelled();
				Finish();
			}
			else
			{
				Console.Write(data.Data);
				try
				{
					var _uri = data.Data;

					var filePath = IOUtil.getPath(context, _uri);

					if (string.IsNullOrEmpty(filePath))
						filePath = _uri.Path;

					var file = IOUtil.readFile(filePath);

					var fileName = GetFileName(context, _uri);

					OnFilePicked(new FilePickerEventArgs(file, fileName, filePath));
				}
				catch (Exception readEx)
				{
					// Notify user file picking failed.
					OnFilePickCancelled();
					Console.Write(readEx);
				}
				finally
				{
					Finish();
				}
			}
		}

		string GetFileName(Context ctx, AndroidNet.Uri uri)
		{

			string[] projection = { MediaStore.MediaColumns.DisplayName };

			var cr = ctx.ContentResolver;
			var name = "";
			var metaCursor = cr.Query(uri, projection, null, null, null);

			if (metaCursor != null)
			{
				try
				{
					if (metaCursor.MoveToFirst())
					{
						name = metaCursor.GetString(0);
					}
				}
				finally
				{
					metaCursor.Close();
				}
			}
			return name;
		}

		internal static event EventHandler<FilePickerEventArgs> FilePicked;
		internal static event EventHandler<EventArgs> FilePickCancelled;

		private static void OnFilePickCancelled()
		{
			FilePickCancelled?.Invoke(null, null);
		}

		private static void OnFilePicked(FilePickerEventArgs e)
		{
			FilePicked?.Invoke(null, e);
		}
	}
}