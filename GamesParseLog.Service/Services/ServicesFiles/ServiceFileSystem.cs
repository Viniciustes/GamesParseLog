using System.IO;
using System.Web;

namespace GamesParseLog.Service.Services.ServicesFiles
{
    internal class ServiceFileSystem
    {
        public void Save(HttpPostedFileBase file, string filename)
        {
            file.SaveAs(filename);
        }

        public DirectoryInfo CreateDirectory(string directoryName)
        {
            return Directory.CreateDirectory(directoryName);
        }
    }
}