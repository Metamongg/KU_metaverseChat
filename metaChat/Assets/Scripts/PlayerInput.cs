using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviourPun {

    private GameObject target;

    public string moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string rotateAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름
    public string clickButton = "click";
    
    // 값 할당은 내부에서만 가능
    public float move { get; private set; } // 감지된 움직임 입력값
    public float rotate { get; private set; } // 감지된 회전 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값
    public float click { get; private set; }

    // 매프레임 사용자 입력을 감지
    private void Update() {

        // 로컬 플레이어가 아닌 경우 입력을 받지 않음
        if (!photonView.IsMine)
        {
            return;
        }

        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        if (GameManager.instance != null
            && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            click = 0;
            return;
        }

        // move에 관한 입력 감지
        move = Input.GetAxis(moveAxisName);
        // rotate에 관한 입력 감지
        rotate = Input.GetAxis(rotateAxisName);
        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);

        // 마우스 클릭 입력을 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 통해 클릭한 대상을 확인
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 클릭한 대상이 플레이어인 경우 PlayerInfo 스크립트를 가져와 정보를 출력
                PlayerInfo playerInfo = hit.collider.GetComponent<PlayerInfo>();
                PhotonView photonView = hit.collider.GetComponent<PhotonView>();
                Player targetPlayer = photonView.Owner;

                if (photonView.IsMine == false)
                {
                    if (playerInfo != null)
                    {
                        // 상대 정보 콘솔 출력
                        Debug.Log(photonView.ViewID + " : " + playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "소개 : " + playerInfo.playerIntro + "\n");
                        // 채팅 열기
                        if (targetPlayer != null && !playerInfo.isChatting)
                        {

                        }
                    }
                }
                else
                {
                    Debug.Log(photonView.ViewID + " : " + "본인 클릭!");
                }
            }
        }
    }
}