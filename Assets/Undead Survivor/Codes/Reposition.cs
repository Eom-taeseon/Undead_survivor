using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>(); // Collider2D는 기본 도형의 모든 collider2D를 포함
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) // collision의 campareTag가 Area가 아니라면 아무것도 실행 안함
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; // 플레이어 위치
        Vector3 myPos = transform.position; // collision의 위치
        //float diffX = Mathf.Abs(playerPos.x - myPos.x); // 플레이어의 위치 - collision의 위치의 차이
        //float diffY = Mathf.Abs(playerPos.y - myPos.y); // 플레이어의 위치 - collision의 위치의 차이

        // Normalized를 했기 때문에 조정해준다.
        // Normalized를 안했다면 생략 가능
        Vector3 playerDir = GameManager.instance.player.inputVec; // 플레이어의 입력 벡터 (버튼 누름)
        //float dirX = playerDir.x < 0 ? -1 : 1;
        //float dirY = playerDir.y < 0 ? -1 : 1;
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        // 본격적인 logic 실행
        switch (transform.tag)
        {
            // transform.tag가 Ground인 경우
            case "Ground":
                if(diffX > diffY)
                {
                    // 지정된 값만큼 현재 위치에서 이동
                    transform.Translate(Vector3.right * dirX * 40); // right 방향으로 player가 움직인 방향(dirX) * 40만큼의 거리(tile이 player기준 20만큼 있으니까)
                }

                else if (diffX < diffY)
                {
                    // 지정된 값만큼 현재 위치에서 이동
                    transform.Translate(Vector3.up * dirY * 40); // up 방향으로 player가 움직인 방향(dirY, 음수) * 40만큼의 거리(tile이 player기준 20만큼 있으니까)
                }
                break;

            // transform.tag가 Enemy인 경우
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}
