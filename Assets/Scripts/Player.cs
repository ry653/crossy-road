using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator Generator;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text BestscoreText;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private Text coinsText;
    //[SerializeField] private GameCore GameCore;
    [Header("music")]
    [SerializeField] private AudioSource deadSound;
    [SerializeField] private AudioSource colectCoinsSound;
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private float thrust;

    private int bestScore;
    private int coins;
    private bool soundOn;

    public float thrustX, thrustZ;
    private int score;
    public bool going = true;
    private Animator animator;
    private bool isHopping;
    private bool fixedUpdateOn;


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best score");
        coins = PlayerPrefs.GetInt("coins");
        soundOn = intToBool(PlayerPrefs.GetInt("val"));
        if (soundOn)
        {
            Mixer.SetFloat("Master", 0);
        }
        else
        {
            Mixer.SetFloat("Master", -80);
        }


        Mixer.SetFloat("Dead", 0);
        fixedUpdateOn = false;
        animator = GetComponent<Animator>();
        Score();
        SwipeController.SwipeEvent += CheckInput;
        coinsText.text = coins + " $";
        BestscoreText.text = "Best score: " + bestScore;
    }
    private void FixedUpdate()
    {
        if (fixedUpdateOn)
        {
            
            if (transform.position.y < 1.4f)
            {
               // rb.AddForce(thrustX, 2, thrustZ, ForceMode.Impulse);
                rb.velocity = new Vector3(thrustX, 2f, thrustZ);
            }
            fixedUpdateOn = false;
           // transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));

        }
    }

    private void MoveCharacter(float thrustX, float thrustZ)
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
        animator.SetTrigger("hop");
        this.thrustX = thrustX;
        this.thrustZ = thrustZ;
        fixedUpdateOn = true;
        Generator.SpawnTerrain(false, transform.position);
        isHopping = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            dead();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            Coins();
        }
        if (collision.collider.GetComponent<Vehicel>() != null)
        {
            if (collision.collider.GetComponent<Vehicel>().islog)
            {
                transform.parent = collision.collider.transform;
            }
            else
            {
                dead();
            }

        }
        else
        {
            transform.parent = null;
        }

    }

    public void dead()
    {

        deadSound.Play();

        animator.SetTrigger("dead");
        going = false;
        rb.isKinematic = true;
        gameOver.gameOver();
        Mixer.SetFloat("Dead", -80);

    }

    public void FinishHop()
    {
        isHopping = false;

    }
    private void Coins()
    {
        colectCoinsSound.Play();
        coins++;
        coinsText.text = coins + " $";
        PlayerPrefs.SetInt("coins", coins);
    }
    private void Score()
    {
        if (score < transform.position.x)
        {
            score = (int)transform.position.x;
            scoreText.text = "Score: " + score;
            if (score > bestScore)
            {
                bestScore = score;
                BestscoreText.text = "Best score: " + bestScore;
                PlayerPrefs.SetInt("Best score", bestScore);
            }
        }
    }
    private void CheckInput(SwipeController.SwipeType type)
    {
        if (going)
        {
            if ((type == SwipeController.SwipeType.UP || Input.GetKeyDown(KeyCode.A)) && !isHopping)
            {
                Score();
                MoveCharacter(thrust, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if ((type == SwipeController.SwipeType.DOWN || Input.GetKeyDown(KeyCode.S)) && !isHopping)
            {
                if (transform.position.x > 1)
                {
                    MoveCharacter(-thrust, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }
            if ((type == SwipeController.SwipeType.LEFT || Input.GetKeyDown(KeyCode.A)) && !isHopping)
            {
                MoveCharacter(0, thrust);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            if ((type == SwipeController.SwipeType.RIGHT || Input.GetKeyDown(KeyCode.D)) && !isHopping)
            {
                MoveCharacter(0, -thrust);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
