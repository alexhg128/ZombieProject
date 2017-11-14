using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {

    public Camera cam;
    private float fieldOfView = 60f;
    bool sig = false;
    public float changeRate = 0.20f;
    private float nextChange;
    public UnityEngine.UI.RawImage img;
    // Use this for initialization
    void Start () {
        cam.fieldOfView = 60f;
        img.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Sight") && Time.time > nextChange)
        {
            startSight();
            nextChange = Time.time + changeRate;
        }
	}

    void startSight()
    {
        if(sig)
        {
            fieldOfView = 20f;
            img.enabled = true;
        }
        else
        {
            fieldOfView = 60f;
            img.enabled = false;
        }
        sig = !sig;
        cam.fieldOfView = fieldOfView;
    }
}
