using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawnlocation;
    private float rightDeadZone = 0.3f;
    private int count = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {

        if (CheckShoot())
        {
            if (count == 3)
            {
                CreateBullet();
                count = 0;
            }
            else
            {
                count++;
            }
            
        }

    }

    bool CheckShoot()
    {
        var x = Input.GetAxis("Right Horizontal");
        var y = Input.GetAxis("Right Vertical");
        if (x > rightDeadZone || x < -rightDeadZone || y > rightDeadZone || y < -rightDeadZone)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CreateBullet()
    {
        bullet = (GameObject)Instantiate(Resources.Load("Pre_bullet"));
        bullet.transform.position = spawnlocation.transform.position;
        bullet.transform.rotation = spawnlocation.rotation;
    }
}
