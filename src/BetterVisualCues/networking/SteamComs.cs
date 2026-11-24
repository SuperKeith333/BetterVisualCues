using System;
using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public struct PlayerInfo
{
    public string id;
    public String nickname;
}

public class SteamComms
{
    public static SteamComms instance = new();
    internal const byte VISUAL_CUE_EVENT_CODE = 187;
    Action<string, VisualCueEventType, string>? EventHandle;

    public static void Init(Action<string, VisualCueEventType, string> handle)
    {
        instance.EventHandle = handle;
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    public static void Unload()
    {
        instance.EventHandle = null;
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    public static void SendEvent(VisualCueEventType eventType, string e, ReceiverGroup who)
    {
        object[] content = [(int)eventType, e];
        RaiseEventOptions raiseEventOptions = new() {Receivers = who};
        PhotonNetwork.RaiseEvent(VISUAL_CUE_EVENT_CODE, content, raiseEventOptions, SendOptions.SendUnreliable);
    }

    public static PlayerInfo[] AllPlayers()
    {
        return [.. PhotonNetwork.PlayerList.Select(c =>
        new PlayerInfo
        {
            id = c.NickName,
            nickname = c.NickName,
        }
        )];
    }

    public static string? PhotonIdToString(int actorNumber)
    {
        var c = PhotonNetwork.PlayerList.FirstOrDefault(c => c.ActorNumber == actorNumber);
        if (c == null) return null;
        var nick = c.NickName;
        var players = AllPlayers().ToLookup(p => p.nickname, p => p.id);
        return players.Contains(nick) ? players[nick].First() : null;
    }

    public static void OnEvent(EventData e)
    {
        if (e.Code != VISUAL_CUE_EVENT_CODE) return;
        object[] data = (object[])e.CustomData;
        string? sender = PhotonIdToString(e.Sender);
        if (sender == null) return;
        VisualCueEventType eventType = (VisualCueEventType)(int)(data[0]);
        string s = (string)data[1];
        instance.EventHandle?.Invoke(sender, eventType, s);
    }
}