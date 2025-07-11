class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => this.birdsPerDay[birdsPerDay.Length-1];

    public void IncrementTodaysCount() =>
        this.birdsPerDay[birdsPerDay.Length-1] = Today()+1;

    public bool HasDayWithoutBirds()
    {
        foreach (int b in birdsPerDay) {
            if (b == 0) {
                return true;
            } 
        } 
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birds = 0;
        for (int i = 0; i < numberOfDays; i++) {
            birds += birdsPerDay[i];
        } 
        return birds;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (int b in birdsPerDay) {
            if (b >= 5) {
                busyDays++;
            } 
        } 
        return busyDays;
    }
}
