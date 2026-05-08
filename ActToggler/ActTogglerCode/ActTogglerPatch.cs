using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Random;

namespace ActToggler.ActTogglerCode;

[HarmonyPatch(typeof(ActModel), nameof(ActModel.GetRandomList))]
[HarmonyPriority(Priority.Last)]
public class ActTogglerPatch
{
    public static void Finalizer(ref IEnumerable<ActModel> __result, Rng rng)
    {
        var list = __result.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = ActTogglerConfig.GetWeightedAct(i + 1, rng);
        }
        __result = list;
    }
}