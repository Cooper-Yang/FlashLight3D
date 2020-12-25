using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager me;
    public List<Transform> lightTransforms;

	private void Awake()
	{
		me = this;
	}

	public void UpdateAiTarget()
	{
		AITargetScript.me.envirlightSources.Clear();
		foreach (var source in lightTransforms)
		{
			AITargetScript.me.envirlightSources.Add(source);
		}
	}
}
