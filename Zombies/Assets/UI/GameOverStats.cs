using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int zombies = PlayerPrefs.GetInt("Zombies");
        float time = PlayerPrefs.GetFloat("Time");

        if(zombies == null)
        {
            zombies = 0;
        }
        if(time == null)
        {
            time = 0;
        }

        time /= 60;
        Text text = gameObject.GetComponent<Text>();
        string t = "TU PUNTUAJE ES:\n" + zombies.ToString() +" Zombies en " + time.ToString("#.00") + " Minutos";
        text.text = t;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
