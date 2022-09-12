﻿using System;
using System.IO;
using Dalamud.Logging;

namespace NoTankYou.System;

public class LocalizationManager : IDisposable
{
    private readonly Dalamud.Localization Localization;

    public LocalizationManager()
    {
        var assemblyLocation = Service.PluginInterface.AssemblyLocation.DirectoryName!;
        var filePath = Path.Combine(assemblyLocation, @"translations");

        Localization = new Dalamud.Localization(filePath, "NoTankYou_");
        Localization.SetupWithLangCode(Service.PluginInterface.UiLanguage);

        Service.PluginInterface.LanguageChanged += OnLanguageChange;
    }

    public void ExportLocalization()
    {
        try
        {
            Localization.ExportLocalizable();
        }
        catch (Exception ex)
        {
            PluginLog.Error(ex, "Error exporting localization files");
        }
    }

    public void Dispose()
    {
        Service.PluginInterface.LanguageChanged -= OnLanguageChange;
    }

    private void OnLanguageChange(string languageCode)
    {
        try
        {
            PluginLog.Information($"Loading Localization for {languageCode}");
            Localization.SetupWithLangCode(languageCode);
        }
        catch (Exception ex)
        {
            PluginLog.Error(ex, "Unable to Load Localization");
        }
    }
}