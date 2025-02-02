﻿using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable once CheckNamespace
namespace SCHIZO.Unity.Creatures
{
    [CreateAssetMenu(menuName = "SCHIZO/Creatures/Custom Creature Data")]
    public class CustomCreatureData : ScriptableObject
    {
        [Header("Creature Prefab")]
        public GameObject prefab;

        [Header("Databank Info")]
        public Sprite unlockSprite;
        public Texture2D databankTexture;
        public TextAsset databankText;

        [Header("Creature Sounds")]
        [FormerlySerializedAs("sounds")] public CreatureSoundData soundData;
    }
}
