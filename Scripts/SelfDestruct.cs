using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    public GameObject explosion;

    private float shake = 0.2f;
    private AudioSource audioSource;

	// Use this for initialization
	void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnEnable ()
    {
        EventManager.StartListening ("Destroy", Destroy);
	}

    void OnDisable()
    {
        EventManager.StopListening("Destroy", Destroy);
    }

    void Destroy()
    {
        EventManager.StopListening("Destroy", Destroy);
        EventManager.StopListening("Junk", Destroy);
        StartCoroutine(DestroyNow());
    }

    IEnumerator DestroyNow()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        audioSource.pitch = Random.Range(0.75f, 1.75f);
        audioSource.Play();
        float startTime = 0;
        float shakeTime = Random.Range(1f, 3f);
        while (startTime < shakeTime)
        {
            transform.Translate (Random.Range(-shake, shake), 0f, Random.Range(-shake, shake));
            transform.Rotate (0f, Random.Range(-shake * 100, shake * 100), 0f);
            startTime -= Time.deltaTime;
            yield return null;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        yield return null;
    }
}
