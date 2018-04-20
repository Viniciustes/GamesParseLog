using System.IO;
using System.Linq;
using System.Web;

namespace GamesParseLog.Service.Services.ServicesFiles
{
    internal class ServiceFileUpload
    {
        private readonly ServiceFileSystem _serviceFileSystem;

        public ServiceFileUpload()
        {
            _serviceFileSystem = new ServiceFileSystem();
        }

        public string[] Upload(HttpFileCollectionBase files)
        {
            var diskBasepath = HttpContext.Current.Server.MapPath("~/");
            var appBasepath = HttpContext.Current.Server.MapPath("~/FilesUploads/");
            var directoryPath = Path.Combine(diskBasepath, appBasepath);
            var filename = files[0].FileName.Contains("\\") ? files[0].FileName.Split('\\').Last() : files[0].FileName;
            var fname = Path.Combine(directoryPath, filename);

            _serviceFileSystem.CreateDirectory(directoryPath);
            _serviceFileSystem.Save(files[0], fname);

            return new[] { filename, Path.GetExtension(filename).Replace(".", ""), fname };
        }
    }
}