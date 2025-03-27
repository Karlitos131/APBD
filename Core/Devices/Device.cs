namespace APBD{
    public abstract class Device
    {
        public string Id { get; }
        public string Name { get; }
        public bool IsEnabled { get; set; }

        protected Device(string id, string name, bool isEnabled)
        {
        Id = id;
        Name = name;
        IsEnabled = isEnabled;
        }

        public virtual void TurnOn()
    {
        IsEnabled = true;
    }

    public virtual void TurnOff()
    {
        IsEnabled = false;
    }

    public abstract override string ToString();
    }
}