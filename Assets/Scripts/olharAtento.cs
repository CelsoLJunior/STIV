using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olharAtento : MonoBehaviour {

	[SerializeField] private float currentAmount;
	// speed = 50 para testes
	private float speed = 50;
	private bool shouldIncrease=false;
	public bool sideOK=false;

	void Update(){
		if (shouldIncrease == true) {
			IniciarTimer();
		}
		if (currentAmount >= 99) {
			sideOK = true;
		}
	}

	public void isLooking(){
		shouldIncrease = true;
	}

	public void IniciarTimer(){
		if (currentAmount < 100){
			currentAmount += speed * Time.deltaTime;
		}
	}
	public void notLooking(){
		shouldIncrease = false;
		currentAmount = 0;
	}
}
