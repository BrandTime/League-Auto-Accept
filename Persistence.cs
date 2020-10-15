using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Conduit
{
    /**
     * Class responsible for handling filesystem persistence. In particular, this stores our JWT and keypairs.
     */
    class Persistence
    {
        public static string DATA_DIRECTORY = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ALi Auto Accept");

        static Persistence()
        {
            // Create directory if needed.
            if (!Directory.Exists(DATA_DIRECTORY)) Directory.CreateDirectory(DATA_DIRECTORY);
        }

    }
}
