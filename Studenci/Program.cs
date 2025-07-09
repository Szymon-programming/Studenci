using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Studenci.Services;
using Studenci.UI;

namespace Studenci
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface Interface = new UserInterface();

            Interface.Run();

        }
    }
}
