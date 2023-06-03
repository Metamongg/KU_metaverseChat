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
            // ���콺�� ���� Ŭ���� ����� Ȯ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ����� �÷��̾��� ��� PlayerInfo ��ũ��Ʈ�� ������ ������ ���
                PlayerInfo playerInfo = hit.collider.GetComponent<PlayerInfo>();
                PhotonView photonView = hit.collider.GetComponent<PhotonView>();
                Player targetPlayer = photonView.Owner;

                if (photonView.IsMine == false)
                {
                    if (playerInfo != null)
                    {
                        /*status.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "�Ұ� : " + playerInfo.playerIntro + "\n";*/
                        status2.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "�Ұ� : " + playerInfo.playerIntro + "\n";
                        /*status3.text = playerInfo.playerDepartment + " " + playerInfo.playerName + "\n" +
                                  "�Ұ� : " + playerInfo.playerIntro + "\n";*/

                        // ä�� ����
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
                    //status.text = "���� Ŭ��!";
                    status2.text = "���� Ŭ��!";
                    //status3.text = "���� Ŭ��!";
                }
            }
        }
    }
}
