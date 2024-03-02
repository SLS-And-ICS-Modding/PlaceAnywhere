
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlaceAnywhere
{
    public class Class1:MelonMod
    {
        static int frames = 0;
        bool IsInGame => GameObject.FindObjectsOfType<PlayerRaycast>().Length > 0;
        bool patched = false;
        
        public override void OnUpdate()
        {
            
            if(IsInGame && !patched)
            {
                Harmony.PatchAll();
                patched = true;
            }
            frames++;
        }
        

    }
    [HarmonyPatch(typeof(PlayerRaycast))]
    [HarmonyPatch("Update")]
    class PlayerRaycast_Update_Patch
    {
        static void Prefix(PlayerRaycast __instance)
        {
            Traverse.Create(__instance).Field("itemGreen").SetValue(true);
            Traverse.Create(__instance).Field("itemDistance").SetValue(1.0f);
        }
        
    }
}
