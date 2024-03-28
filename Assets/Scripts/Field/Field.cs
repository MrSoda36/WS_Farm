using UnityEngine;

public class Field : MonoBehaviour
{
    [field: SerializeField]
    public GameObject PlantedPlant { get; private set; }

    public bool Collect()
    {
        if (PlantedPlant != null)
        {
            if (PlantedPlant.GetComponent<Plant>().IsGrown)
            {
                PlantedPlant.GetComponent<Plant>().SetField(null);
                PlantedPlant = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void PlantSeed(GameObject seed)
    {
        if (PlantedPlant == null)
        {
            PlantedPlant = seed.GetComponent<Seed>().Plant(this);
            PlantedPlant.transform.SetParent(transform);
            PlantedPlant.GetComponent<Plant>().SetField(this);
            StartCoroutine(PlantedPlant.GetComponent<Plant>().Grow());
        }
    }
}
