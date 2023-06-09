using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    public GameObject Car;
    public void HandleCar()
    {
        Car.GetComponent<Animator>().Play("Car crashing", 0, 0);
    }
}
