public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void SetSponsors(params string[] sponsors) => this.sponsors = sponsors;
    public string DisplaySponsor(int sponsorNum) => this.sponsors[sponsorNum];
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;

        if (serialNum < latestSerialNum) {
            serialNum = latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }

        if (serialNum > latestSerialNum)
            latestSerialNum = serialNum;

        return true;
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;
    public TelemetryClient(RemoteControlCar car) => this.car = car;

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage = 100;
        int distanceDrivenInMeters = 0;

        return (car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters) &&
                distanceDrivenInMeters != 0)
            ? $"usage-per-meter={(100-batteryPercentage)/distanceDrivenInMeters}"
            : "no data";
    }
}
