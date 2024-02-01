using UnityEngine;

public class Container : MonoBehaviour
{
    public bool isFull;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 들어온 오브젝트가 드래그 중인 오브젝트이고, 컨테이너가 꽉 차 있지 않다면
        if (collision.gameObject.GetComponent<ObjectDragDown>() && !isFull)
        {
            // 컨테이너를 꽉 차게 합니다.
            isFull = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 나가는 오브젝트가 드래그 중인 오브젝트라면
        if (collision.gameObject.GetComponent<ObjectDragDown>())
        {
            // 컨테이너를 비웁니다.
            isFull = false;
        }
    }
}