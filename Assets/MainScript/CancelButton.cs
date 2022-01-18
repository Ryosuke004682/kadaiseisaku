using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class CancelButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("cancel");
        });        
    }
}
