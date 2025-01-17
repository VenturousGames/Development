﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {
	private GameObject go2;
	private AudioManager AudioPlay;

	public int Wood = 100;
		public int Planks = 50;
	public int Stone = 100;
		public int Slabs = 50;
	public int Iron = 100;
		public int Ingots = 50;
	public int Gold = 1000;

	// Use this for initialization
	void Start () {
		go2 = GameObject.Find("GameAudio");
		AudioPlay = go2.GetComponent<AudioManager> ();
	}
	

	public bool Deduct (int costPlanks, int costWood, int costSlabs, int costGold, int costIron, int costIngots) {
		int error = 0;
		if (costPlanks > Planks || costWood > Wood || costSlabs > Slabs || costGold > Gold || costIngots > Ingots || costIron > Iron) {

			//Find out what we don't have
			if (costPlanks > Planks) {
				error++;
			} if (costWood > Wood) {
				error++;
			} if (costSlabs > Slabs) {
				error++;
			} if (costGold > Gold) {
				error++;
			} if (costIron > Iron) {
				error++;
			} if (costIngots > Ingots) {
				error++;
			}
			if(error >= 2) {
				//Not enough resources
				return false;
			} else {
				if (costPlanks > Planks) {
					//Not enough Planks!
					return false;
				} if (costWood > Wood) {
					AudioPlay.NotEnoughWood();
					return false;
				} if (costSlabs > Slabs) {
					//Not enough Slabs!
					return false;
				} if (costGold > Gold) {
					//Not enough Gold
					return false;
				} if (costIron > Iron) {
					//Not Enough Iron
					return false;
				}if (costIngots > Ingots) {
					//Not enough Ingots
					return false;
				}
			}
			return false;
	} else {
			Planks -= costPlanks;
			Wood -= costWood;
			Slabs -= costSlabs;
			Gold -= costGold;
			Iron -= costIron;
			Ingots -= costIngots;
			return true;
		}
	}


	public void Add (int addPlanks, int addWood, int addStone, int addSlabs, int addGold, int addIron, int addIngots) {
		Planks += addPlanks;
		Wood += addWood;
		Slabs += addSlabs;
		Stone += addStone;
		Gold += addGold;
		Iron += addIron;
		Ingots += addIngots;
		}

	public bool woodDeduct (int cost)
	{
		if (Wood > cost) {
			Wood -= cost;
			return true;
		} else {
			return false;;
			//Play Not Enough Stone!
		}
	}
	public bool plankDeduct (int cost)
	{
		if (Planks > cost) {
			Planks -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool stoneDeduct (int cost)
	{
		if (Stone > cost) {
			Stone -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool slabDeduct (int cost)
	{
		if (Slabs > cost) {
			Slabs -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool ironDeduct (int cost)
	{
		if (Iron > cost) {
			Iron -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool ingotDeduct (int cost)
	{
		if (Ingots > cost) {
			Ingots -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	public bool goldDeduct (int cost)
	{
		if (Gold > cost) {
			Gold -= cost;
			return true;
		} else {
			return false;
			//Play Not Enough Stone!
		}
	}
	


	
	// Update is called once per frame
	void Update () {
	
	}
}
