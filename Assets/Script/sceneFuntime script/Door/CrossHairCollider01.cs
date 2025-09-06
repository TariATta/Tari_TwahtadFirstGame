using UnityEngine;

public class CrossHairCollider01 : MonoBehaviour
{
    public Transform Player;
    [SerializeField] GameObject crossHair;
    void OnMouseOver()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 3)
            {
                crossHair.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
        {
            crossHair.SetActive(false);
        }

    void OnMouseExit()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist >= 3)
            {
                crossHair.SetActive(false);
            }
        }
    }
}
