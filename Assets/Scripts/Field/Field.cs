using UnityEngine;

public class Field : MonoBehaviour
{
    public Plant PlantedPlant { get; private set; }

    public void Collect(PlayerPlantActions player)
    {
        bool actionSucces = false;
        if (PlantedPlant != null)
        {
            if (PlantedPlant.IsGrown)
            {
                actionSucces = player.CollectPlant(PlantedPlant);
            }
        }

        if (actionSucces)
        {
            PlantedPlant = null;
        }
    }

    public void PlantSeed(Seed seed)
    {
        if (PlantedPlant == null)
        {
            PlantedPlant = seed.Plant(this);
        }
    }
}
