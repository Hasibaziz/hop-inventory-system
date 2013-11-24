using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace ERP.Utility
{
    public class Autovalue
    {
        public static string Fornullvalue(String location)
        {
             if (location == "HLBD") {
                    string hlbd = string.Empty;
                    hlbd = "110000000001";
                   return hlbd;
                }
                else if (location == "HYBD") {
                    string hybd = string.Empty;
                    hybd = "120000000001";
                    return hybd;
                }
                else if (location == "HLWF") {
                    string hlwf = string.Empty;
                    hlwf = "130000000001";
                   return hlwf;
                }
                else if (location == "HLAP") {
                    string hlap = string.Empty;
                    hlap = "210000000001";
                    return hlap;
                }
                else if (location == "HLRC") {
                    string hlrc = string.Empty;
                    hlrc = "220000000001";
                    return hlrc;
                }
                else if (location == "HLST")
                 {
                     string hlst = string.Empty;
                     hlst = "230000000001";
                     return hlst;
                  }
                 else
                 {
                     string hlnt = string.Empty;
                     hlnt = "240000000001";
                     return hlnt;
                 }
        }
        public static string FornullvalueLocID(String locationid)
        {
            if (locationid == "67b5ae51-0723-4761-8aff-98b4ea8b8574")    //HLBD
            {
                string hlbd = string.Empty;
                hlbd = "110000000001";
                return hlbd;
            }
            else if (locationid == "946a6e67-e961-4384-928c-eec1b655bcb9")  //HYBD
            {
                string hybd = string.Empty;
                hybd = "120000000001";
                return hybd;
            }
            else if (locationid == "43a6c32b-2c69-4e68-9d6c-194b1e1e7799")  //HLWF
            {
                string hlwf = string.Empty;
                hlwf = "130000000001";
                return hlwf;
            }
            else if (locationid == "272b00a9-475a-43a2-9dee-bbbec8d0f42f")   //HLAP
            {
                string hlap = string.Empty;
                hlap = "210000000001";
                return hlap;
            }
            else if (locationid == "82fde6b4-33b1-43b4-8a80-01af640d55ad")   //HLRC
            {
                string hlrc = string.Empty;
                hlrc = "220000000001";
                return hlrc;
            }
            else if (locationid == "17995c35-d1a9-4310-bda1-a7c1ec66a95c")   //HLST
            {
                string hlst = string.Empty;
                hlst = "230000000001";
                return hlst;
            }
            else                                                             //HLNT
            {
                string hlnt = string.Empty;
                hlnt = "240000000001";
                return hlnt;
            }
        }
        public static string GetNextValue(string enumber)
        {
            //return String.Format("STD{0:D6}", Convert.ToInt32(enumber.Substring(3)) + 1);
            //return String.Format("{4:D12}", Convert.ToInt32(enumber.Substring(9)) + 1);
            string prefix = enumber.Substring(0, 3);
            return prefix + String.Format("{0:D9}", Convert.ToInt32(enumber.Substring(9)) + 1);
            //String _val = prefix + Convert.ToInt32(enumber.Substring(9) + 1);
            //return _val;
        }

        public static string AutoITRFValue(String location)
        {
            if (location == "HLBD")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else if (location == "HYBD")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else if (location == "HLWF")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else if (location == "HLAP")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else if (location == "HLRC")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else if (location == "HLST")
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
            else
            {
                string SYSDate = location + DateTime.Now.ToString("ddMMyymm");
                string val = SYSDate.Substring(4, SYSDate.Length - 4);
                int value = Convert.ToInt32(val) + 1;
                SYSDate = location + value;
                return SYSDate;
            }
        }


    }
}