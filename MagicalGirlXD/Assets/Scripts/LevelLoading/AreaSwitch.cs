﻿using UnityEngine;
using System.Collections;

public class AreaSwitch : MonoBehaviour {
	Player player;

	void Awake() {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col){
		/*
		Debug.Log("Trigger is on");
		if(other.gameObject.tag =="Player"){
			Debug.Log("I am here ");
			Application.LoadLevel(1);
		}
		*/
		if (col.gameObject.tag == "Player") {
			if(player.hasWaterKey) {
				if (Application.loadedLevel == 1)
					Application.LoadLevel(2);
				else if (Application.loadedLevel == 2)
					Application.LoadLevel(1);
			}
		}
	}
}
