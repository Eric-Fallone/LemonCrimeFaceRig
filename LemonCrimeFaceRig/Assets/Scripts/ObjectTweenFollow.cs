using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTweenFollow : MonoBehaviour
{

	public Transform TargetToFollow;

	public float speed;

	public float deadBand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//LeanTween.cancel(this.gameObject);
		//LeanTween.followSpring(this.transform, TargetToFollow, LeanProp.position, 1f, 1f);

		// Move our position a step closer to the target.

		// Check if the position of the cube and sphere are approximately equal.
		if (!(Vector3.Distance(transform.position, TargetToFollow.position) < deadBand))
		{
			float step = speed * Time.deltaTime; // calculate distance to move
			transform.position = Vector3.MoveTowards(transform.position, TargetToFollow.position, step);
		}

	}
}
