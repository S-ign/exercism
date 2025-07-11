static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);
    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now > appointmentDate;
    public static bool IsAfternoonAppointment(DateTime appointmentDate) => appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;

    //Have I become obsessed with method-bodied members?
    public static string Description(DateTime appointmentDate) =>
        "You have an appointment on " + appointmentDate.ToString("M/d/yyyy h:mm:ss tt") + ".";

    //Le Gasp! :o
    //The Readme has been giving answers in method-bodied member notation! (kinda)
    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
}
