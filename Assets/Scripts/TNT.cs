using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        var obstacles =
            Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (var obstacle in obstacles)
            if (obstacle.gameObject.CompareTag("Hitable"))
                Destroy(obstacle.gameObject);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
