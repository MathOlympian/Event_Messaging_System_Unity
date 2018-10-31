using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour
{
    private UnityAction someListener;

	// Use this for initialization
	void Awake ()
    {
        someListener = new UnityAction(SomeFunction);
	}

    private void OnEnable()
    {
        EventManager.StartListening("test", someListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("test", someListener);
    }

    void SomeFunction()
    {
        Debug.Log("SomeFunction called");
    }
}
