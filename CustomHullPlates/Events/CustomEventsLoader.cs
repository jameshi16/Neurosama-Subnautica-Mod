﻿using HarmonyLib;
using UnityEngine;

namespace SCHIZO.Events
{
    [HarmonyPatch]
    public static class CustomEventsLoader
    {
        private static CustomEventManager eventManager;
        private static void LoadEvents(GameObject host)
        {
            eventManager = host.AddComponent<CustomEventManager>();

            eventManager.AddEvent<ErmMoonEvent>();
        }

        [HarmonyPatch(typeof(Player), nameof(Player.Awake))]
        [HarmonyPostfix]
        public static void EventLoadHook(Player __instance)
        {
            LoadEvents(Player.mainObject);
        }
    }
}
