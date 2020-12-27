using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
	public GameObject targetSetter;
	private AITargetScript ts;
	public GameObject camControl;

	private void Start()
	{
		ts = targetSetter.GetComponent<AITargetScript>();
	}

	private void OnTriggerEnter(Collider other)
	{
		print("collided");
		if (other.CompareTag("Player"))
		{
			print("collide with player");
			if (ts.playerLightSource != null)
			{
				print("kill player");
				targetSetter.SetActive(false); // disable target setter so ai won't move anymore
				camControl.GetComponent<CamControl>().isDead = true;  //Player die here.
			}
		}
	}
}
