// Type: TroutZoom.Properties.Settings
// Assembly: TroutZoom, Version=1.1.0.0, Culture=neutral, PublicKeyToken=a84158465d51f68d
// MVID: 0632150E-6A81-4FF2-9663-7F701F6E69DE
// Assembly location: C:\Users\strost\Downloads\TroutZoom\TroutZoom.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TroutZoom.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("100")]
    [UserScopedSetting]
    public double LastZoomLevel
    {
      get
      {
        return (double) this["LastZoomLevel"];
      }
      set
      {
        this["LastZoomLevel"] = (object) value;
      }
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    [DefaultSettingValue("20")]
    public double MinZoomLevel
    {
      get
      {
        return (double) this["MinZoomLevel"];
      }
      set
      {
        this["MinZoomLevel"] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("400")]
    public double MaxZoomLevel
    {
      get
      {
        return (double) this["MaxZoomLevel"];
      }
      set
      {
        this["MaxZoomLevel"] = (object) value;
      }
    }

    static Settings()
    {
    }
  }
}
