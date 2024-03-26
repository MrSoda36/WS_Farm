using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedActions : MonoBehaviour
{
    private PlayerMain _playerMain;
    private List<Seed> seeds;

    public event Action<Seed> OnSeedChanged;

    public void PlantSeed(Field field)
    {
        field.PlantSeed(seeds[0]);
        seeds.RemoveAt(0);
    }
}
