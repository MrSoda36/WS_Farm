using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handling the player's actions with seeds in the game.
/// </summary>
public class PlayerSeedActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private List<GameObject> _seeds = new List<GameObject>();

    /// <summary>
    /// Event when the number of seeds in the player's inventory changes.
    /// </summary>
    public event Action<int> OnSeedChanged;

    /// <summary>
    /// Plant a seed in the field.
    /// </summary>
    /// <param name="field">The field in which we plant the seed.</param>
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

    /// <summary>
    /// Add a seed to the player's inventory.
    /// </summary>
    /// <param name="seed">The added seed's GameObject</param>
    /// <returns>True if there is enough space, false if the inventory is full.</returns>
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
