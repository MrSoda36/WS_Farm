using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    [SerializeField]
    private List<Seed> _seeds = new List<Seed>();

    public event Action<Seed> OnSeedChanged;

    public void PlantSeed(Field field)
    {
        if (_seeds.Count == 0)
        {
            Debug.Log("You don't have any seeds.");
            return;
        }

        field.PlantSeed(_seeds[0]);
        _seeds.RemoveAt(0);
    }

    public bool AddSeed(Seed seed)
    {
        if (_seeds.Count < 4)
        {
            _seeds.Add(seed);
            OnSeedChanged?.Invoke(seed);
            return true;
        }
        else
        {
            Debug.Log("You can't carry more than 4 seeds.");
            return false;
        }
    }
}
