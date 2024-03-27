using UnityEngine;

public class PlantSeller : MonoBehaviour
{
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
