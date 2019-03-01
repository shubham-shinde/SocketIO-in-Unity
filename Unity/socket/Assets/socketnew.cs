using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class socketnew : MonoBehaviour
{
    public SocketIOComponent socket;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ConnectToServer());
    }

    IEnumerable ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        socket.Emit("name");
        yield return new WaitForSeconds(1f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
