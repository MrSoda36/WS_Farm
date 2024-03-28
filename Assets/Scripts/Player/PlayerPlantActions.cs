using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantActions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private List<GameObject> _plants = new List<GameObject>();

    public event Action<int> OnPlantChanged;

    /// <summary>
    /// Try to collect the plant and add it to the player's inventory.
    /// </summary>
    /// <param name="plant">Plant collected.</param>
    public void CollectPlant(GameObject plant)
    {
        bool actionSuccess;
        if (_plants.Count < 4)
        {
            actionSuccess = plant.GetComponent<Plant>().Field.Collect();
            if (actionSuccess)
            {
                _plants.Add(plant);
                OnPlantChanged?.Invoke(_plants.Count);
                plant.gameObject.SetActive(false);
                plant.transform.SetParent(transform);
            }
            else
            {
                Debug.Log("Plant is not grown yet.");
            }
        }
        else
        {
            Debug.Log("You can't carry more than 4 plants.");
        }
    }

    public GameObject RemovePlant()
    {
        if (_plants.Count > 0)
        {
            GameObject plant = _plants[0];
            _plants.RemoveAt(0);
            OnPlantChanged?.Invoke(_plants.Count);
            return plant;
        }
        else
        {
            Debug.Log("You don't have any plants.");
            return null;
        }
    }
}
