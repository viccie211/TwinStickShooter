using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

    private int countdown=200;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        countdown--;
        if(countdown<50&&countdown%5==0)
        {
            SpriteRenderer r = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            r.enabled = !r.enabled;
        }
        if(countdown<=0)
        {
            Object.Destroy(gameObject);
        }
    }
}
