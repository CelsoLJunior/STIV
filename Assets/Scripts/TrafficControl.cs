using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TrafficControl : MonoBehaviour {

	bool raceStarted = false;
	GameObject[] AICars;
	GameObject sinaleira;
	GameObject paradaCarro;
	public GameObject blocoDaSinaleira;
	float topspeed;

	// Use this for initialization
	void Start () {
		AICars = GameObject.FindGameObjectsWithTag("AICar");
		sinaleira = GameObject.FindGameObjectWithTag("Sinaleira");
		//paradaCarro = GameObject.FindGameObjectWithTag("paradaCarro");

		foreach (GameObject car in AICars) 
		{
			topspeed = car.GetComponent<CarController>().GetVelocidadeMaximaCarro();
		}

		/*foreach (GameObject car in AICars) 
		{
			car.GetComponent<CarAIControl>().enabled = false;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
		if (blocoDaSinaleira.GetComponent<isColliding>().triggeredByBlock == true && sinaleira.GetComponent<TimerSinaleira>().GetSinalAmareloStatus() == true) 
		{
			foreach (GameObject car in AICars) 
				{
					car.GetComponent<CarController>().SetarTopSpeed(1);
				}
		}
		if (blocoDaSinaleira.GetComponent<isColliding>().triggeredByBlock == true && sinaleira.GetComponent<TimerSinaleira>().GetSinalVermelhoStatus() == true) 
		{
			foreach (GameObject car in AICars) 
				{
					car.GetComponent<CarController>().SetarTopSpeed(0);
				}
		}
		if (blocoDaSinaleira.GetComponent<isColliding>().triggeredByBlock == false || sinaleira.GetComponent<TimerSinaleira>().GetSinalVerdeStatus() == true) 
		{
			foreach (GameObject car in AICars) 
			{
				car.GetComponent<CarController>().SetarTopSpeed(topspeed);
			}
		}

		/*
		if (blocoDaSinaleira.GetComponent<isColliding>().triggeredByBlock == true) {
			if (sinaleira.GetComponent<TimerSinaleira>().GetSinalAmareloStatus() == true) 
			{
				foreach (GameObject car in AICars) 
				{
					car.GetComponent<CarController>().SetarTopSpeed(1);
				}
			}
			else if (sinaleira.GetComponent<TimerSinaleira>().GetSinalVermelhoStatus() == true) 
			{
				foreach (GameObject car in AICars) 
				{
					car.GetComponent<CarController>().SetarTopSpeed(0);
				}
			}	
		}
		else {
			foreach (GameObject car in AICars) 
			{
				car.GetComponent<CarController>().SetarTopSpeed(topspeed);
			}
		}
		*/		
	}
}
