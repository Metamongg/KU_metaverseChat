using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class myInfo : MonoBehaviour
{
    //public TMP_Text status;
    public TextMeshProUGUI status2;
    //public Text status3;

    void Update()
    {
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
                        /*status.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "소개 : " + playerInfo.playerIntro + "\n";*/
                        status2.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "소개 : " + playerInfo.playerIntro + "\n";
                        /*status3.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "소개 : " + playerInfo.playerIntro + "\n";*/

                        // 채팅 열기
                        if (targetPlayer != null && !playerInfo.isChatting)
                        {

                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    //status.text = "본인 클릭!";
                    status2.text = "본인 클릭!";
                    //status3.text = "본인 클릭!";
                }
            }
        }
    }
}
