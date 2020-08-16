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

        public static bool ValidPassword(string psw)
        {
            if (psw.Length < 8)
            {
                return false;
            }
            else
            {
                int upper = 0;
                int lower = 0;
                int number = 0;
                int special = 0;
                for (int i = 0; i < psw.Length; i++)
                {
                    if (psw[i] >= 48 && psw[i] <= 57)
                    {
                        number++;
                    }
                    else if (psw[i] >= 65 && psw[i] < 90)
                    {
                        upper++;
                    }
                    else if (psw[i] >= 97 && psw[i] < 122)
                    {
                        lower++;
                    }
                    else
                    {
                        special++;
                    }
                }
                if (upper > 0 && lower > 0 && special > 0 && number > 0)
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
}
