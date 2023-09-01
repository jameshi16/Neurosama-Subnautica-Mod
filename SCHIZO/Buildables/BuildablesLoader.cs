﻿using Nautilus.Crafting;
using SCHIZO.Creatures.Ermfish;
using SCHIZO.Utilities;
using UnityEngine;

namespace SCHIZO.Buildables;

public static class BuildablesLoader
{
	public static Transform DisabledParent { get; private set; }

	public static LocalSoundCollection ErmWorldSounds { get; private set; }

	public static void Load()
	{
		DisabledParent = new GameObject("SCHIZO DISABLED PARENT").transform;
		DisabledParent.gameObject.SetActive(false);
		GameObject.DontDestroyOnLoad(DisabledParent);

		ErmWorldSounds = new LocalSoundCollection("noises", "bus:/master/SFX_for_pause/PDA_pause/all/indoorsounds");

		LoadOldVersions();

		new BuildablePrefab("VedalTurtle2", "Tutel", "<size=75%>(Model by FutabaKuuhaku)</size>")
		{
			IconFileName = "tutel.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CreepvinePiece, 10)),
			PrefabName = "turtle",
			TechGroup = TechGroup.Miscellaneous,
			TechCategory = TechCategory.Misc,
		}.WithOldVersion("VedalTurtle").Register();

		new BuildablePrefab("NeuroErm2", "Erm", "<size=75%>(Model by w1n7er)</size>")
		{
			IconFileName = "erm.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CopperWire, 2), new CraftData.Ingredient(TechType.Silicone, 2), new CraftData.Ingredient(TechType.Battery), new CraftData.Ingredient(TechType.Titanium, 4), new CraftData.Ingredient(ErmfishTypes.Regular.TechType)),
			PrefabName = "neuroerm",
			TechGroup = TechGroup.Miscellaneous,
			TechCategory = TechCategory.Misc,
			ModifyPrefab = prefab =>
			{
				prefab.AddComponent<ErmNoises>();
			}
		}.Register();

		new BuildablePrefab("Neuroopper2", "Neurooper", "<size=75%>(Model by greencap, original art by Sandro)</size>")
		{
			IconFileName = "neurooper.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CopperWire), new CraftData.Ingredient(TechType.Silicone, 2), new CraftData.Ingredient(TechType.Peeper, 3), new CraftData.Ingredient(TechType.Bladderfish, 3)),
			PrefabName = "neurooper",
			TechGroup = TechGroup.Miscellaneous,
			TechCategory = TechCategory.Misc,
		}.WithOldVersion("Neurooper").Register();

		new BuildablePrefab("NeuroFumo2", "Low-poly Neuro fumo", "Fumo collection 1/2\n<size=75%>(Model by YuG)</size>")
		{
			IconFileName = "neurofumo.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CopperWire), new CraftData.Ingredient(TechType.Silicone, 2), new CraftData.Ingredient(TechType.JeweledDiskPiece, 2), new CraftData.Ingredient(TechType.Gold)),
			PrefabName = "neurofumo",
			TechGroup = TechGroup.Miscellaneous,
			TechCategory = TechCategory.Misc,
		}.WithOldVersion("NeuroFumo").Register();

		new BuildablePrefab("NeuroFumoNew", "Neuro fumo", "Fumo collection 2/2\n<size=75%>(Model by Kat)</size>")
		{
			IconFileName = "neurofumonew.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CopperWire), new CraftData.Ingredient(TechType.Silicone, 2), new CraftData.Ingredient(TechType.JeweledDiskPiece, 2), new CraftData.Ingredient(TechType.Gold)),
			PrefabName = "neurofumo2",
			TechGroup = TechGroup.Miscellaneous,
			TechCategory = TechCategory.Misc,
		}.Register();
	}

	private static void LoadOldVersions()
	{
		new BuildablePrefab("NeuroErm", "Erm (OLD VERSION, PLEASE REBUILD)", "<size=75%>(Model by w1n7er)</size>")
		{
			IconFileName = "erm.png",
			Recipe = new RecipeData(new CraftData.Ingredient(TechType.CopperWire, 2), new CraftData.Ingredient(TechType.Silicone, 2), new CraftData.Ingredient(TechType.Battery), new CraftData.Ingredient(TechType.Titanium, 4)),
			PrefabName = "neuroerm",
			ModifyPrefab = prefab =>
			{
				prefab.transform.Find("WM").localScale = new Vector3(1, -1, 1);
				prefab.transform.Find("WM/erm/regular").gameObject.SetActive(false);
				prefab.transform.Find("WM/erm/cured").gameObject.SetActive(true);
				prefab.GetComponentsInChildren<MeshRenderer>().ForEach(r => r.material.color = new Color(0.75f, 0, 0.75f));
			}
		}.Register();
	}
}