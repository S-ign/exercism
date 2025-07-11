public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum) {
            case 1:
                return "goalie";
            case 8:
                return "midfielder";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";

        } 
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report) {
            case int i:
                return $"There are {i} supporters at the match.";
            case float f:
                return "";
            case string s:
                return s;
            case Foul foul:
                return foul.GetDescription();
            case Injury injury:
                return "Oh no! " +
                    injury.GetDescription() +
                    " Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                return manager.Club != null
                    ? $"{manager.Name} ({manager.Club})"
                    :manager.Name;
            default:
                return "";
        } 
    }
}
