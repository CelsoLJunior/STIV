using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	public Transform LoadingBar;
	public string levelToLoad;
	[SerializeField] private float currentAmount;
	// speed = 40 para testes
	// speed = 10 para crianças
	private float speed = 40;
	private bool shouldIncrease=false;

	void Update(){
		if (shouldIncrease == true) {
			IniciarTimer();	
		}
		if (currentAmount >= 99) {
			Application.LoadLevel(levelToLoad);
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
