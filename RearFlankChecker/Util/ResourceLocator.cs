using Advanced_Combat_Tracker;
using System.IO;

namespace RearFlankChecker.Util
{
    class ResourceLocator
    {
        public static string findResourcePath(string fileName)
        {
            var path = Path.Combine(
                ActGlobals.oFormActMain.AppDataFolder.FullName,
                fileName);

            if (File.Exists(path))
            {
                return path;
            }

            foreach (var item in ActGlobals.oFormActMain.ActPlugins)
            {
                if (item.pluginFile.Name.ToUpper() == "RearFlankChecker.dll".ToUpper() )
                {
                    path = Path.Combine(
                        Path.GetDirectoryName(item.pluginFile.FullName),
                        fileName);

                    if (File.Exists(path))
                    {
                        return path;
                    }
                    break;
                }
            }

            return File.Exists(fileName) ? fileName : null;
        }

    }

}
