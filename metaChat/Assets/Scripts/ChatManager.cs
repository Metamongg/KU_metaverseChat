using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public Text chatText;
    public InputField messageInput;

    private Player targetPlayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 상대방의 오브젝트를 클릭하면 해당 플레이어를 타겟으로 설정합니다.
                targetPlayer = hit.collider.GetComponent<PhotonView>().Owner;
            }
        }
    }

    public void SendChatMessage()
    {
        if (targetPlayer != null)
        {
            string message = messageInput.text;

            // 포톤을 통해 선택한 상대방에게 채팅 메시지를 보냅니다.
            photonView.RPC("ReceiveChatMessage", targetPlayer, message);

            // 메시지 입력 필드를 초기화합니다.
            messageInput.text = string.Empty;
        }
    }

    [PunRPC]
    private void ReceiveChatMessage(string message, PhotonMessageInfo info)
    {
        // 채팅 메시지를 받았을 때 처리하는 로직을 구현합니다.
        // 예를 들어, 받은 메시지를 채팅창에 표시하거나 로그로 출력할 수 있습니다.
        string sender = info.Sender.NickName;
        string chatMessage = string.Format("{0}: {1}", sender, message);
        chatText.text += chatMessage + "\n";
    }
}