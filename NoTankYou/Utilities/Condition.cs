﻿using Dalamud.Game.ClientState.Conditions;

namespace NoTankYou.Utilities
{
    internal static class Condition
    {
        public static bool IsBoundByDuty()
        {
            var baseBoundByDuty = Service.Condition[ConditionFlag.BoundByDuty];
            var boundBy56 = Service.Condition[ConditionFlag.BoundByDuty56];
            var boundBy95 = Service.Condition[ConditionFlag.BoundByDuty95];

            // Triggers when Queue is started
            //var boundBy97 = Service.Condition[ConditionFlag.BoundToDuty97];

            return baseBoundByDuty || boundBy56 || boundBy95;
        }
    }
}