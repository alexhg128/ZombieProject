using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public Button button;
	// Use this for initialization
	void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TaskOnClick();
        }
    }
	
	// Update is called once per frame
	void TaskOnClick () {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }
}
