using UnityEngine;

/// <summary>
/// Class representing a field in the game.
/// A field can be planted with a seed, creating a plant which can be collected when grown.
/// </summary>
public class Field : MonoBehaviour
{
    /// <summary>
    /// Gets the plant currently planted in the field.
    /// </summary>
    [field: SerializeField]
    public GameObject PlantedPlant { get; private set; }

    /// <summary>
    /// Collect the plant from the field.
    /// </summary>
    /// <returns>True if the collect succeded, False if it failed.</returns>
    public bool Collect()
    {
        if (PlantedPlant != null)
        {
            if (PlantedPlant.GetComponent<Plant>().IsGrown)
            {
                PlantedPlant.GetComponent<Plant>().Field = null;
                PlantedPlant = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Plant a seed in the field.
    /// </summary>
    /// <param name="seed">GameObject with Seed Component.</param>
    public void PlantSeed(GameObject seed)
    {
        if (PlantedPlant == null)
        {
            PlantedPlant = seed.GetComponent<Seed>().Plant(this);
            PlantedPlant.transform.SetParent(transform);
            PlantedPlant.GetComponent<Plant>().Field = this;
            StartCoroutine(PlantedPlant.GetComponent<Plant>().Grow());
        }
    }
}
