using System.Globalization;

public static class HighSchoolSweethearts
{
    private static string asciiHeart = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     A. B.  +  C. D.     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";

    public static string DisplaySingleLine(string studentA, string studentB) =>
      $"                  {studentA} ♡ {studentB}                    ";

    public static string GetNameInitial(string name) {
        //split name into first and last name
        string[] fl = name.Split(" ");
        //get the first index being the first name and then the first letter for the first name
        char fi = fl[0][0];
        //get the second index being the second name and then the first letter of for the last name
        char li = fl[1][0];

        return $"{fi} {li}";
    }

    public static string DisplayBanner(string studentA, string studentB) {
        var leftInitial = GetNameInitial(studentA).Split(" ");
        var rightInitial = GetNameInitial(studentB).Split(" ");

        //Replace A - D with the initials
        asciiHeart = asciiHeart.Replace("A", leftInitial[0]);
        asciiHeart = asciiHeart.Replace("B", leftInitial[1]);
        asciiHeart = asciiHeart.Replace("C", rightInitial[0]);
        asciiHeart = asciiHeart.Replace("D", rightInitial[1]);
        return asciiHeart;
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        //define the format to write the date in
        string format = "dd.MM.yyyy";

        //define the culture to convert to
        var germanCulture = new CultureInfo("de-DE");

        //return the string converting date with the german CultureInfo
        //N2 (number 2 decimal places)
        //in germany the decimal and comma are inversed to how they are used in the US.
        //US - 1,535.22
        //DE - 1.535,22
        return $"{studentA} and {studentB} have been dating since {start.ToString(
                format, germanCulture)} - that's {hours.ToString("N2", germanCulture)} hours";
    }
}
