using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private float growthTime;

    [field: SerializeField]
    public int Value { get; private set; }

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
        Debug.Log("Plant is grown.");
        IsGrown = true;
    }
}
