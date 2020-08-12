using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni2_Andreja_Kolesar.Model
{
    class Person
    {
        private string path = @"..\..\ClinicAccess.txt";
        public string username { get; set; }
        public string password { get; set; }

        public bool isMaster()
        {
            string[] lines = File.ReadAllLines(path);
            if(lines[0].Split(':')[1]==username && lines[1].Split(':')[1] == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
    }
}
