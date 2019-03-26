using System;
using System.Text;

namespace CodeGenerator
{
    static public class Generator
    {
        static public string Encode(string name, DateTime date, uint account)
        {
            return GetCorrectName(name) + GetEncodeDate(date) + GetEncodeAccount(account);
        }

        static public (string, DateTime, uint) Decode(string code)
        {
            if (code.Length < 11)
                throw new ArgumentException("Сode length must be greater than 10");            
            return (GetName(code), GetDecodeDate(code), GetDecodeAccount(code));
        }

        static private string GetCorrectName(string name)
        {
            return (name.Length > 8)? name.Substring(0, 8):name;
        }

        static private string GetEncodeDate(DateTime date)
        {
            StringBuilder result= new StringBuilder();
            result.Append(Base36.Encode(date.Day));
            result.Append(Base36.Encode(date.Month));
            int tmpYear = date.Year - 2000;
            if (tmpYear > 1295)
                throw new ArgumentOutOfRangeException("Cannot represent the year.");
            string tmpStr = Base36.Encode(tmpYear);
            tmpStr = tmpStr.PadLeft(2,'0');
            result.Append(tmpStr);
            return result.ToString();
        }

        static private string GetEncodeAccount(uint account)
        {
            string result = "";
            if(account>99999999 && account<1)
                throw new ArgumentOutOfRangeException("Cannot represent the account.");
            result = Base36.Encode((int)account);
            result = result.PadLeft(6,'0');
            return result;
        }

        static private string GetName(string code)
        {
            return code.Substring(0,code.Length-10);
        }

        static private DateTime GetDecodeDate(string code)
        {
            string tmpDay = code.Substring(code.Length - 10, 1);
            string tmpMonth = code.Substring(code.Length - 9, 1);
            string tmpYear = code.Substring(code.Length - 8, 2);
            tmpDay = Base36.Decode(tmpDay).ToString().PadLeft(2,'0');
            tmpMonth = Base36.Decode(tmpMonth).ToString().PadLeft(2,'0');
            tmpYear = (2000 + Base36.Decode(tmpYear)).ToString();
            return DateTime.ParseExact(tmpDay + tmpMonth + tmpYear, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        static private uint GetDecodeAccount(string code)
        {
            return (uint)Base36.Decode(code.Substring(code.Length - 6));
        }
    }
}
