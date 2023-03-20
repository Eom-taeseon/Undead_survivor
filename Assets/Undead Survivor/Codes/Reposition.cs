using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>(); // Collider2D�� �⺻ ������ ��� collider2D�� ����
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) // collision�� campareTag�� Area�� �ƴ϶�� �ƹ��͵� ���� ����
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; // �÷��̾� ��ġ
        Vector3 myPos = transform.position; // collision�� ��ġ
        //float diffX = Mathf.Abs(playerPos.x - myPos.x); // �÷��̾��� ��ġ - collision�� ��ġ�� ����
        //float diffY = Mathf.Abs(playerPos.y - myPos.y); // �÷��̾��� ��ġ - collision�� ��ġ�� ����

        // Normalized�� �߱� ������ �������ش�.
        // Normalized�� ���ߴٸ� ���� ����
        Vector3 playerDir = GameManager.instance.player.inputVec; // �÷��̾��� �Է� ���� (��ư ����)
        //float dirX = playerDir.x < 0 ? -1 : 1;
        //float dirY = playerDir.y < 0 ? -1 : 1;
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        // �������� logic ����
        switch (transform.tag)
        {
            // transform.tag�� Ground�� ���
            case "Ground":
                if(diffX > diffY)
                {
                    // ������ ����ŭ ���� ��ġ���� �̵�
                    transform.Translate(Vector3.right * dirX * 40); // right �������� player�� ������ ����(dirX) * 40��ŭ�� �Ÿ�(tile�� player���� 20��ŭ �����ϱ�)
                }

                else if (diffX < diffY)
                {
                    // ������ ����ŭ ���� ��ġ���� �̵�
                    transform.Translate(Vector3.up * dirY * 40); // up �������� player�� ������ ����(dirY, ����) * 40��ŭ�� �Ÿ�(tile�� player���� 20��ŭ �����ϱ�)
                }
                break;

            // transform.tag�� Enemy�� ���
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}
