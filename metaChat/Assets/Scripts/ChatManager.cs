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
                // ������ ������Ʈ�� Ŭ���ϸ� �ش� �÷��̾ Ÿ������ �����մϴ�.
                targetPlayer = hit.collider.GetComponent<PhotonView>().Owner;
            }
        }
    }

    public void SendChatMessage()
    {
        if (targetPlayer != null)
        {
            string message = messageInput.text;

            // ������ ���� ������ ���濡�� ä�� �޽����� �����ϴ�.
            photonView.RPC("ReceiveChatMessage", targetPlayer, message);

            // �޽��� �Է� �ʵ带 �ʱ�ȭ�մϴ�.
            messageInput.text = string.Empty;
        }
    }

    [PunRPC]
    private void ReceiveChatMessage(string message, PhotonMessageInfo info)
    {
        // ä�� �޽����� �޾��� �� ó���ϴ� ������ �����մϴ�.
        // ���� ���, ���� �޽����� ä��â�� ǥ���ϰų� �α׷� ����� �� �ֽ��ϴ�.
        string sender = info.Sender.NickName;
        string chatMessage = string.Format("{0}: {1}", sender, message);
        chatText.text += chatMessage + "\n";
    }
}