using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour

//Detect a collision and make a vibrate effect when ball runs into objects
{
    private void OnCollisionEnter(Collision collision)
    {
        Handheld.Vibrate();
    }
}

