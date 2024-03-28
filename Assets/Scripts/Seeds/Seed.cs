using UnityEngine;

/// <summary>
/// Class representing a seed in the game.
/// A seed can be planted in a field, creating a plant.
/// </summary>
public class Seed : MonoBehaviour
{
    [SerializeField]
    private GameObject _plant;

    /// <summary>
    /// Gets the cost of the seed.
    /// </summary>
    [field: SerializeField]
    public int Cost { get; private set; }

    /// <summary>
    /// Plant a seed in a field, and launch growth.
    /// </summary>
    /// <param name="field">Field in which the seed is planted.</param>
    /// <returns>The new plant.</returns>
    public GameObject Plant(Field field)
    {
        Debug.Log("Seed planted.");
        GameObject newPlant = Instantiate(_plant, field.transform.position, Quaternion.identity);
        return newPlant;
    }
}
