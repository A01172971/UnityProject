using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	public Transform target;
	float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//Follow the player in horizontal axis
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    	
    	//Moving up alone
    	transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
