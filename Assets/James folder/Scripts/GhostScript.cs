using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public bool onDoor;
	public GameObject targetSetter;
	private AITargetScript ts;

	private void Start()
	{
		ts = targetSetter.GetComponent<AITargetScript>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (ts.playerLightSource != null)
			{
				print("kill player");
			}
		}
	}
}
