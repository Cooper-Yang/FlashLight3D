using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform aiTarget;
	public GameObject ghost;
	public float durability;
	private float actualDurability;
	public bool closed;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost"))
		{
			print("ghost on door");
			aiTarget.position = ghost.transform.position;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost"))
		{
			actualDurability -= 1f * Time.deltaTime;
		}
	}

	private void Start()
	{
		actualDurability = durability;
	}

	private void Update()
	{
		if (actualDurability <= 0)
		{
			actualDurability = durability;
			closed = false;
		}
	}
}
