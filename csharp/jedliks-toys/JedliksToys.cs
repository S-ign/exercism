class RemoteControlCar
{

    private int _distance = 0;
    private int _battery = 100;

    //oooo the exercism AI suggested I transform the method like this(expresion bodied mothod)
    //this is fancy!~
    public static RemoteControlCar Buy() => new RemoteControlCar();
    public string DistanceDisplay() => $"Driven {_distance} meters";

    //Cool discovery, before I fitured it out I was trying to do calculations in BatteryDisplay
    //but then I thought.... the only thing this method is supposed to do is display information.
    //
    //When I reminded myself of that I realized I should just be modifying the variables in Drive.
    //Instead of trying to do _battery-(_distance/20) type of calculations here, which was throwing
    //an error once it got to 2000 distance.
    //
    //Nice lesson :)
    //Thanks!
    public string BatteryDisplay() {
        if (_battery <= 0) {
            return "Battery empty";
        }
        return $"Battery at {_battery}%";
    }

    public void Drive() {
        if (_battery > 0) {
            _distance += 20;
            _battery--;
        } 
    }
}
