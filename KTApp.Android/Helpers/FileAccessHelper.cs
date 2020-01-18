using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KTApp.Droid.Helpers
{
	public class FileAccessHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var dbPath = Path.Combine(path, filename);

			CopyDatabaseIfNotExists(dbPath);

			return dbPath;
		}

		private static void CopyDatabaseIfNotExists(string dbPath)
		{
			if (!File.Exists(dbPath))
			{
				using var br = new BinaryReader(Application.Context.Assets.Open("UKTA.db"));
				using var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create));

				var buffer = new byte[2048];
				var length = 0;
				while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
				{
					bw.Write(buffer, 0, length);
				}
			}
		}
	}

}