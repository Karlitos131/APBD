namespace APBD
public class Embedded : Device
{
    public string IpAddress { get; }
    public string NetworkName { get; }
    private bool _isConnected;

    public Embedded(string id, string name, bool isEnabled, string ipAddress, string networkName)
        : base(id, name, isEnabled)
    {
        if (!id.StartsWith("ED-"))
            throw new ArgumentException("Embedded device ID must start with 'ED-'");
            
        if (!System.Net.IPAddress.TryParse(ipAddress, out _))
            throw new ArgumentException("Invalid IP address format");
            
        IpAddress = ipAddress;
        NetworkName = networkName;
    }

    public override void TurnOn()
    {
        Connect();
        base.TurnOn();
    }

    public override void TurnOff()
    {
        _isConnected = false;
        base.TurnOff();
    }

    private void Connect()
    {
        _isConnected = NetworkName.Contains("MD Ltd.");
        if (!_isConnected)
            throw new ConnectionException();
    }

    public override string ToString() => 
        $"Embedded {Name} ({Id}) is {(IsEnabled ? "enabled" : "disabled")} " +
        $"on network {NetworkName} ({IpAddress})";
}