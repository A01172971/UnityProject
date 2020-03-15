using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
	public int life = 500;
	public bool isAlive = true;
	public Transform feet;
	public LayerMask ground;
	float widthFeet = 0.2f;
	float jumpForce = 300f;
	bool inGround = false;
	Animator anim;
	Rigidbody2D rbody;
	bool flip = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    	rbody = GetComponent<Rigidbody2D>();	
    }

    // Update is called once per frame
    void Update()
    {
    	//inGround = Physics2D.OverlapCircle(feet.position, widthFeet, ground);
		//anim.SetBool("pisando", inGround);

    	float walk = Input.GetAxis("Horizontal");
		anim.SetFloat("caminar", Mathf.Abs(walk)); //caminar is the parameter in animator
		rbody.velocity = new Vector2(walk * 5f, rbody.velocity.y);
        if (!flip && walk < 0) Flip();
    	if (flip && walk > 0) Flip();
    
    /*
		if (Input.GetKey(KeyCode.Space) && inGround)
		{
			rbody.AddForce(new Vector2(0,jumpForce));
		}

		anim.SetFloat("altura",rbody.velocity.y);
		*/
    }

    void Flip()
    {
    	flip = !flip;
    	Vector3 scale = transform.localScale;
    	scale.x *= -1;
    	transform.localScale = scale;
    }

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
}
