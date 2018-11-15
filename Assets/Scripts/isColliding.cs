using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isColliding : MonoBehaviour {

	public bool triggeredByBlock;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "ColliderBottom" || other.gameObject.name == "ColliderFront" || other.gameObject.name == "ColliderBody"){
			// Quando há colisão, o item fica verdadeiro
			triggeredByBlock = true;
			Debug.Log (gameObject.name + " esta ativo");
		}
		//Debug.Log (gameObject.name + " esta passando por " + other.gameObject.name);
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.name == "ColliderBottom" || other.gameObject.name == "ColliderFront" || other.gameObject.name == "ColliderBody"){
			// Quando não há colisão, o item fica falso
			triggeredByBlock = false;
			Debug.Log (gameObject.name + " nao esta ativo");
		}
		//Debug.Log (gameObject.name + " esta saindo de " + other.gameObject.name);
	}
}
