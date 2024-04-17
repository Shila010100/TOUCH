using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Vibrate : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
            UduinoManager.Instance.sendCommand("vibrate");

    }
}
