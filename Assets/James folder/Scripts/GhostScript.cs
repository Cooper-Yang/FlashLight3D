using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public bool onDoor;
	public GameObject targetSetter;
	private AITargetScript ts;
	//public Animator GhostAnim;
	public Animation GhostAnim;
	public GameObject camControl;

	private void Start()
	{
		ts = targetSetter.GetComponent<AITargetScript>();
	}

    private void Update()
    {
		GhostAnimation();
	}

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			print("collide with player");
			if (ts.playerLightSource != null)
			{
				print("kill player");
				targetSetter.SetActive(false); // disable target setter so ai won't move anymore
				camControl.GetComponent<CamControl>().isDead = true;  //Player die here.
				// implement player die here
			}
		}
	}

	void GhostAnimation()
    {
		if (this.transform.position == targetSetter.transform.position)
		{
			GhostAnim.Play("idle");

		}
		else
			GhostAnim.Play("walk");
    }

}
