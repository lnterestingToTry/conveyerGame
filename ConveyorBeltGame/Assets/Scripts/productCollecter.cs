using UnityEngine;

public class productCollecter : MonoBehaviour
{
    [SerializeField] private gameManager gM;
    [SerializeField] private GameObject cpDefault;
    [SerializeField] private Animation a;

    private void OnTriggerEnter(Collider other)
    {
        TouchHandler tH = other.GetComponent<TouchHandler>();
        if (other.CompareTag("product") && tH.collected == false)
        {
            gM.targetProduct = null;
            gM.handTarget_scr.objToCopy = cpDefault;
            gM.handTarget_scr.newTarget = true;

            gM.AC_character.SetInteger("state", 0);

            other.GetComponent<copyPosition>().objToCopy = other.gameObject;
            other.transform.position = transform.position;
            other.transform.SetParent(transform);

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            tH.collected = true;

            gM.needToCollect -= 1;
            gM.tLUpdate();
            a.PlayQueued("+1 prod");
        }
    }
}
