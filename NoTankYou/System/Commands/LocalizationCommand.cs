﻿using NoTankYou.Interfaces;

namespace NoTankYou.System.Commands;

internal class LocalizationCommand : IPluginCommand
{
    public string CommandArgument => "loc";

    public void Execute(string? additionalArguments)
    {
        switch (additionalArguments)
        {
            case "generate":
                Service.LocalizationManager.ExportLocalization();
                break;
        }
    }
}