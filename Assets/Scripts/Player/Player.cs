﻿using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	/*How I made it work :
	 * In the animator, I created a variable called AnimState.
	 * If AnimState = 1, then the animator switches to Walk
	 * Else, if its 0, it switches to idle
	 * I used Unity's built in Transitions to do a smooth transition between each.
	 * 
	 * Now, all we need to do is figure out if the player has reached its destination and set the variable accordingly!
	 * 
	 * GG
	 * - Jacob
	 * PS: Use "animator.SetInteger ("AnimState", 0);" to set to 0 (idle) or 1 (walking) and let Unity do everything else.
	 */
	private Animator animator;
	private bool reachedDest;
	NavMeshAgent agent;
	private bool newPath;
	private Vector3 oldDestination;
	private bool rotLastFrameLogged = false;
	private Vector3 rotLastFrame;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		reachedDest = false;
	}
	
	
	// Update is called once per frame
	void Update()
	{
		if(reachedDest == false && rotLastFrameLogged == false) {
			rotLastFrame = new Vector3 (this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
			rotLastFrameLogged = true;
		}
		if(oldDestination != agent.destination) {
			
			oldDestination = agent.destination;
			newPath = true;
			reachedDest = false;
		}
		
		//Run this check so long as we have not reached our destination (our distance > stopping Distance
		if ( Vector3.Distance( agent.destination, agent.transform.position) <= agent.stoppingDistance)
		{
			//If we DONT have a Path. agent.velocity is a fail safe
			if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
			{
				//Since we have no path, don't walk
				animator.SetInteger ("AnimState", 0);
				//We've reached our destination
				reachedDest = true;
				newPath = false;

				transform.eulerAngles = rotLastFrame;
			}
			
		}
		//If we havn't reached our destination
		if(reachedDest == false || newPath == true) {
			//Walk!
			rotLastFrameLogged = false;
			animator.SetInteger ("AnimState", 1);
		}
		
		
		
	}
}