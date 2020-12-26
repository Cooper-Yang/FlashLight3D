using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public bool onDoor;
	public GameObject targetSetter;
	
	//public Animator GhostAnim;
	public Animation GhostAnim;
	

	

    private void Update()
    {
		GhostAnimation();
	}

    

	void GhostAnimation()
    {
		if (transform.position == targetSetter.transform.position)
		{
			GhostAnim.Play("idle");

		}
		else
			GhostAnim.Play("walk");
    }
}
