using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMarkerMover : MonoBehaviour
{

	public BlendtreeLandMarkHandler BlendHandler;

	public Transform TransformToMove;

	public Transform Min;
	public Transform Max;

    // Update is called once per frame
    void Update()
    {
		TransformToMove.position = Vector3.Lerp(
			Min.position,
			Max.position,
			BlendHandler.getDistanceValue() );    
    }
}
