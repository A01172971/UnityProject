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
	float jump = 25f;
	float velocity = 10f;
	bool inGround = false;
	Animator anim;
	Rigidbody2D rbody;
	bool flip = false;

    //Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //We get the animator component of the player 
    	rbody = GetComponent<Rigidbody2D>(); //We get the rigid body component of the player
    }


    //Update is called once per frame
    void Update()
    {
    	inGround = Physics2D.OverlapCircle(feet.position, widthFeet, ground); //We test if player feets overlap ground
		anim.SetBool("pisando", inGround); //We send it to unity parameter

    	float walk = Input.GetAxis("Horizontal"); //Horizontal axis of the player
		anim.SetFloat("caminar", Mathf.Abs(walk)); //We send it to unity parameter 
		rbody.velocity = new Vector2(walk * velocity, rbody.velocity.y); //velocity of the player
        if (!flip && walk < 0) Flip(); //To change horizontal axis of the player if going to left
    	if (flip && walk > 0) Flip(); //To change horizontal axis of the player if going to right

    	//Jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && inGround)
		{
			rbody.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
		}
		anim.SetFloat("altura",rbody.velocity.y); //We sent it to unity parameter
    }


    //Flip the horizontal axis 
    void Flip()
    {
    	flip = !flip;
    	Vector3 scale = transform.localScale;
    	scale.x *= -1;
    	transform.localScale = scale;
    }


    //Reset the scene
	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
}
