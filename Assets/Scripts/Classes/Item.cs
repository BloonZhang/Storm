using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
	public int id;
	public string description;
	public Sprite sprite;
    // TODO: 
    // what's your opinion on a "public float usesPerSecond" here? 
    // It makes sense to me, since we keep track of a timer_useRate here
    // And then we can remove Gun's bulletsPerSecond

    //^ I think useRate and shots per second should be tracked seperately, one is more per click while one is for holding imo

	// helper variables
    [System.NonSerialized] public float timer_useRate = 0f;

	public virtual void Action(Transform equipPoint){
		// base action -- probably just a swing animation if no override?
	}

}
