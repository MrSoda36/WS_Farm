using UnityEngine;

public class Seed : MonoBehaviour
{
    private bool _isPlanted;
    private Plant _plant;

    public int Cost { get; private set; }

    /// <summary>
    /// Plant a seed in a field, and launch growth.
    /// </summary>
    /// <param name="field">Field in which the seed is planted.</param>
    /// <returns>The new plant.</returns>
    public Plant Plant(Field field)
    {
        if (_isPlanted)
        {
            return null;
        }

        _isPlanted = true;
        Plant newPlant = Instantiate(_plant, field.transform.position, Quaternion.identity);
        StartCoroutine(newPlant.Grow());
        return newPlant;
    }
}
