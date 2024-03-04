using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementObjets : MonoBehaviour
{
    public float vitesse;
    public float placementFin;
    public float placementDebut;
    public float deplacementAleatoire;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= placementFin) 
        {
            transform.position = new Vector2(placementDebut, Random.Range(-deplacementAleatoire, deplacementAleatoire));
            print(transform.position);
        }
        transform.Translate(vitesse, 0, 0);
    }
}
