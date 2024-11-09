using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace EnableDebugPlugin;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        var harmony = new Harmony("com.Zeffies.EnableDebugPlugin");
        harmony.PatchAll();

    }
}
[HarmonyPatch(typeof(AnNGUIOptionMenu), "CreateNewCurrentMenuItem")]
public class AnNGUIOptionMenu_CreateNewCurrentMenuItem
{
    [HarmonyPrefix]
    static void SetDebugMenuOn()
    {
        AnSingleton<AnGameMgr>.Instance.GetDbgCheatData().m_isUseDbgMenuInGame = true;
    }
}
