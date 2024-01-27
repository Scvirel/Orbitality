using System;
using System.IO;

namespace Orbitality.Client.Runtime
{
    public sealed class LoadFromFile : ILoadFromFile
    {
        public string Execute(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}