using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int score = 0;
    public GameController gameController;
    public Hammer hammer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                //hit the mole
                if (hit.transform.GetComponent<Mole>() != null && gameController.gameTimer > 0)
                {
                    Mole mole = hit.transform.GetComponent<Mole>();

                    if(mole.moleCanHit == true)
                        score++;

                    mole.OnHit();
                    hammer.Hit(mole.transform.position);

                }
            }
        }
		
	}
}
