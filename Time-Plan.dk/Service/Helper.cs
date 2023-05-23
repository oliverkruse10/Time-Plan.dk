using System.Text;

namespace Time_Plan.dk.Service
{
    public static class Helper
    {

        // Når vi benytter DateTime i C# så er det vigtigt at vi bruger den rigtige format, da det ellers kan give problemer. 
        // for at løse de problemer vi har mødt, har vi valgt at konvertere vores DateTime til en string og route den istedet
        // Her er der 4 methoder som konvertere mellem DateTime og string, så vi kan bruge dem i vores routes.

        public static DateTime StringToDate(string datetime)
        {
            DateTime dt = DateTime.ParseExact(datetime, "dd-MM-yyyy", null);
            return dt;
        }
        public static string DateToString(DateTime dt)
        {
            StringBuilder sb = new StringBuilder();
            if (dt.Day < 10)
                sb.Append("0");
            sb.Append(dt.Day);
            sb.Append("-");
            if (dt.Month < 10)
                sb.Append("0");
            sb.Append(dt.Month);
            sb.Append("-");
            sb.Append(dt.Year);
            return sb.ToString();
        }
        public static string Add7DaysToString(DateTime dt)
        {
            DateTime nydt = dt.AddDays(7);
            int i = nydt.Day;
            StringBuilder sb = new StringBuilder();
            if (i < 10)
                sb.Append("0");
            sb.Append(i);
            sb.Append("-");
            if (nydt.Month < 10)
                sb.Append("0");
            sb.Append(nydt.Month);
            sb.Append("-");
            sb.Append(nydt.Year);
            return sb.ToString();
        }

        public static string Remove7DaysToString(DateTime dt)
        {
            DateTime nydt = dt.AddDays(-7);
            int i = nydt.Day;
            StringBuilder sb = new StringBuilder();
            if (i < 10)
                sb.Append("0");
            sb.Append(i);
            sb.Append("-");
            if (nydt.Month < 10)
                sb.Append("0");
            sb.Append(nydt.Month);
            sb.Append("-");
            sb.Append(nydt.Year);
            return sb.ToString();
        }
    }
}
