public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new Dictionary<int, string>();

    public static Dictionary<int, string> GetExistingDictionary() =>
        new Dictionary<int, string> {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) =>
         new Dictionary<int, string> {
            {countryCode, countryName}
        };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) {
        if (CheckCodeExists(existingDictionary, countryCode)) {
            return existingDictionary[countryCode];
        } 
        return "";
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (CheckCodeExists(existingDictionary, countryCode)) {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        int longest = 0;
        string lcn = "";
        foreach (string cn in existingDictionary.Values) {
            if (cn.Length > longest) {
                longest = cn.Length;
                lcn = cn;
            } 
        } 
        return lcn;
    }
}
