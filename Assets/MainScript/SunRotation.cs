using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 2) * Time.deltaTime);
    }
}
