using System;
using System.IO;

namespace Orbitality.Client.Runtime
{
    public sealed class SaveToFile : ISaveToFile
    {
        public void Execute(string path, string serializedData)
        {
            try
            {
                File.WriteAllText(path, serializedData);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}