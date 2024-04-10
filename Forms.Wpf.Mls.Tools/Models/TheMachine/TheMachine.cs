namespace Forms.Wpf.Mls.Tools.Models.TheMachine;

using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class TheMachine : Machine
{
    public TheMachine()
    {
        Client = new Client(true);
        Culture = new Culture(true);
        Processor = new Processor(true);
        Version = new Version(true);
        Variables = [];
        Networks = [];
        try { AddNetworkMachines(); AddUserVariables(); AddHash(); }
        catch (Exception) { }
    }
    private void AddNetworkMachines()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                var networkMachine = new Network
                {
                    Id = nic.Id.Replace("{", "").Replace("}", ""),
                    Name = nic.Name,
                    Description = nic.Description,
                    Type = nic.NetworkInterfaceType.ToString()
                };

                var ip = nic.GetIPProperties().UnicastAddresses
                    .FirstOrDefault(x => x.Address.AddressFamily == AddressFamily.InterNetwork);
                if (ip != null)
                {
                    networkMachine.Ip = ip.Address.ToString();
                }

                var address = nic.GetPhysicalAddress();
                var mac = BitConverter.ToString(address.GetAddressBytes());
                networkMachine.Mac = mac;//address.ToString();
                Networks?.Add(networkMachine);
            }
        }
    }
    public void AddUserVariables()
    {
        int errors = 0;
        foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
        {
            if (variable.Key != null && variable.Value != null)
            {
                try { Variables?.Add(variable.Key.ToString()!, variable.Value.ToString()); }
                catch (Exception)
                {
                    errors++;
                    if (Variables!.ContainsKey("ERRORS"))
                    {
                        Variables["ERRORS"] = errors.ToString();
                    }
                    else
                    {
                        Variables.Add("ERRORS", errors.ToString());
                    }
                }
            }
        }
    }
    public void AddHash()
    {
        var clientJson = JsonSerializer.Serialize(Client);
        var cultureJson = JsonSerializer.Serialize(Culture);
        var processorJson = JsonSerializer.Serialize(Processor);
        var versionJson = JsonSerializer.Serialize(Version);
        Hash = HashString(clientJson + cultureJson + processorJson + versionJson);
    }

    public static string HashString(string text, string salt = "")
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        byte[] textBytes = Encoding.UTF8.GetBytes(text + salt);
        byte[] hashBytes = SHA256.HashData(textBytes);
        string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        return hash;
    }

    public string? Hash { get; set; }
}