using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private List<GameObject> _seeds = new List<GameObject>();

    public event Action<int> OnSeedChanged;

    public void PlantSeed(Field field)
    {
        if (_seeds.Count == 0)
        {
            Debug.Log("You don't have any seeds.");
            return;
        }

        field.PlantSeed(_seeds[0]);
        _seeds.RemoveAt(0);
        OnSeedChanged?.Invoke(_seeds.Count);
    }

    public bool AddSeed(GameObject seed)
    {
        if (_seeds.Count < 4)
        {
            _seeds.Add(seed);
            OnSeedChanged?.Invoke(_seeds.Count);
            return true;
        }
        else
        {
            Debug.Log("You can't carry more than 4 seeds.");
            return false;
        }
    }
}
