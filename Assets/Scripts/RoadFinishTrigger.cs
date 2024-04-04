using UnityEngine;

public class RoadFinishTrigger : MonoBehaviour
{
    public Vector3 FinalPosition;
    public void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Car"))
            car.GetComponent<CarController>().FinalPosition = FinalPosition;
    }
}
