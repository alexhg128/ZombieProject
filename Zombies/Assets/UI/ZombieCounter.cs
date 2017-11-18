using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieCounter : MonoBehaviour
{

    private Text txt;
    private int zombie;

    void Start()
    {
        txt = GameObject.Find("Zombies").GetComponent<Text>();
        zombie = 0;
    }

	public void UpdateCounter()
    {
        zombie++;
        txt.text = zombie.ToString() + " Zombies";
    }

    public int getCurrentZombies()
    {
        return zombie;
    }

}
