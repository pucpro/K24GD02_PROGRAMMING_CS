using System;

class TemperatureChangedEventArgs : EventArgs
{
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double t) => NewTemperature = t;
}

class Thermometer
{
    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    public void SetTemperature(double t)
    {
        TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(t));
    }
}

class Program
{
    static void Main()
    {
        Thermometer thermo = new Thermometer();
        thermo.TemperatureChanged += (s, e) => Console.WriteLine($"Nhiet do moi: {e.NewTemperature}°C");

        thermo.SetTemperature(30.5);
        thermo.SetTemperature(25.0);
    }
}