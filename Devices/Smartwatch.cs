namespace APBD
public class Smartwatch : Device, IPowerNotify
{
    private int _batteryLevel;

    public int BatteryLevel
    {
        get => _batteryLevel;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Battery level must be 0-100");
            
            _batteryLevel = value;
            if (_batteryLevel < 20) Notify();
        }
    }

    public Smartwatch(string id, string name, bool isEnabled, int batteryLevel) 
        : base(id, name, isEnabled)
    {
        if (!id.StartsWith("SW-"))
            throw new ArgumentException("Smartwatch ID must start with 'SW-'");
            
        BatteryLevel = batteryLevel;
    }

    public override void TurnOn()
    {
        if (BatteryLevel < 11)
            throw new EmptyBatteryException();
            
        base.TurnOn();
        BatteryLevel -= 10;
    }

    public void Notify()
    {
        Console.WriteLine($"Low battery warning: {BatteryLevel}% remaining");
    }

    public override string ToString() => 
        $"Smartwatch {Name} ({Id}) is {(IsEnabled ? "enabled" : "disabled")} with {BatteryLevel}% battery";
}