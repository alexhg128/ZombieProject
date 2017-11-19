using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpeed : MonoBehaviour {
	public float speed; 
	public Animation anim ; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim["walk"].speed = speed;
	}
}
