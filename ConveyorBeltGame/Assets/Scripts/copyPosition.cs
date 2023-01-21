using UnityEngine;

public class copyPosition : MonoBehaviour
{
    public GameObject objToCopy;
    private Vector3 defaultPosition;

    private Vector3 lerpStart;

    private float handTimer;
    public bool newTarget;

    private void Awake()
    {
        defaultPosition = transform.position;
    }

    void Start()
    {
        handTimer = 0f;
    }

    void Update()
    {
        if (objToCopy != null)
        {
            if (CompareTag("handWayPoint"))
            {
                if (newTarget)
                {
                    handTimer = 1f;
                    newTarget = false;
                    lerpStart = transform.position;
                }

                if (handTimer >= 0)
                {
                    transform.position = Vector3.Lerp(lerpStart, objToCopy.transform.position, (1f - handTimer) / 1f);
                    handTimer -= Time.deltaTime;
                    //Debug.Log(transform.position = Vector3.Lerp(lerpStart, objToCopy.transform.position, (10f - handTimer) / 10f));

                }
                else if(objToCopy.CompareTag("hand"))
                {
                    transform.position = objToCopy.transform.position;
                }
            }
            else
            {
                transform.position = objToCopy.transform.position;
            }
        }
        else
        {
            transform.position = defaultPosition;
        }
    }
}
