﻿using Dalamud.Configuration;
using Dalamud.Plugin;
using NoTankYou.DisplaySystem;
using System;
using System.Collections.Generic;

namespace NoTankYou
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        [Serializable]
        public class ModuleSettings
        {
            public bool Enabled = false;
            public bool Forced = false;
            public bool Reposition = false;
        }
        public enum MainMode
        {
            Party,
            Solo
        }
        public enum SubMode
        {
            OnlyInDuty,
            Everywhere
        }

        public int Version { get; set; } = 3;
        public int NumberOfWaitFrames = 30;

        public WarningBanner.ImageSize ImageSize = WarningBanner.ImageSize.Large;

        public MainMode ProcessingMainMode = MainMode.Party;
        public SubMode ProcessingSubMode = SubMode.OnlyInDuty;

        public bool DisableInAllianceRaid = true;
        public int TerritoryChangeDelayTime = 8000;
        public int DeathGracePeriod = 5000;

        public ModuleSettings TankStanceSettings = new ModuleSettings();
        public ModuleSettings DancePartnerSettings = new ModuleSettings();
        public ModuleSettings FaerieSettings = new ModuleSettings();
        public ModuleSettings KardionSettings = new ModuleSettings();
        public ModuleSettings SummonerSettings = new ModuleSettings();

        public List<int> TerritoryBlacklist = new();

        public bool ForceWindowUpdate = false;

        [NonSerialized] private DalamudPluginInterface? pluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;

            TerritoryBlacklist ??= new();
            TankStanceSettings ??= new ModuleSettings();
            DancePartnerSettings ??= new ModuleSettings();
            FaerieSettings ??= new ModuleSettings();
            KardionSettings ??= new ModuleSettings();
            SummonerSettings ??= new ModuleSettings();
            Save();
        }

        public void Save()
        {
            pluginInterface!.SavePluginConfig(this);
        }
    }
}