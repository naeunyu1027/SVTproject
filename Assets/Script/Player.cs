using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 7f;
    private GameObject currentPasswordUI; // 현재 열려 있는 비밀번호 UI
    private Looks currentLooks; // 현재 감지된 Looks
    private Vector2 lastDirection; // 마지막으로 누른 방향

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        lastDirection = Vector2.up; // 기본 방향은 위
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(x * speed, y * speed);

        // 키 입력에 따라 마지막 방향 업데이트
        if (x != 0) lastDirection = new Vector2(x, 0); // 수평 방향 입력
        else if (y != 0) lastDirection = new Vector2(0, y); // 수직 방향 입력    
              

        CheckLooks(); // Looks 감지
    }

    void CheckLooks()
    {
        float rayDistance = 1.8f; // 레이 길이
        Debug.DrawRay(transform.position, lastDirection.normalized * rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection.normalized, rayDistance, LayerMask.GetMask("Entity"));

        if (hit.collider != null) {// Looks를 감지했을 경우
            Looks newLooks = hit.collider.GetComponent<Looks>(); // Looks 오브젝트 가져오기

            if (newLooks != currentLooks) // 감지된 Looks가 바뀌었을 경우
            {
                if (currentPasswordUI != null) // 기존에 열려 있던 UI 닫기
                {
                    currentPasswordUI.SetActive(false);
                    currentPasswordUI = null;
                }

                currentLooks = newLooks; // 현재 감지된 Looks를 업데이트

                if (currentLooks != null && currentLooks.passwordUI != null) // 새로운 Looks에 UI가 있다면
                {
                    currentPasswordUI = currentLooks.passwordUI; // 현재 UI 변경
                }
            }
        }
        else // Looks를 감지하지 못한 경우
        {
            if (currentPasswordUI != null) // 기존 UI가 열려 있으면 닫기
            {
                currentPasswordUI.SetActive(false);
                currentPasswordUI = null;
            }
            currentLooks = null; // 감지된 Looks 초기화
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentLooks != null) // F 키를 눌렀고 Looks가 감지된 경우
        {
            if (currentPasswordUI != null) // 감지된 Looks에 연결된 UI가 있다면
            {
                currentPasswordUI.SetActive(!currentPasswordUI.activeSelf); // UI를 토글 (켜고/끄기)
            }
        }
    }
}
