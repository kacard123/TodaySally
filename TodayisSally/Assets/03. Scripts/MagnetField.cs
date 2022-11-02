using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public bool magnetTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BasicItemMagnetic>(out BasicItemMagnetic ps) && magnetTime)
        {
            ps.targett = gameObject;
            ps.magnetTime = true;
        }

        if (collision.gameObject.TryGetComponent<BasicMagneticItem2>(out BasicMagneticItem2 ms) && magnetTime)
        {
            ms.targett = gameObject;
            ms.magnetTime = true;
        }

        if (collision.gameObject.TryGetComponent<BasicManneticItem2>(out BasicManneticItem2 bs) && magnetTime)
        {
            bs.targett = gameObject;
            bs.magnetTime = true;
        }
    }
}
