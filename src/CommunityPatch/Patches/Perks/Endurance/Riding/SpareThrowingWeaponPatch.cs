﻿using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace CommunityPatch.Patches.Perks.Endurance.Riding {
  public class SpareThrowingWeapon : ExtraAmmoPerksPatch<SpareThrowingWeapon> {

    private static readonly MethodInfo PatchMethodInfo = typeof(SpareThrowingWeapon).GetMethod("Postfix", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);
    
    public override void Apply(Game game) {
      if (Applied) return;

      CommunityPatchSubModule.Harmony.Patch(TargetMethodInfo,
        postfix: new HarmonyMethod(PatchMethodInfo));
      Applied = true;
    }

    static bool CanApplyPerk(Hero hero, WeaponComponentData weaponComponentData) => 
      WeaponComponentData.GetItemTypeFromWeaponClass(weaponComponentData.WeaponClass) == ItemObject.ItemTypeEnum.Thrown &&
      hero.GetPerkValue(DefaultPerks.Riding.SpareThrowingWeapon);
      
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Postfix(Agent __instance) {
      if (HasMount(__instance)) {
        ApplyPerk(__instance, 1, CanApplyPerk);      
      }
    }
  }
}