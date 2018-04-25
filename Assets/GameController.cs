using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject moleContainer;
    public TextMesh infoText;
    public Player player;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 15f;
    public float resetTimer = 3f;

    private Mole[] moles;
    private float spawnTimer = 0f;

	// Use this for initialization
	void Start () {
        moles = moleContainer.GetComponentsInChildren<Mole>();
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;

        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            if (spawnTimer <= 0f)
            {
                moles[Random.Range(0, moles.Length)].Rise();

                spawnDuration -= spawnDecrement;
                if (spawnDuration <= minimumSpawnDuration)
                {
                    spawnDuration = minimumSpawnDuration;
                }

                spawnTimer = spawnDuration;
            }

            infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;;
        }
        else
        {
            infoText.text = "Game Over!\nYour score: " + Mathf.Floor(player.score);

            resetTimer -= Time.deltaTime;
            if (resetTimer <=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
