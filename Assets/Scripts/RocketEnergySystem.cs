using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    private Rocket rocket;

    private void Start()
    {
        rocket= GetComponent<Rocket>();
    }
    public void FuelRecover()
    {
        if (rocket.fuel < 100f)
        {
            rocket.fuel += 0.1f;            
        }
    }
}
