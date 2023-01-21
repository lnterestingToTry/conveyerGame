using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    private gameManager gM;
    public bool collected;
    [SerializeField] private int id;

    private void OnMouseDown()
    {

        gM = GetComponentInParent<gameManager>();
        if (gM.prodID == id)
        {
            if (gM.AC_character.GetInteger("state") != 1 && gM.targetProduct == null)
            {
                gM.targetProduct = gameObject;
                gM.handTarget_scr.objToCopy = gameObject;
                gM.handTarget_scr.newTarget = true;
            }
        }
    }
}
