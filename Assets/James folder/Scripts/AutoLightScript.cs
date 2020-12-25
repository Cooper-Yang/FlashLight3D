using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLightScript : MonoBehaviour
{
	public List<GameObject> myLightChildren;
	public bool changeMat;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			foreach (var lightSource in myLightChildren)
			{
				print("activate light source");
				lightSource.SetActive(true);
			}
			if (changeMat)
			{
				foreach (var mat in GetComponent<Renderer>().materials)
				{
					print("mat to white");
					mat.SetColor("_EmissionColor", Color.white);
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			foreach (var lightSource in myLightChildren)
			{
				print("disable light source");
				lightSource.SetActive(false);
			}
			if (changeMat)
			{
				foreach (var mat in GetComponent<Renderer>().materials)
				{
					print("mat to black");
					mat.SetColor("_EmissionColor", Color.black);
				}
			}
		}
	}
}
