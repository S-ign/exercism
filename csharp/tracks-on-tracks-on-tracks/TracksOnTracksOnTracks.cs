public static class Languages
{
    public static List<string> NewList() => new List<string>();

    public static List<string> GetExistingLanguages() => new List<string>{"C#", "Clojure", "Elm"};

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        List<string> l = new List<string>();
        foreach (string li in languages) {
            l.Add(li);
        } 
        l.Add(language);
        return l;
    }

    public static int CountLanguages(List<string> languages)
    {
        int c = 0;
        foreach (string l in languages) {
            //hehe... you get it?
            c++;
        } 
        return c;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        foreach (string l in languages) {
            if (l == language) {
                return true;
            } 
        } 
        return false;
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) {
        if (Languages.CountLanguages(languages) == 0) {
            return false;
        } 
        if (languages[0] == "C#") {
            return true;
        } 
        if (languages[1] == "C#" && Languages.CountLanguages(languages) <= 3) {
            return true;
        } 
        return false;
    } 

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        bool _ = languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        Dictionary<string, bool> unique = new Dictionary<string, bool>();
        foreach (string l in languages) {
            if (!unique.ContainsKey(l)) {
                unique.Add(l, true);
            } else {
                return false;
            } 
        } 
        return true;
    }
}
