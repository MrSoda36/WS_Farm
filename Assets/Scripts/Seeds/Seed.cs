using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    private GameObject _plant;

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
