using UnityEngine;
using UnityEngine.Audio;

public class BirdManager : MonoBehaviour
{
    private int attack;
    private bool attackActive = false;
    private int attackDecide;
    [Min(2)]public int attackChance;
    public int FollowDistanceOffset;
    public float BirdSpeed = 10f;
    public GameObject LeftWarning;
    public GameObject RightWarning;
    public GameObject UpWarning;
    public GameObject LeftAlert;
    public GameObject RightAlert;
    public GameObject UpAlert;
    private Rigidbody2D upBirdPhys;
    private Rigidbody2D leftBirdPhys;
    private Rigidbody2D rightBirdPhys;
    private Transform upBirdTransform;
    private Transform leftBirdTransform;
    private Transform rightBirdTransform;
    private Transform playerTransform;
    private AudioSource BirdAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        LeftWarning.SetActive(false);
        RightWarning.SetActive(false);
        UpWarning.SetActive(false);
        LeftAlert.SetActive(false);
        RightAlert.SetActive(false);
        UpAlert.SetActive(false);
        upBirdPhys = GameObject.Find("Upbird").GetComponent<Rigidbody2D>();
        leftBirdPhys = GameObject.Find("Leftbird").GetComponent<Rigidbody2D>();
        rightBirdPhys = GameObject.Find("Rightbird").GetComponent<Rigidbody2D>();
        upBirdTransform = GameObject.Find("Upbird").GetComponent<Transform>();
        leftBirdTransform = GameObject.Find("Leftbird").GetComponent<Transform>();
        rightBirdTransform = GameObject.Find("Rightbird").GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        BirdAudioSource = GameObject.Find("BirdAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if an attack is currently already happening
        if (attackActive == false)
        {
            upBirdTransform.position = new Vector2(1, (playerTransform.position.y + FollowDistanceOffset));
            leftBirdTransform.position = new Vector2(-19 - FollowDistanceOffset, playerTransform.position.y);
            rightBirdTransform.position = new Vector2(21 + FollowDistanceOffset, playerTransform.position.y);
            UpAlert.transform.position = new Vector2(1.1f, (playerTransform.position.y + 15));
            LeftAlert.transform.position = new Vector2(-7.25f, playerTransform.position.y);
            RightAlert.transform.position = new Vector2(9.95f, playerTransform.position.y);

            // Random generated number to see if an attack should go ahead
            attackDecide = Random.Range(1, attackChance);

            if (attackDecide == 1)
            {
                BirdAudioSource.Play();

                // Random number to see what attack to do
                attack = Random.Range(1, 4);

                if (attack == 1)
                {
                    UpWarning.SetActive(true);
                    UpAlert.SetActive(true);
                    // Random number to see what side up bird should attack from
                    attack = Random.Range(1, 3);
                    if (attack == 1)
                    {
                        upBirdTransform.position = new Vector2(-4, (playerTransform.position.y + FollowDistanceOffset));
                    }
                    else if (attack == 2)
                    {
                        upBirdTransform.position = new Vector2(6, (playerTransform.position.y + FollowDistanceOffset));
                    }
                    attackActive = true;
                    leftBirdTransform.gameObject.SetActive(false);
                    rightBirdTransform.gameObject.SetActive(false);
                    upBirdPhys.velocity = new Vector2(0, -BirdSpeed);
                }
                else if (attack == 2)
                {
                    LeftWarning.SetActive(true);
                    LeftAlert.SetActive(true);
                    attackActive = true;
                    upBirdTransform.gameObject.SetActive(false);
                    rightBirdTransform.gameObject.SetActive(false);
                    leftBirdPhys.velocity = new Vector2(BirdSpeed, 0);
                }
                else if (attack == 3)
                {
                    RightWarning.SetActive(true);
                    RightAlert.SetActive(true);
                    attackActive = true;
                    upBirdTransform.gameObject.SetActive(false);
                    leftBirdTransform.gameObject.SetActive(false);
                    rightBirdPhys.velocity = new Vector2(-BirdSpeed, 0);
                }
            }
        }
        else if (attackActive == true)
        {
            if (upBirdPhys.position.y < (playerTransform.position.y - 15))
            {
                UpWarning.SetActive(false);
                UpAlert.SetActive(false);
                upBirdTransform.position = new Vector2(1, (playerTransform.position.y + FollowDistanceOffset));
                leftBirdTransform.gameObject.SetActive(true);
                rightBirdTransform.gameObject.SetActive(true);
                attackActive = false;
            }
            else if (leftBirdPhys.position.x > 25)
            {
                LeftWarning.SetActive(false);
                LeftAlert.SetActive(false);
                leftBirdTransform.position = new Vector2(-19, playerTransform.position.y);
                upBirdTransform.gameObject.SetActive(true);
                rightBirdTransform.gameObject.SetActive(true);
                attackActive = false;
            }
            else if (rightBirdPhys.position.x < -15)
            {
                RightWarning.SetActive(false);
                RightAlert.SetActive(false);
                rightBirdTransform.position = new Vector2(21, playerTransform.position.y);
                upBirdTransform.gameObject.SetActive(true);
                leftBirdTransform.gameObject.SetActive(true);
                attackActive = false;
            }
            
        }
    }
}

