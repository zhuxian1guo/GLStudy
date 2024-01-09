using System;
using BestHTTP;
using BestHTTP.Examples.Helpers;
using BestHTTP.WebSocket;
using UnityEngine;
using UnityEngine.UI;
//namespace BestHTTP.Examples.Websockets;

public class WebSocketMgr : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The WebSocket address to connect")]
    //  wss://besthttpwebgldemo.azurewebsites.net/  
    // 
    //  wss://besthttpwebgldemo.azurewebsites.net/ws
    //  ws://192.168.1.118:9211/websocket/
    //  ws://192.168.1.203:19211/websocket/OIL_TREATMENT_OVERVIEW
    private string address = "ws://192.168.1.203:19211/websocket";


    /// <summary>
    /// Saved WebSocket instance
    /// </summary>
    WebSocket webSocket;

    public void Start()
    {
        OnConnectButton();
    }

    public void SetAddress(string ad) {
        address = ad;
        UIMgr.instance.JSLog("js设置地址是:" + address);
    }

    public void OnConnectButton()
    {
        // Create the WebSocket instance
        Debug.Log("地址是:" + address);
        UIMgr.instance.JSLog("地址是:" + address);
        this.webSocket = new WebSocket(new Uri(address));

        #if !UNITY_WEBGL || UNITY_EDITOR
                this.webSocket.StartPingThread = true;

        #if !BESTHTTP_DISABLE_PROXY && (!UNITY_WEBGL || UNITY_EDITOR)
                if (HTTPManager.Proxy != null)
                    this.webSocket.OnInternalRequestCreated = (ws, internalRequest) => internalRequest.Proxy = new HTTPProxy(HTTPManager.Proxy.Address, HTTPManager.Proxy.Credentials, false);
        #endif
        #endif

        // Subscribe to the WS events
        this.webSocket.OnOpen += OnOpen;
        this.webSocket.OnMessage += OnMessageReceived;
        this.webSocket.OnClosed += OnClosed;
        this.webSocket.OnError += OnError;

        // Start connecting to the server
        this.webSocket.Open();
        Debug.LogWarning("Connecting...");

    }

    public void OnCloseButton()
    {
        //AddText("Closing!");
        // Close the connection
        this.webSocket.Close(1000, "Bye!");

        //SetButtons(false, false);
        //this._input.interactable = false;
    }

    void OnOpen(WebSocket ws)
    {
        Debug.LogWarning("WebSocket Open!");
    }

    void OnMessageReceived(WebSocket ws, string message)
    {
        Debug.Log("Message received:"+message);
    }

    void OnClosed(WebSocket ws, UInt16 code, string message)
    {
        Debug.Log(string.Format("WebSocket closed! Code: {0} Message: {1}", code, message));
        webSocket = null;
    }

    void OnError(WebSocket ws, string error)
    {
        Debug.LogWarning(string.Format("An error occured: <color=red>{0}</color>", error));
        webSocket = null;
    }

}
