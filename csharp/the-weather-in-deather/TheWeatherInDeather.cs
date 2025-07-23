public class WeatherStation
{
    private Reading reading;
    private List<DateTime> recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public decimal LatestTemperature => reading.Temperature;
    public decimal LatestPressure => reading.Pressure;
    public decimal LatestRainfall => reading.Rainfall;

    public void AcceptReading(Reading reading)
    {
        this.reading = reading;
        recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        reading = new Reading();
        recordDates.Clear();
        temperatures.Clear();
    }

    public bool HasHistory =>
        recordDates.Count > 1
            ? true
            : false;

    public Outlook ShortTermOutlook =>
        reading.Equals(new Reading()) == true
            ? throw new ArgumentException()
            : reading.Temperature switch {
                30 or < 30 => Outlook.Cool,
                50 or > 50 => Outlook.Good,
                _ => Outlook.Warm
            };

    public Outlook LongTermOutlook =>
        reading.WindDirection switch {
            WindDirection.Northerly => Outlook.Cool,
            WindDirection.Southerly => Outlook.Good,
            WindDirection.Westerly => Outlook.Rainy,
            WindDirection.Easterly when reading.Temperature > 20 => Outlook.Good,
            WindDirection.Easterly when reading.Temperature <= 20 => Outlook.Warm,
            _ => throw new ArgumentException(),
        };

    public State RunSelfTest() =>
        reading.Equals(new Reading()) == true
            ? State.Bad
            : State.Good;
}

/*** Please do not modify this struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}
