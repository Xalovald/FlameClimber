using UnityEngine;

public class BonusCoin : MonoBehaviour
{
    public float speedBoost = 25f;
    public bool isTouched;

    public Transform topCheckLeft;
    public Transform topCheckRight;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.AddCoin();
            player.BoostSpeed(speedBoost);
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isTouched = Physics2D.OverlapArea(topCheckLeft.position, topCheckRight.position);

        if (isTouched)
        {
            Destroy(gameObject);
        }
    }
}
