﻿using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace SCHIZO.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method), MeansImplicitUse]
public sealed class LoadMethodAttribute : Attribute
{
    public static void LoadAll()
    {
        Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttribute<LoadMethodAttribute>() != null)
            .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            .Where(m => m.GetCustomAttribute<LoadMethodAttribute>() != null)
            .ForEach(m => m.Invoke(null, null));
    }
}
