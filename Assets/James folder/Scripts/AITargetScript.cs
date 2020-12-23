using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetScript : MonoBehaviour
{
    public List<Transform> envirlightSources;
    public Transform playerLightSource;
	public GameObject ghost;
	public GhostScript gs;

	private void Start()
	{
		gs = ghost.GetComponent<GhostScript>();
	}

	private void Update()
	{
		if (!gs.onDoor) // if ai is not trying to open a door, look for light sources
		{
			if (playerLightSource != null)
			{
				transform.position = new Vector3(playerLightSource.position.x, 0, playerLightSource.position.z);
			}
			else if (envirlightSources.Count > 0)
			{
				float minDis = int.MaxValue;
				foreach (var source in envirlightSources)
				{
					float dis = Vector3.Distance(source.position, ghost.transform.position);
					if (minDis > dis)
					{
						minDis = dis;
						transform.position = new Vector3(source.position.x, 0, source.position.z);
					}
				}
			}
		}
	}
}
