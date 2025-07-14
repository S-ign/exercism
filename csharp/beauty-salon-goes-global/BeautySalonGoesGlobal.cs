using System.Globalization;

public enum Location
{
    NewYork = 0,
    London  = 1,
    Paris   = 2
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    private static readonly Dictionary<Location, string> TimeZoneMap = new() {
        {Location.NewYork, "Eastern Standard Time"},
        {Location.London,  "GMT Standard Time"},
        {Location.Paris,   "W. Europe Standard Time"},
    };

    public static TimeZoneInfo GetTimeZone(Location location) =>
        TimeZoneInfo.FindSystemTimeZoneById(TimeZoneMap[location]);

    private static CultureInfo GetCultureInfo(Location location) =>
        location switch {
            Location.NewYork => new CultureInfo("en-US"),  // MM/dd/yyyy
            Location.London  => new CultureInfo("en-GB"),  // dd/MM/yyyy
            Location.Paris   => new CultureInfo("fr-FR"),  // dd/MM/yyyy
            _ => CultureInfo.InvariantCulture
        };

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var unspcifiedTime = DateTime.SpecifyKind(DateTime.Parse(appointmentDateDescription),
                DateTimeKind.Unspecified);
        var timeZone = GetTimeZone(location);
        return TimeZoneInfo.ConvertTimeToUtc(unspcifiedTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch {
            AlertLevel.Early    => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.Add(new TimeSpan(-1, -45, 0)),
            AlertLevel.Late     => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), "Wrong AlertLevel")
        };
        
    public static bool HasDaylightSavingChanged(DateTime dt, Location location) {
        var timeZone = GetTimeZone(location);
        var current = TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(
                    dt, DateTimeKind.Unspecified), timeZone);

        var past = TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(
                dt.AddDays(-7), DateTimeKind.Unspecified), timeZone);

        return timeZone.IsDaylightSavingTime(current) != timeZone.IsDaylightSavingTime(past);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location) {
        var culture = GetCultureInfo(location);

        if (!DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime parsedDateTime))
            return DateTime.MinValue;

        return parsedDateTime;

    }
}
