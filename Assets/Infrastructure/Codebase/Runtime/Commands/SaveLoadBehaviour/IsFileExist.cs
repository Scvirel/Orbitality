using System;
using System.IO;

namespace Orbitality.Client.Runtime
{
    public sealed class IsFileExist : IIsFileExist
    {
        public bool Execute(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}