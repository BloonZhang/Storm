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

	// helper variables
    [System.NonSerialized] public float timer_useRate = 0f;

	public virtual void Action(Transform equipPoint){
		// base action -- probably just a swing animation if no override?
	}

}
