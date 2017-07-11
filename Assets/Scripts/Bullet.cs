using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private int maxDistance = 50;
    public int power = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        doMove();
        if(checkTooFar())
        {
            Object.Destroy(this.gameObject);
        }
    }

    void doMove()
    {
        var y = 10f * Time.deltaTime;
        transform.Translate(0,y,0);
    }

    bool checkTooFar()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dif = transform.position - player.position;
        if(dif.magnitude>maxDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
