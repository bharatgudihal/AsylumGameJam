using UnityEngine;
using System.Collections;

public class clickButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null && hit.collider.name == this.gameObject.name)
                {
                    Debug.Log(hit.rigidbody.name);
 //                   hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                }
            }
        }
    }
}
