using UnityEngine;

public class TileScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // dragDown != null || !dragDown._batched
        // 드래그된 유닛인지 확인
        ObjectDragDown dragDown = other.GetComponent<ObjectDragDown>();
        if (dragDown != null == dragDown._batched)
        {
            // 유닛을 타일의 위치에 생성
            Instantiate(dragDown.unitPrefab, this.transform.position, Quaternion.identity);

            // 배치 상태를 true로 변경

            dragDown._batched = true;

            // 드래그된 유닛을 제거
            Destroy(other.gameObject);
        }
    }
}