using UnityEngine;
using System;
using System.Collections.Generic;


namespace CarterGames.Assets.SaveManager
{
    [Serializable]
    public class SaveData
    {
        [SerializeField] public float gnomeHealth;
        [SerializeField] public float sunHealth;
        [SerializeField] public SaveVector3 gnomePosition;
        [SerializeField] public SaveVector3[] enemyPositions;
        [SerializeField] public float[] enemyHealths;
    }
}