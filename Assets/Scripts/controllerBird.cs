using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerBird : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;
    public float itemRespawnRate;
    public bool flappyBlesse = false;
    public bool partieTerminee = false;
    public Sprite flappy_dommage_down;
    public Sprite flappy_dommage_up;
    public Sprite flappy_vie_down;
    public Sprite flappy_vie_up;
    public GameObject goldCoin;
    public GameObject packVie;
    public GameObject champi;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (partieTerminee == false) 
        {
            if (Input.GetKey("a"))
            {
                vitesseX = -1;
            }
            else if (Input.GetKey("d"))
            {
                vitesseX = 1;
            }
            else
            {
                vitesseX = GetComponent<Rigidbody2D>().velocity.x;
            }

            if (Input.GetKeyDown("w"))
            {
                if (flappyBlesse == false)
                {
                    GetComponent<SpriteRenderer>().sprite = flappy_vie_up;
                }
                else 
                {
                    GetComponent<SpriteRenderer>().sprite = flappy_dommage_up;
                }
                vitesseY = 4;
            }
            if (Input.GetKeyUp("w"))
            {
                if (flappyBlesse == false)
                {
                    GetComponent<SpriteRenderer>().sprite = flappy_vie_down;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = flappy_dommage_down;
                }
                vitesseY = 4;
            }
            else
            {
                vitesseY = GetComponent<Rigidbody2D>().velocity.y;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
        }
    }
    void OnCollisionEnter2D(Collision2D infoObjetToucher)
    {
        if (infoObjetToucher.gameObject.name == "PieceOr")
        {
            infoObjetToucher.gameObject.SetActive(false);
            Invoke("ActiverGoldCoin", itemRespawnRate);
        }

        else if (infoObjetToucher.gameObject.name == "PackVie")
        {
            flappyBlesse = false;
            infoObjetToucher.gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = flappy_vie_down;
            Invoke("ActiverPackVie", itemRespawnRate);
        }

        else if (infoObjetToucher.gameObject.name == "Champingon")
        {
            infoObjetToucher.gameObject.SetActive(false);
            Invoke("ActiverChampi", itemRespawnRate);
            transform.localScale *= 1.3f;
            Invoke("PetitFlappy", 5f);
        }

        else if (infoObjetToucher.gameObject.name == "Colonne_Haut" || infoObjetToucher.gameObject.name == "Colonne_Bas")
        {
            if (flappyBlesse  == false) 
            {
                flappyBlesse = true;
                GetComponent<SpriteRenderer>().sprite = flappy_dommage_down;
            }
            else
            {
                partieTerminee = true;
                Invoke("ReloadScene", 2f);
                GetComponent<Rigidbody2D>().freezeRotation = false;
                GetComponent<Rigidbody2D>().angularVelocity = -90f;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void ActiverGoldCoin() 
    {
        goldCoin.gameObject.SetActive(true);
    }

    void ActiverPackVie()
    {
        packVie.gameObject.SetActive(true);
    }

    void ActiverChampi()
    {
        champi.gameObject.SetActive(true);
    }

    void PetitFlappy()
    {
        transform.localScale /= 1.3f;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("flappyBird");
    }
}
