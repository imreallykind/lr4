using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kabachok
{
    public class Kabachok
    {
        public string GetResult(string input)
        {
            char Operation = ' ';
            bool flag = false;
            string a = "", b = "";
            string str = input;
            foreach (char s in str)
            {
                if (Char.IsDigit(s) == true)
                {
                    if (!flag)
                        a += s.ToString();
                    else
                        b += s.ToString();
                }
                else
                {
                    flag = true;
                    Operation = s;
                }
            }
            //MessageBox.Show(a+"$"+Operation.ToString()+"$"+b);
            string output = "$";
            if (a.Length < 9 && a.Length != 0 && b.Length < 9 && b.Length != 0)
            {
                switch (Operation)
                {
                    case '+': output = (Int32.Parse(a) + Int32.Parse(b)).ToString(); break;
                    case '-': output = (Int32.Parse(a) - Int32.Parse(b)).ToString(); break;
                    case '*': output = (Int32.Parse(a) * Int32.Parse(b)).ToString(); break;
                    case '/': output = (Int32.Parse(a) / Int32.Parse(b)).ToString(); break;
                    default:
                        break;
                }
                //IsOperation = false;
                //Properties.Settings.Default.save = output;
                //Properties.Settings.Default.Save();
            }
            return output;
        }
    }
}
