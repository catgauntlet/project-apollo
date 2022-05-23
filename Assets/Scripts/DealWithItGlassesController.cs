using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealWithItGlassesController : MonoBehaviour
{
    [SerializeField] private RawImage dealWithItGlasses;

    private bool glassesFallingDown = false;
    private Vector3 glassesStartPosition;

    private void Start()
    {
        glassesStartPosition = dealWithItGlasses.GetComponent<Transform>().position;
        print(glassesStartPosition);
    }

    private void Update()
    {
        if (glassesFallingDown)
        {
            Vector3 currentPosition = dealWithItGlasses.GetComponent<Transform>().position;
            print(transform.position.y - currentPosition.y);
            print(transform.position.y - glassesStartPosition.y);
            if (transform.position.y - currentPosition.y < -1.5f)
            {
                print(glassesStartPosition);
                Vector3 downWardMovement = new Vector3(0, -2f);
                dealWithItGlasses.GetComponent<Transform>().position = currentPosition + downWardMovement * Time.deltaTime;
            }

        }
    }

    public void DropGlasses()
    {
        dealWithItGlasses.enabled = true;
        glassesFallingDown = true;
    }
}
