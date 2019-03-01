using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;


// State object for receiving data from remote device. 
public class inputChange:MonoBehaviour {

    //public InputField inf;
    private SocketIOComponent socket;
    public InputField T;

    public void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        //socket.On("open", (TestOpen) =>
        //{
        //    Debug.Log(TestOpen);
        //});
        socket.On("open", TestOpen);
        //socket.On("boop", TestBoop);
        socket.On("error", TestError);
        socket.On("close", TestClose);
        socket.On("message", TestOpen);
        socket.On("typing", TestOpen);
        socket.On("name", TestOpen);
        Dictionary<string, string> name = new Dictionary<string, string>();
        name["name"] = "UNITY";
        socket.Emit("name", new JSONObject(name));
    }

    public void lund()
    {
        Dictionary<string, string> msg = new Dictionary<string, string>();
        msg["name"] = "UNITY";
        msg["data"] = T.text;
        socket.Emit("message", new JSONObject(msg));
    }

    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());
    }

    public void TestBoop(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

        if (e.data == null) { return; }

        Debug.Log(
            "#####################################################" +
            "THIS: " + e.data.GetField("this").str +
            "#####################################################"
        );
    }

    public void TestError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void TestClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }
}