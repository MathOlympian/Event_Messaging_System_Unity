using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("q"))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
