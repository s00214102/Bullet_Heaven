using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDetached : MonoBehaviour
{
    [SerializeField]Element currentElement;
    public OrbDetached(Element element)
    {
        currentElement = element;
    }

    private void Start()
    {
        //OrbController orbController = GetComponent<OrbController>();
        //orbController.StopOrbFollow();

        OrbFollow orbFollow = GetComponent<OrbFollow>();
        orbFollow.StopOrb();

        if (this.gameObject.CompareTag("Fire"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;

            GetComponent<Collider2D>().isTrigger = false;
            //this.gameObject.AddComponent<FireCollisions>();
        }
    }
}
