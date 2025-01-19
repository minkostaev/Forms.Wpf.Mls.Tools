namespace Forms.Wpf.Mls.Tools.Models.TheMachine;

using Forms.Wpf.Mls.Tools.Services;
using System.Text.Json;

public class TheMachine : Machine
{
    public TheMachine()
    {
        Client = new Client(true);
        Culture = new Culture(true);
        Processor = new Processor(true);
        Version = new Version(true);
        Networks = new Networks();
        Variables = new Variables();
        AddHash();
    }
    private void AddHash()
    {
        try
        {
            var clientJson = JsonSerializer.Serialize(Client);
            var cultureJson = JsonSerializer.Serialize(Culture);
            var processorJson = JsonSerializer.Serialize(Processor);
            var versionJson = JsonSerializer.Serialize(Version);
            Hash = More.HashString(clientJson + cultureJson + processorJson + versionJson);
        }
        catch (Exception ex) { Hash = ex.Message; }
    }
}