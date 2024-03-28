using System.Collections;
using UnityEngine;

/// <summary>
/// Class representing a plant in the game.
/// A plant can be grown in a field and collected when fully grown.
/// </summary>
public class Plant : MonoBehaviour
{
    [SerializeField]
    private float _growthTime;
    [SerializeField]
    private ParticleSystem _plantParticles;

    /// <summary>
    /// Gets the money value of the plant.
    /// </summary>
    [field: SerializeField]
    public int Value { get; private set; }

    /// <summary>
    /// Gets the field where the plant is planted.
    /// </summary>
    public Field Field { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the plant is fully grown.
    /// </summary>
    public bool IsGrown { get; private set; }

    /// <summary>
    /// Grow the plant after a certain amount of time.
    /// </summary>
    /// <returns>Wait for the growthTime.</returns>
    public IEnumerator Grow()
    {
        IsGrown = false;
        yield return new WaitForSeconds(_growthTime);
        Debug.Log("Plant is grown.");
        _plantParticles.Play();
        IsGrown = true;
    }

    /// <summary>
    /// Sets the field where the plant is planted.
    /// </summary>
    /// <param name="field">The field in which the plant is planted.</param>
    public void SetField(Field field)
    {
        Field = field;
    }
}
