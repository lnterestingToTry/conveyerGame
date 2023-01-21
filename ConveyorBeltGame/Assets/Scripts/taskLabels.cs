using TMPro;
using UnityEngine;

public class taskLabels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI num, prodID, tasksLeft;

    public void canvasUpdate(string prodName, int prodNum, int tasks)
    {
        num.text = prodNum.ToString();
        prodID.text = prodName;
        tasksLeft.text = tasks.ToString() + " tasks left";
    }
}
