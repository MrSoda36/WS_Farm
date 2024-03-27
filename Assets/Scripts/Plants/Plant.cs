using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private int value;
    private float growthTime;

    public Plant(int value, float growthTime)
    {
        this.value = value;
        this.growthTime = growthTime;
    }

    public Field Field { get; private set; }

    public bool IsGrown { get; private set; }

    /// <summary>
    /// Grow the plant after a certain amount of time.
    /// </summary>
    /// <returns>Coroutine stuff(?).</returns>
    public IEnumerator Grow()
    {
        IsGrown = false;
        yield return new WaitForSeconds(growthTime);
        IsGrown = true;
    }
}
