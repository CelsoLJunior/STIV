using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class olharAtentoSinaleira : MonoBehaviour {

	[SerializeField] private float currentAmount;
	// speed = 50 para testes
	private float speed = 50;
	private bool shouldIncrease=false;
	public bool sinaleiraOK=false;
	public bool leftOK=false;
	public bool rightOK=false;
	public GameObject olhouEsquerda;
	public GameObject olhouDireita;
	public GameObject sinaleira;
	public Text myText;

	void Update(){
		leftOK = olhouEsquerda.GetComponent<olharAtento>().sideOK;
		rightOK = olhouDireita.GetComponent<olharAtento>().sideOK;
		
		if (olhouEsquerda.GetComponent<olharAtento>().sideOK == true && olhouDireita.GetComponent<olharAtento>().sideOK){
			myText.text = "Olhe para a sinaleira e espere a hora de atravessar";
		}

		if (olhouEsquerda.GetComponent<olharAtento>().sideOK == true && olhouDireita.GetComponent<olharAtento>().sideOK == true && sinaleira.GetComponent<TimerSinaleira>().GetSinalVermelhoStatus() == true) {
			if (shouldIncrease == true) {
				IniciarTimer();
			}
			if (currentAmount >= 99) {
				sinaleiraOK = true;
			}	
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
