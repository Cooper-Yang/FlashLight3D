using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetScript : MonoBehaviour
{
	static public AITargetScript me;
    public List<Transform> envirlightSources;
    public Transform playerLightSource;
	public GameObject ghost;
	private GhostScript gs;

	private void Awake()
	{
		me = this;
	}

	private void Start()
	{
		gs = ghost.GetComponent<GhostScript>();
	}

	private void Update()
	{
		if (!gs.onDoor) // if ai is not trying to open a door, look for light sources
		{
			if (playerLightSource != null) // if there is a player light source, then look for player
			{
				transform.position = new Vector3(playerLightSource.position.x, 0, playerLightSource.position.z);
			}
			else if (envirlightSources.Count > 0) // no player light source, but environment light source, look for nearest one
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
			else // no player light source nor environment light source, stand still
			{
				print("stand still");
				transform.position = ghost.transform.position;
			}
		}
	}
	
	public void ChasePlayer(Transform playerTransform)
	{
		playerLightSource = playerTransform;
	}

	public void StopChasingPlayer()
	{
		playerLightSource = null;
	}
}
