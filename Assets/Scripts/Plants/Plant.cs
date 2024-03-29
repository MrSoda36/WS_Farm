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
    private int _growthMaxStage;
    [SerializeField]
    private ParticleSystem _plantParticles;
    [SerializeField]
    private Sprite[] _growthSprites;

    /// <summary>
    /// Gets the money value of the plant.
    /// </summary>
    [field: SerializeField]
    public int Value { get; private set; }

    /// <summary>
    /// Gets or sets the field where the plant is planted.
    /// </summary>
    public Field Field { get; set; }

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
        int stage = 0;
        IsGrown = false;
        while (stage < _growthMaxStage)
        {
            yield return new WaitForSeconds(_growthTime);
            GetComponent<SpriteRenderer>().sprite = _growthSprites[stage];
            stage++;
        }

        _plantParticles.Play();
        IsGrown = true;
    }
}
