using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform aiTarget;
	public GameObject ghost;
	public GhostScript gs;
	public float durability;
	private float actualDurability;
	public bool closed;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost") && closed) // if collide with ghost when door is closed
		{
			print("ghost on door");
			aiTarget.position = ghost.transform.position; // tell ai to stop moving
			gs.onDoor = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost"))
		{
			actualDurability -= 1f * Time.deltaTime; // when ai is inside a trigger, decrease its durability
		}
	}

	private void Start()
	{
		actualDurability = durability;
		gs = ghost.GetComponent<GhostScript>();
	}

	private void Update()
	{
		if (actualDurability <= 0) // if its durability is drained, set door closed to false, reset durability
		{
			actualDurability = durability;
			closed = false;
			gs.onDoor = false;
		}
	}
}
