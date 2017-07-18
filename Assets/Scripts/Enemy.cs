using UnityEngine;
using System.Collections;

    public class Enemy : MonoBehaviour
    {

        // Use this for initialization
        public int hp = 3;
        public float dropChance = 0.01f;
        public Vector3 Player;
        public Vector3 target;
        public GameObject drop;
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
                Points p=(Points)GameObject.FindObjectOfType(typeof(Points));//get the score object
                PlayerBehaviour player = (PlayerBehaviour)GameObject.FindObjectOfType(typeof(PlayerBehaviour));//get the player
                player.killedThisWave++;                                                                        //keep count of the wave
                SpawnEnemies se = (SpawnEnemies)GameObject.FindObjectOfType(typeof(SpawnEnemies));              
                p.points += 10 * se.wave;                                                                       //update the points
                if(Random.Range(0f,1f)<=dropChance)                                                             //check whether it should drop
                {
                    drop = (GameObject)Instantiate(Resources.Load("pre_healthPickup"));
                    drop.transform.position = transform.position;
                }
                if (player.killedThisWave>=se.totalThisWave)                                                    //if wave is finished, then advance
                {
                    se.advanceWave();
                    player.killedThisWave = 0;    
                }
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
            transform.Translate(0f, 2f * Time.deltaTime, 0f);
        }
}
