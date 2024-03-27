using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private List<GameObject> _plants = new List<GameObject>();

    public event Action<Plant> OnPlantChanged;

    /// <summary>
    /// Try to collect the plant and add it to the player's inventory.
    /// </summary>
    /// <param name="plant">Plant collected</param>
    /// <returns>True if the collect succeced. False if it failed.</returns>
    public bool CollectPlant(GameObject plant)
    {
        if (_plants.Count < 4)
        {
            _plants.Add(plant);
            OnPlantChanged?.Invoke(plant.GetComponent<Plant>());
            plant.gameObject.SetActive(false);
            plant.transform.SetParent(transform);
            return true;
        }
        else
        {
            Debug.Log("You can't carry more than 4 plants.");
            return false;
        }
    }

    public GameObject RemovePlant()
    {
        if (_plants.Count > 0)
        {
            GameObject plant = _plants[0];
            _plants.RemoveAt(0);
            OnPlantChanged?.Invoke(plant.GetComponent<Plant>());
            return plant;
        }
        else
        {
            Debug.Log("You don't have any plants.");
            return null;
        }
    }
}
