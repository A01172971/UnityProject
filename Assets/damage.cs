using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
	void OnTriggerStay2D (Collider2D thing)
	{
		if (thing.gameObject.tag == "Player") 
		{
			if (thing.gameObject.GetComponent<player>().isAlive == true) 
			{
				thing.gameObject.GetComponent<player>().life -= 1000;
			}
		}
	}
}
