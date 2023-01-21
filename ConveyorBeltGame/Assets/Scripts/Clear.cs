using UnityEngine;
public class Clear : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("product"))
        {
            Destroy(other.gameObject);
        }
    }
}
