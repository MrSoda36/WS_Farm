using UnityEngine;

public class Field : MonoBehaviour
{
    [field: SerializeField]
    public GameObject PlantedPlant { get; private set; }

    public void Collect(PlayerPlantActions player)
    {
        bool actionSucces = false;
        if (PlantedPlant != null)
        {
            if (PlantedPlant.GetComponent<Plant>().IsGrown)
            {
                actionSucces = player.CollectPlant(PlantedPlant);
                Debug.Log("Collect succes ? : " + actionSucces);
            }
            else
            {
                Debug.Log("Plant is not grown yet.");
            }

            if (actionSucces)
            {
                Debug.Log("Removing plant from field.");
                PlantedPlant = null;
            }
        }
    }

    public void PlantSeed(GameObject seed)
    {
        if (PlantedPlant == null)
        {
            PlantedPlant = seed.GetComponent<Seed>().Plant(this);
            PlantedPlant.transform.SetParent(transform);
            StartCoroutine(PlantedPlant.GetComponent<Plant>().Grow());
        }
    }
}
