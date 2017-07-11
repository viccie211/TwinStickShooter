using UnityEngine;
using System.Collections;

    public class Enemy : MonoBehaviour {

        // Use this for initialization
        public int hp = 20;
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if(checkDead())
            {
                Object.Destroy(this.gameObject);
            } 
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
    }
