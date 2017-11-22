using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ShootableZombie : MonoBehaviour {

	//The zombie's current health point total
	public int currentHealth = 1;
    public Text txt;
    public GameObject go;

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0)
		{
			//if health has fallen below zero, deactivate it
			//gameObject.SetActive (false);
			zombieScript script2 = gameObject.GetComponent<zombieScript>();
			script2.OnTriggerEnter ();
			ZombieCounter script = GameObject.Find("Zombies").GetComponent<ZombieCounter>();
            script.UpdateCounter();


        }
	}
}
