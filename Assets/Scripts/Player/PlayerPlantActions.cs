using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private List<Plant> _plants = new List<Plant>();

    public event Action<Plant> OnPlantChanged;

    /// <summary>
    /// Try to collect the plant and add it to the player's inventory.
    /// </summary>
    /// <param name="plant">Plant collected</param>
    /// <returns>True if the collect succeced. False if it failed.</returns>
    public bool CollectPlant(Plant plant)
    {
        if (_plants.Count < 4)
        {
            _plants.Add(plant);
            OnPlantChanged?.Invoke(plant);
            plant.gameObject.SetActive(false);
            return true;
        }
        else
        {
            Debug.Log("You can't carry more than 4 plants.");
            return false;
        }
    }
}
