﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
	public Material canPlaceMaterial;
	public Material cantPlaceMaterial;
	public GameObject objectToBePlaced;

	private bool _canPlace = false;
	private Renderer objectsRenderer;
	private Bounds objectBounds;

    // Start is called before the first frame update
    void Start()
    {
		objectsRenderer = this.GetComponent<Renderer>();
		objectBounds = objectsRenderer.bounds;
    }

    // Update is called once per frame
    void Update()
    {
		SetObjectMaterial();
    }

	private void SetObjectMaterial()
	{
		if (_canPlace)
		{
			objectsRenderer.material = canPlaceMaterial;
		} else
		{
			objectsRenderer.material = cantPlaceMaterial;
		}
	}

	public void SetCanPlace(float normalValue)
	{
		if(normalValue == 1)
		{
			_canPlace = true;
		} else
		{
			_canPlace = false;
		}
	}

	public void PlaceObject(Vector3 place, Quaternion rotation)
	{
		if (_canPlace)
		{
			GameObject createdObject =  Instantiate(objectToBePlaced, place + new Vector3(0, objectBounds.extents.y, 0), rotation);
			createdObject.GetComponent<ObjectScript>().SetCanPlace(1);
		}
	}
}
