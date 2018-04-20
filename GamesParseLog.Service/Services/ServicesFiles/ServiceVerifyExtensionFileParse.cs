namespace GamesParseLog.Service.Services.ServicesFiles
{
    internal static class ServiceVerifyExtensionFileParse
    {
        internal static bool VerifyExtensionFileParse(string extension)
        {
            const string extensionType = "log";
            return extension == extensionType;
        }
    }
}