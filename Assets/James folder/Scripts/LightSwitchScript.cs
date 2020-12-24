using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public List<GameObject> lightsIcontrol;
	public bool changeMatToo;

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
