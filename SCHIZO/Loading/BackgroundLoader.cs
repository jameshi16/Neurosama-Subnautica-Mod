﻿using SCHIZO.DataStructures;
using SCHIZO.Resources;
using SCHIZO.Unity.Loading;

namespace SCHIZO.Loading;

public static class BackgroundLoader
{
    static BackgroundLoader()
    {
        LoadingBackgrounds = new SavedRandomList<LoadingBackground>("LoadingBackgrounds");

        LoadingBackgroundCollection collection = ResourceManager.LoadAsset<LoadingBackgroundCollection>("LoadingBackgrounds");

        foreach (LoadingBackground background in collection.backgrounds)
        {
            LoadingBackgrounds[background.randomListId] = background;
        }
    }

    public static readonly SavedRandomList<LoadingBackground> LoadingBackgrounds;
}
