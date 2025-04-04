using UnityEngine;

public class OnTriggerHead : MonoBehaviour
{
    public bool headTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        headTrigger = true;
    }
}
