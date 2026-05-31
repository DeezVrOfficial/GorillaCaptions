using BepInEx;
using UnityEngine;

namespace GorillaCaptions
{
    [BepInPlugin(PluginInfo.Guid, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        void Awake()
        {
            instance = this;
            Debug.Log("<GorillaCaptions> Created by Deez & Goldentrophy <3");
            Debug.Log("Rip GoldenTrophy (iiDk) Dec 2019 - Feb 23, 2026 <3");
        }

        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();

            GameObject ClassHolder = new GameObject("GorillaCaptions");
            ClassHolder.AddComponent<Managers.SynthesizerManager>();
            ClassHolder.AddComponent<Managers.BubbleManager>();
            DontDestroyOnLoad(ClassHolder);

            Debug.Log("<GorillaCaptions> Fully initialized!");
        }
    }
}