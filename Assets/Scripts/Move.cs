using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private float rightDeadZone = 0.3f;
    // Use this for initialization
    void Start () {
	
	}
    public float z= 0f;
	// Update is called once per frame
	void Update () {
        doMove();
        doRotate();
    }

    void FixedUpdate()
    {
        
    }

    void doMove()
    {
        var x = Input.GetAxis("Left Horizontal")* 20f*Time.deltaTime;
        var y = Input.GetAxis("Left Vertical")* 20f * Time.deltaTime;
        Vector3 newPos = transform.position;
        newPos.x += x;
        newPos.y += y;
        transform.position = newPos;
    }

    void doRotate()
    {
        var x = Input.GetAxis("Right Horizontal");
        var y = Input.GetAxis("Right Vertical");
        if (x > rightDeadZone || x < -rightDeadZone || y > rightDeadZone || y < -rightDeadZone)
        {
            Vector2 vec = new Vector2(x, y);
            vec.Normalize();
            Vector2 normal = new Vector2(-1, 0);
            var z = (Mathf.Atan2(vec.y, vec.x) - Mathf.Atan2(normal.y, normal.x)) * Mathf.Rad2Deg;
            z += 90;
            this.z = z;
            transform.eulerAngles = new Vector3(0,0,z);
        }
        
        
    }
}

