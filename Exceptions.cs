public class EmptySystemException : Exception
{
    public EmptySystemException() : base("Operating system is not installed") { }
}

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException() : base("Battery level is too low to turn on") { }
}

public class ConnectionException : Exception
{
    public ConnectionException() : base("Cannot connect to the network") { }
}