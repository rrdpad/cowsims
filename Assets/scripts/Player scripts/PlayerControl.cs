using UnityEngine;
using System.Collections;
using TMPro;
using System.IO;

public class RotateClass : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private TextMeshProUGUI _scoreLabel;
    [SerializeField]
    private float _speed;

    public int scoreCount;
    public int[] purchasedWeapon;

    private Animator _anim;

    // Pause
    private GameObject _pauseConvas;
    public static bool gamePaused = false;

    void Start()
    {
        if (gameObject.name == "Canvas") return;

        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _pauseConvas = GameObject.Find("PauseMenu");
        _pauseConvas.SetActive(gamePaused);

        purchasedWeapon = new int[3];


        if (File.Exists(Application.persistentDataPath + "/player.save"))
        {
            var data = SaveSystem.LoadPlayer();
            scoreCount = data.money;
            purchasedWeapon[0] = data.purchasedWeapon[0];
            purchasedWeapon[1] = data.purchasedWeapon[1];
            purchasedWeapon[2] = data.purchasedWeapon[2];

            _scoreLabel = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
            _scoreLabel.text = $"Кашель: {scoreCount}";
            return;
        }
        scoreCount = 0;
        purchasedWeapon[0] = 0;
        purchasedWeapon[1] = 0;
        purchasedWeapon[2] = 0;
        SaveSystem.SavePlayer(this);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            pauseGame();
        }

        if (gamePaused == true) return;
        LookAtMouse();
        Move();
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }

    private void Move()
    {
        if (gameObject.name != "Canvas")
        {
            var input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
            _rigidbody.velocity = input.normalized * _speed;

            if (input.y < 0 || input.y > 0 || input.x < 0 || input.x > 0)
            {
                _anim.SetBool("is running", true);
            }
            else
            {
                _anim.SetBool("is running", false);
            }
        }
    }

    void pauseGame()
    {
        if (gamePaused == true)
        {
            Time.timeScale = 0f;
            _pauseConvas.SetActive(gamePaused);
        }
        else
        {
            Time.timeScale = 1;
            _pauseConvas.SetActive(gamePaused);
        }
    }
}