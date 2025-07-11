class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    private int _speed = 0;
    private int _batteryDrain = 0;
    private int _distance = 0;
    private int _battery = 100;

    public RemoteControlCar(int speed, int batteryDrained) {
        this._speed = speed;
        this._batteryDrain = batteryDrained;
    } 

    public bool BatteryDrained()
    {
        if (_battery < _batteryDrain) {
            return true;
        } 
        return false;
    }

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (_battery >= _batteryDrain) {
            this._distance += _speed;
            this._battery -= _batteryDrain;
        } 
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int _distance = 0;
    public RaceTrack(int distance) => this._distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        //Lets run this baby!!!!
        while (!car.BatteryDrained()) {
            car.Drive();
        } 
        return car.DistanceDriven() >= _distance;
    }
}
