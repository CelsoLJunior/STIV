using System.Collections;
using UnityEngine;

public class TimerSinaleira : MonoBehaviour {
	
	//variables
	public int i = 0;
	public float cronometro;
	public float[] temporizador;
	public bool statusVermelho, statusAmarelo, statusVerde;
	Color[] coresDaSinaleira = {Color.red, Color.yellow, Color.green, Color.grey};
	public GameObject[] sinaisParaVeiculos;
	public GameObject[] sinaisParaPedestres;

	void Start(){
		statusVermelho=false;
		statusAmarelo=false;
		statusVerde=true;

		sinaisParaVeiculos[2].GetComponent<Renderer>().material.color = coresDaSinaleira[2];
		sinaisParaPedestres[0].GetComponent<Renderer>().material.color = coresDaSinaleira[0];
	}

	// Update is called once per frame
	void Update () {
		cronometro += Time.deltaTime;

		if (cronometro > temporizador[i]) 
		{
			TrocaSinal();
			cronometro = 0;
			i++;
		}
		if (i == temporizador.Length) 
		{
			i = 0;
		}
	}

	void TrocaSinal(){
		if (statusVermelho == true) 
		{
			// Vermelho DESLIGA && Verde LIGA
			// Fazer sinaleira pedestre piscar
			// sinaisParaPedestres[0].GetComponent<Renderer>().material.color = coresDaSinaleira[0];
			statusVermelho = false;
			sinaisParaVeiculos[0].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			sinaisParaPedestres[1].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			statusVerde = true;
			sinaisParaVeiculos[2].GetComponent<Renderer>().material.color = coresDaSinaleira[2];
			sinaisParaPedestres[0].GetComponent<Renderer>().material.color = coresDaSinaleira[0];
		}
		else if (statusVerde == true) {
			// Verde DESLIGA && Amarelo LIGA
			statusVerde = false;
			sinaisParaVeiculos[2].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			sinaisParaPedestres[1].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			statusAmarelo = true;
			sinaisParaVeiculos[1].GetComponent<Renderer>().material.color = coresDaSinaleira[1];
		}
		else{
			// Amarelo DESLIGA && Vermelho LIGA
			statusAmarelo = false;
			sinaisParaVeiculos[1].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			sinaisParaPedestres[0].GetComponent<Renderer>().material.color = coresDaSinaleira[3];
			statusVermelho = true;
			sinaisParaVeiculos[0].GetComponent<Renderer>().material.color = coresDaSinaleira[0];
			sinaisParaPedestres[1].GetComponent<Renderer>().material.color = coresDaSinaleira[2];
		}
	}

	public bool GetSinalVermelhoStatus(){
		return this.statusVermelho;
	}

	public bool GetSinalAmareloStatus(){
		return this.statusAmarelo;
	}
}
