﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppEsqueci.Droid
{
    public class FileAcessHelper
    {
        public static string GeLocalFilePath(string filename)
        {
            string Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var connection = System.IO.Path.Combine(Path, filename);
            return connection;
        }
    }
}