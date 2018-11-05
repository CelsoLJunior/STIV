﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	public Transform LoadingBar;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;
	private bool shouldIncrease=false;

	void Update(){
		if (shouldIncrease == true) {
			IniciarTimer();	
		}		
	}

	public void AtivarBool(){
		shouldIncrease = true;
	}

	public void IniciarTimer(){
		if (currentAmount < 100){
			currentAmount += speed * Time.deltaTime;
		}
		LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
	public void ZerarTimer(){
		shouldIncrease = false;
		LoadingBar.GetComponent<Image>().fillAmount = 0;
		currentAmount = 0;
	}
}
