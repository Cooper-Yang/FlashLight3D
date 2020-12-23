using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public bool onDoor;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			print("kill player");
		}
	}
}
