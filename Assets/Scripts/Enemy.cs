using UnityEngine;
using System.Collections;

    public class Enemy : MonoBehaviour
    {

        // Use this for initialization
        public int hp = 3;
        public Vector3 Player;
        public Vector3 target;
        void Start() {
            
            
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                Player = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
            else
            {
                Player = new Vector3(0, 0, 9);
            }
            if (checkDead())
            {
                Points p=(Points)GameObject.FindObjectOfType(typeof(Points));
                p.points += 100;   
                Object.Destroy(this.gameObject);
            }
            doMove();
        }

        void OnCollisionEnter2D(Collision2D c)
        {
            if (c.gameObject.GetComponent<Bullet>())
            {
                this.hp -= c.gameObject.GetComponent<Bullet>().power;
                Object.Destroy(c.gameObject);
            }
        }

        bool checkDead()
        {
            if(this.hp<=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void doMove()
        {
            if(Player!=null)
            {
                target = new Vector3(Player.x, Player.y, Player.z);
            }

            Vector3 direction = target - transform.position;
            direction = direction.normalized;
            transform.up = direction;
            transform.Translate(0f, 1f * Time.deltaTime, 0f);
        }
}
