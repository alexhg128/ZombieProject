using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float time;

	void Update () {
        time = Time.timeSinceLevelLoad;
        //Debug.Log(time.ToString() + "\n");
        time /= 60;
        float seconds = (time - (int) time) * 60 ;
        GameObject.Find("Time").GetComponent<Text>().text = ((int) time).ToString("00") + ":" + seconds.ToString("00.00");
        
    }
}
