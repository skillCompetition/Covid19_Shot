using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    public int bulletLevel;

    private float moveX;
    private float moveY;

    [SerializeField] GameObject[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 moveMentVector = inputValue.Get<Vector2>();
        moveX = moveMentVector.x;
        moveY = moveMentVector.y;

    }

    IEnumerator Fire()
    {
        for (; ; )
        {
            GameObject bullet =  Instantiate(bullets[bulletLevel], transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);

        }


    }


}
