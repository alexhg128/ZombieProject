using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HPCounter : MonoBehaviour {

    private Text txt;
    private Text xt;
    private int life;
    private ZombieCounter script;
    private RawImage heart1;
    private RawImage heart2;
    private RawImage heart3;
    private RawImage heart4;
    private RawImage heart5;
    public Texture halfHeart;
	private float nextDamage;
	private AudioSource no;
	private AudioSource golpe;

    void Start()
    {
        txt = GameObject.Find("Life").GetComponent<Text>();
        xt = GameObject.Find("Zombies").GetComponent<Text>();
        script = xt.GetComponent<ZombieCounter>();
        life = 100;
		nextDamage = Time.time + 1.5f;
        initHearts();
		no = GameObject.Find ("Nooo").GetComponent<AudioSource>();
		golpe = GameObject.Find ("Golpe").GetComponent<AudioSource>();
    }

    public void Damage(int damage)
    {
		if (Time.time > nextDamage) {
			
			life -= damage;
			nextDamage = Time.time + 1.5f;
			golpe.Play ();
		}
        txt.text = "HP " + life.ToString();
        if(life <= 90)
        {
            heart5.texture = halfHeart;
        }
        if (life <= 80)
        {
            heart5.enabled = false;
        }
        if (life <= 70)
        {
            heart4.texture = halfHeart;
        }
        if (life <= 60)
        {
            heart4.enabled = false;
        }
        if (life <= 50)
        {
            heart3.texture = halfHeart;
        }
        if (life <= 40)
        {
            heart3.enabled = false;
        }
        if (life <= 30)
        {
            heart2.texture = halfHeart;
        }
        if (life <= 20)
        {
            heart2.enabled = false;
        }
        if (life <= 10)
        {
            heart1.texture = halfHeart;
        }
        if (life <= 0)
        {
            GameOver(script.getCurrentZombies(), Time.timeSinceLevelLoad);
			no.Play ();
        }
        
    }

    public void GameOver(int zom, float t)
    {
        PlayerPrefs.SetInt("Zombies", zom);
        PlayerPrefs.SetFloat("Time", t);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    private void initHearts()
    {
        heart1 = GameObject.Find("Heart1").GetComponent<RawImage>();
        heart2 = GameObject.Find("Heart2").GetComponent<RawImage>();
        heart3 = GameObject.Find("Heart3").GetComponent<RawImage>();
        heart4 = GameObject.Find("Heart4").GetComponent<RawImage>();
        heart5 = GameObject.Find("Heart5").GetComponent<RawImage>();
    }
}
