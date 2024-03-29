using UnityEngine;

/// <summary>
/// Class representing the shop where the player sells his plants.
/// </summary>
public class PlantSeller : MonoBehaviour
{
    /// <summary>
    /// Sell a plant and give the money value of the plant.
    /// </summary>
    /// <param name="plant">The sold plant's GameObject.</param>
    /// <returns>The money value of the plant.</returns>
    public int SellPlant(GameObject plant)
    {
        if (plant != null)
        {
            int value = plant.GetComponent<Plant>().Value;
            Destroy(plant);
            return value;
        }

        return -1;
    }
}
