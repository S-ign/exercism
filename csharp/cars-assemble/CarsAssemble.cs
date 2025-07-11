// - `0`: 0% success rate.
// - `1` to `4`: 100% success rate.
// - `5` to `8`: 90% success rate.
// - `9`: 80% success rate.
// - `10`: 77% success rate.

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 10) {
            return .77;
        } else if (speed == 9) {
            return .8;
        } else if (speed >=5) {
            return .9;
        } else if (speed >=1) {
            return 1.0;
        } 

        return 0;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return SuccessRate(speed)*(221*speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return ((int)ProductionRatePerHour(speed))/60;
    }
}
