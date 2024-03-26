using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEventManager : MonoBehaviour
{
	private ArduinoConnector arduinoConnector;

	void Start()
	{
		// Find the ArduinoConnector instance in the scene
		arduinoConnector = FindObjectOfType<ArduinoConnector>();
	}

	void Update()
	{
		// Example: Trigger a vibration when the spacebar is pressed
		if (Input.GetKeyDown(KeyCode.Space))
		{
			arduinoConnector.Vibrate("vibrate 100");
		}
	}
}


public class vibrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
