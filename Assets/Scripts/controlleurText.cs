using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlleurText : MonoBehaviour
{
    public TextMeshPro pointageTxt;
    public TextMeshPro pointage;
    public TextMeshPro FinDeJeu;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        pointageTxt.text = "Pointage:";
        FinDeJeu.text = "YOU LOSE";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D infoObjetToucher)
    {
        if (infoObjetToucher.gameObject.name == "PieceOr" || infoObjetToucher.gameObject.name == "PackVie")
        {
            score += 5;
            pointage.text = score.ToString();
        }

        else if (infoObjetToucher.gameObject.name == "Champingon")
        {
            score += 10;
            pointage.text = score.ToString();
        }

        else if (infoObjetToucher.gameObject.name == "Colonne_Haut" || infoObjetToucher.gameObject.name == "Colonne_Bas")
        {
            score -= 5;
            pointage.text = score.ToString();
        }
    }
}