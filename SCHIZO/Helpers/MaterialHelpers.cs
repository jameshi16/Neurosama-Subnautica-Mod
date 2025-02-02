﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nautilus.Utility;
using Nautilus.Utility.MaterialModifiers;
using SCHIZO.Unity.Materials;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SCHIZO.Helpers;

public static partial class MaterialHelpers
{
    public static void ApplySNShadersIncludingRemaps(
        GameObject gameObject,
        float shininess = 4f,
        float specularIntensity = 1f,
        float glowStrength = 1f,
        params MaterialModifier[] modifiers)
    {
        MaterialRemapper[] remappers = gameObject.GetComponentsInChildren<MaterialRemapper>(true);
        if (remappers.Length == 0)
        {
            MaterialUtils.ApplySNShaders(gameObject, shininess, specularIntensity, glowStrength, modifiers);
            return;
        }

        Transform disabledParent = new GameObject
        {
            transform =
            {
                parent = gameObject.transform
            }
        }.transform;
        disabledParent.gameObject.SetActive(false);

        Dictionary<MaterialRemapOverride, MeshRenderer> renderers = new();

        foreach (MaterialRemapper remapper in remappers)
        {
            foreach (MaterialRemapOverride remapOverride in remapper.config!?.remappings ?? Array.Empty<MaterialRemapOverride>())
            {
                if (renderers.ContainsKey(remapOverride)) continue;

                GameObject holder = new()
                {
                    transform =
                    {
                        parent = disabledParent
                    }
                };
                MeshRenderer rend = holder.AddComponent<MeshRenderer>();
                rend.materials = remapOverride.materials;
                renderers[remapOverride] = rend;
            }
        }

        MaterialUtils.ApplySNShaders(gameObject, shininess, specularIntensity, glowStrength, modifiers);

        foreach (KeyValuePair<MaterialRemapOverride, MeshRenderer> pair in renderers)
        {
            pair.Key.materials = pair.Value.materials;
        }

        Object.Destroy(disabledParent.gameObject);
    }

    [Conditional("BELOWZERO")]
    public static partial void FixBZGhostMaterial(Constructable con);
}
