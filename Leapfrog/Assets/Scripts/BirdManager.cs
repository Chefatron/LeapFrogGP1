using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    private int attack;
    private bool attackActive = false;
    public int attackDecide;
    public int attackChance;
    public GameObject upBird;
    public GameObject leftBird;
    public GameObject rightBird;
    public GameObject player;
    private Rigidbody2D upBirdPhys;
    private Rigidbody2D leftBirdPhys;
    private Rigidbody2D rightBirdPhys;
    private Rigidbody2D playerPhys;
    private Transform upBirdTransform;
    private Transform leftBirdTransform;
    private Transform rightBirdTransform;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        upBirdPhys = upBird.GetComponent<Rigidbody2D>();
        leftBirdPhys = leftBird.GetComponent<Rigidbody2D>();
        rightBirdPhys = rightBird.GetComponent<Rigidbody2D>();
        playerPhys = player.GetComponent<Rigidbody2D>();
        upBirdTransform = upBirdPhys.transform;
        leftBirdTransform = leftBirdPhys.transform;
        rightBirdTransform = rightBirdPhys.transform;
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if an attack is currently already happening
        if (attackActive == false)
        {
            upBirdTransform.position = new Vector2(1, (playerTransform.position.y + 15));
            leftBirdTransform.position = new Vector2(-19, playerTransform.position.y);
            rightBirdTransform.position = new Vector2(21, playerTransform.position.y);

            // Random generated number to see if an attack should go ahead
            attackDecide = Random.Range(1, attackChance);

            if (attackDecide == 300)
            {
                // Random number to see what attack to do
                attack = Random.Range(1, 4);

                if (attack == 1)
                {
                    // Random number to see what side up bird should attack from
                    attack = Random.Range(1, 3);
                    if (attack == 1)
                    {
                        upBirdTransform.position = new Vector2(-4, (playerTransform.position.y + 15));
                    }
                    else if (attack == 2)
                    {
                        upBirdTransform.position = new Vector2(6, (playerTransform.position.y + 15));
                    }
                    upBirdPhys.velocity = new Vector2(0, -10);
                    leftBird.SetActive(false);
                    rightBird.SetActive(false);
                    attackActive = true;
                }
                else if (attack == 2)
                {
                    leftBirdPhys.velocity = new Vector2(10, 0);
                    upBird.SetActive(false);
                    rightBird.SetActive(false);
                    attackActive = true;
                }
                else if (attack == 3)
                {
                    rightBirdPhys.velocity = new Vector2(-10, 0);
                    upBird.SetActive(false);
                    leftBird.SetActive(false);
                    attackActive = true;
                }
            }
        }

        if (attackActive == true)
        {
            if (upBirdPhys.position.y < (playerPhys.position.x - 15))
            {
                upBirdTransform.position = new Vector2(1, (playerTransform.position.y + 15));
                leftBird.SetActive(true);
                rightBird.SetActive(true);
                attackActive = false;
            }
            else if (leftBirdPhys.position.x > 25)
            {
                leftBirdTransform.position = new Vector2(-19, playerTransform.position.y);
                upBird.SetActive(true);
                rightBird.SetActive(true);
                attackActive = false;
            }
            else if (rightBirdPhys.position.x < -15)
            {
                rightBirdTransform.position = new Vector2(21, playerTransform.position.y);
                upBird.SetActive(true);
                leftBird.SetActive(true);
                attackActive = false;
            }
        }
    }
}
