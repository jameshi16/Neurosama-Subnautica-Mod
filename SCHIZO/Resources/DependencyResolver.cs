﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SCHIZO.Resources;

public static class DependencyResolver
{
    public static void InjectResources()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (_, args) =>
        {
            string name = args.Name[..args.Name.IndexOf(',')] + ".dll";

            IEnumerable<string> resources = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(s => s.EndsWith(name));
            string resourceName = resources.FirstOrDefault();
            if (resourceName == null) return null;

            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (stream == null) return null;

            using MemoryStream ms = new();
            stream.CopyTo(ms);
            return Assembly.Load(ms.ToArray());
        };
    }
}
