public class PersonalComputer : Device
{
    public string? OperatingSystem { get; }

    public PersonalComputer(string id, string name, bool isEnabled, string? operatingSystem) 
        : base(id, name, isEnabled)
    {
        if (!id.StartsWith("P-"))
            throw new ArgumentException("PC ID must start with 'P-'");
            
        OperatingSystem = operatingSystem;
    }

    public override void TurnOn()
    {
        if (OperatingSystem == null)
            throw new EmptySystemException();
            
        base.TurnOn();
    }

    public override string ToString() => 
        $"PC {Name} ({Id}) is {(IsEnabled ? "enabled" : "disabled")} " +
        $"with OS: {OperatingSystem ?? "None installed"}";
}