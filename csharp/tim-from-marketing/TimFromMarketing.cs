static class Badge
{
    public static string Print(int? id, string name, string? department)
    {

        string badge = "";
        if (id == null) {
        }  else {
            badge = "["+(id ?? 0).ToString()+"] - ";
        } 

        string dep = "";
        if (department == null) {
            dep = "OWNER";
        } else {
            dep = department.ToUpper();
        } 

        return badge + name + " - " + dep;
    }
}
