using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cukinia : MonoBehaviour
{
    [Range(0.5f,5f)]
    [SerializeField] float speed;
    [Range(1f,10f)]
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newXpos = transform.position.x + speed * Time.fixedDeltaTime;
        transform.position = new Vector2(newXpos, transform.position.y);
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 1 *rotationSpeed, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "enemy" || collision.tag == "motyl")
        {
            Destroy(gameObject);
        }else if (collision.tag == "Shreder")
        {
            Destroy(gameObject);
        }
        
    }
}
