using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
	public int id;
	public string description;
	public Sprite sprite;


	// helper variables
    public float timer_useRate = 0f;

	public virtual void Action(Transform equipPoint){
		// base action -- probably just a swing animation if no override?
	}

}
