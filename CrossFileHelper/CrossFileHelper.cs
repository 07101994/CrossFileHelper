﻿using CrossFileHelper.Abstractions;
using CrossFileHelper.Platform;
using System;

namespace CrossFileHelper
{
	/// <summary>
	/// Cross platform file helper
	/// </summary>
	public class CrossFileHelper
	{
		static Lazy<IFileHelper> implementation = new Lazy<IFileHelper>(() => CreateFileHelper(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		private CrossFileHelper() { }

		/// <summary>
		/// Gets if the plugin is supported on the current platform.
		/// </summary>
		public static bool IsSupported => implementation.Value == null ? false : true;

		/// <summary>
		/// Current plugin implementation to use
		/// </summary>
		public static IFileHelper Current
		{
			get
			{
				var ret = implementation.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		/// <summary>
		/// Create file helper
		/// </summary>
		/// <returns>IFileHelper</returns>
		static IFileHelper CreateFileHelper()
		{
			return new FileHelper();
		}

		internal static Exception NotImplementedInReferenceAssembly() =>
			new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

	}
}