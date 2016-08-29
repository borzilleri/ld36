using UnityEngine;
using System.Collections;

public class ObjectWarp : MonoBehaviour {

    public GameObject warpee;
    public GameObject warpTarget;
    public float rotationSpeed = 0.5f;

	private AudioSource audio;

    bool hasTriggered = false;
    float totalRotation = 0;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

    void Update()
    {
        if (hasTriggered)
        {
            if (totalRotation <= 90)
            {
                warpee.transform.Rotate(0, rotationSpeed, 0);
                totalRotation += rotationSpeed;
            }
        }
    }

    public void OnTriggerEnter2D (Collider2D user)
    {
		Debug.Log ("TRIGGERING!!");
        if (hasTriggered == true)
        {
            return;
        }

        hasTriggered = true;
        warpee.transform.Rotate(0, -90, 0);
        warpee.transform.position = warpTarget.transform.position;

		if (null != audio) {
			audio.Play ();
		}
    }
}
