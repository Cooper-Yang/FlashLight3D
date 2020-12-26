using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DoorScript : MonoBehaviour
{
    public Transform aiTarget;
	public GameObject ghost;
	public GhostScript gs;
	public float durability;
	private float actualDurability;
	public bool closed;

	public GameObject oppositeCollider;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost") && closed) // if collide with ghost when door is closed
		{
			if (this.GetComponentInParent<DoorMvmt>().canOpenByGhost)
			{
				//print("ghost on door");
				aiTarget.position = ghost.transform.position; // tell ai to stop moving
															  //other.gameObject.GetComponent<AIDestinationSetter>().enabled = false;
				gs.onDoor = true;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Ghost"))
		{
			if (this.GetComponentInParent<DoorMvmt>().canOpenByGhost)
			{
				actualDurability -= 1f * Time.deltaTime; // when ai is inside a trigger, decrease its durability
				if (ghost.GetComponent<PoundingSound>().canPound && closed)
				{
					StartCoroutine(ghost.GetComponent<PoundingSound>().Pounding());
				}
			}
		}
	}

    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("Ghost"))
		{
			if (gs.onDoor)
			{
				gs.onDoor = false;
			}
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
			gs.onDoor = false;
			DoorAnim();
		}
	}

	void DoorAnim()
    {
		if (this.gameObject.name == "InCollider")
		{
			this.GetComponentInParent<DoorMvmt>().isOpen = true;
			this.GetComponentInParent<DoorMvmt>().doorState = 1;
		}
		else if (this.gameObject.name == "OutCollider")
		{
			this.GetComponentInParent<DoorMvmt>().isOpen = true;
			this.GetComponentInParent<DoorMvmt>().doorState = 2;
		}
		closed = false;
		oppositeCollider.GetComponent<DoorScript>().closed = closed;
	}

}
