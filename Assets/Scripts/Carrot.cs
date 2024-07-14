
using UnityEngine;

public class Carrot : MonoBehaviour
{
    //[UsedImplicitly]
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //        Destroy(gameObject);
    //}
    private void Update()
    {
        if(transform.position.y != -3.2f)
        {
            Vector2 target = new Vector2(transform.position.x, - 3.2f);
            //transform.position =  Vector2.Lerp((Vector2)transform.position , target,9.8f*Time.deltaTime);
            transform.position = Vector2.MoveTowards((Vector2)transform.position, target, 9.8f * Time.deltaTime);
        }
    }
    public void OnCatched()
    {
        Destroy(gameObject);
    }

}