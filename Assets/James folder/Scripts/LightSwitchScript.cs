using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public List<GameObject> lightsIcontrol;
	public bool changeMatToo;
	private float timer = 0;

	private void Start()
	{
		timer = LightManager.me.lightDuration;
		for (int i = 0; i < lightsIcontrol.Count; i++) // get all the lamps i control
		{
			for (int j = 0; j < lightsIcontrol[i].transform.childCount; j++) // get all the children of the lamps
			{
				if (lightsIcontrol[i].transform.GetChild(j).CompareTag("Light")) // if the child is a light source
				{
					if (lightsIcontrol[i].transform.GetChild(j).gameObject.activeSelf) // if the light source is active
					{
						lightsIcontrol[i].transform.GetChild(j).gameObject.SetActive(false);
						if (changeMatToo) // if the lamp is glowing
						{
							foreach (var mat in lightsIcontrol[i].GetComponent<Renderer>().materials)
							{
								mat.SetColor("_EmissionColor", Color.black); // mute it
							}
						}
					}
				}
			}
		}
	}

	private void Update()
	{
		if (timer > 0 && lightsIcontrol[0].transform.GetChild(0).gameObject.activeSelf && lightsIcontrol[0].transform.GetChild(0).CompareTag("Light")) // if timer > 0 and lights are on
		{
			print(transform.position + ": " + timer);
			timer -= Time.deltaTime; // count down
		}
		else if (timer <= 0) // if time is up
		{
			if (lightsIcontrol[0].transform.GetChild(0).gameObject.activeSelf) // if lights are still on
			{
				SwitchLights(); // turn them off;
				timer = LightManager.me.lightDuration;
			}
		}
		else if (!lightsIcontrol[0].transform.GetChild(0).gameObject.activeSelf) // if lights are off
		{
			timer = LightManager.me.lightDuration; // reset timer
		}
	}

	public void SwitchLights()
	{
		for (int i = 0; i < lightsIcontrol.Count; i++)
		{
			for (int j = 0; j < lightsIcontrol[i].transform.childCount; j++)
			{
				if (lightsIcontrol[i].transform.GetChild(j).CompareTag("Light"))
				{
					if (lightsIcontrol[i].transform.GetChild(j).gameObject.activeSelf)
					{
						print("turn it off");
						LightManager.me.lightTransforms.Remove(lightsIcontrol[i].transform);
						LightManager.me.UpdateAiTarget();
						lightsIcontrol[i].transform.GetChild(j).gameObject.SetActive(false);
						if (changeMatToo)
						{
							foreach (var mat in lightsIcontrol[i].GetComponent<Renderer>().materials)
							{
								mat.SetColor("_EmissionColor", Color.black);
							}
						}
					}
					else
					{
						print("turn them on");
						LightManager.me.lightTransforms.Add(lightsIcontrol[i].transform);
						LightManager.me.UpdateAiTarget();
						lightsIcontrol[i].transform.GetChild(j).gameObject.SetActive(true);
						if (changeMatToo)
						{
							foreach (var mat in lightsIcontrol[i].GetComponent<Renderer>().materials)
							{
								mat.SetColor("_EmissionColor", Color.white);
							}
						}
					}
				}
			}
		}
		
	}
}
