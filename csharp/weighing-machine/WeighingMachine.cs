class WeighingMachine
{
    private double _weight;
    private double _tareAdjustment;

    public WeighingMachine(int precision) {
        Precision = precision;
        _tareAdjustment = 5;
    } 

    // TODO: define the 'Precision' property
    public int Precision { get; }

    // TODO: define the 'Weight' property
    public double Weight {
        get => _weight;
        set {
            if (value < 0) {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight can not be negative.");
            } 
            _weight = Math.Round(value, Precision);
        } 
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment {
        set => _tareAdjustment = value;
    } 

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight => (Weight - _tareAdjustment).ToString($"F{Precision}") + " kg";

}
