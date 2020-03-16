using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
	public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(
			target.position.x, 
			target.position.y-16, //TEMP (need to find a way to get world unit of screen height size) 
			transform.position.z);
    }
}
