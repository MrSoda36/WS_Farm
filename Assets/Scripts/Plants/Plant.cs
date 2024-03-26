using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private int value;
    private float growthTime;

    /// <summary>
    /// Grow the plant after a certain amount of time.
    /// </summary>
    /// <returns>Coroutine stuff(?).</returns>
    public IEnumerator Grow()
    {
        yield return new WaitForSeconds(growthTime);
    }
}
