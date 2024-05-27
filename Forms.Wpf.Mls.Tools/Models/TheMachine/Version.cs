﻿namespace Forms.Wpf.Mls.Tools.Models.TheMachine;

public class Version
{
    public Version() { }
    public Version(bool initialize = false)
    {
        if (initialize)
        {
            try
            {
                Description = Environment.OSVersion.VersionString;
                Platform = Environment.OSVersion.Platform.ToString();
                Pack = Environment.OSVersion.ServicePack;
                Build = Environment.OSVersion.Version.Build;
                Major = Environment.OSVersion.Version.Major;
                //MajorRevision = Environment.OSVersion.Version.MajorRevision;
                Minor = Environment.OSVersion.Version.Minor;
                //MinorRevision = Environment.OSVersion.Version.MinorRevision;
                Revision = Environment.OSVersion.Version.Revision;
            }
            catch (Exception) { }
        }
    }

    public string? Description { get; set; }
    public string? Platform { get; set; }
    public string? Pack { get; set; }
    public int? Build { get; set; }
    public int? Major { get; set; }
    //public int MajorRevision { get; private set; }
    public int? Minor { get; set; }
    //public int MinorRevision { get; private set; }
    public int? Revision { get; set; }
}