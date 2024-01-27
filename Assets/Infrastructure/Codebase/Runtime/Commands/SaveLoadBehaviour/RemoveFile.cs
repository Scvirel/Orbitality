using System;
using System.IO;

namespace Orbitality.Client.Runtime
{
    public sealed class RemoveFile : IRemoveFile
    {
        public void Execute(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}