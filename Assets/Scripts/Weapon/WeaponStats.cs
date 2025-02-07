namespace RehvidGames.Weapon
{
    using System;
    using UnityEngine;

    [Serializable]
    public class WeaponStats
    {
        [Header("Stats")]
        [field: SerializeField] public float Damage { get; private set; } = 10f;
    }
}