using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace AppEsqueci.iOS
{
    class FileAcessHelper
    {
        public static string GeLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");
            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }
            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}