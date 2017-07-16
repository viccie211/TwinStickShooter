using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
    public GameObject bullet;
    public Transform spawnlocation;
    private float rightDeadZone = 0.3f;
    private int count = 0;
    public int hp = 20;
    public int cooldown = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        doMove();
        doRotate();
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
        decreaseCooldownFlash();

    }

    void decreaseCooldownFlash()
    {
        SpriteRenderer r = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
        int lastCooldown = cooldown;
        if(cooldown>0)
        {
            if (cooldown % 10 == 0)
            {
                r.enabled = !r.enabled;
            }
            cooldown--;
            if(cooldown==0&&lastCooldown!=0)
            {
                r.enabled = true;
            }
        }
    }

    void doMove()
    {
        var x = Input.GetAxis("Left Horizontal") * 10f * Time.deltaTime;
        var y = Input.GetAxis("Left Vertical") * 10f * Time.deltaTime;
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
            transform.eulerAngles = new Vector3(0, 0, z);
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

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {

            if (cooldown == 0)
            {
                hp--;
                cooldown = 100;
            }
            if (hp <= 0)
            {
                Object.Destroy(this.gameObject);
            }
        }
    }
}
