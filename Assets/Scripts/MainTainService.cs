using UnityEngine;
using System.Collections;
using Thrift;
using Thrift.Transport;
using Thrift.Protocol;
using Generate;
using System;

public class MainTainService : MonoBehaviour {

    private TTransport transport = null;
    public string serverAddress = "localhost";
    public int serverPort = 7911;
    public bool autoConnect = true;
    private UserStorage.Client client;
    private TProtocol protocol;
    public long sessionId = 0;
	// Use this for initialization
	void Start () {
        if (autoConnect)
        {
            Connect();
        }
	}
	
	public void Connect()
    {
        try
        {
            transport = new TFramedTransport(new TSocket(serverAddress, serverPort));
            protocol = new TBinaryProtocol(transport);
            TMultiplexedProtocol tmp = new TMultiplexedProtocol(protocol, "GameService");
            client = new UserStorage.Client(tmp);
            transport.Open();
            //phrase
        }catch(TApplicationException x)
        {
            Debug.LogWarning(x.StackTrace);
        }catch(Exception x)
        {
            Debug.LogWarning(x.StackTrace);
        }
    }

    public UserStorage.Client GetClient()
    {
        return this.client;
    }

    public void Disconnect()
    {
        if(transport != null)
        {
            transport.Close();
        }
    }

    public long SessionGenerate()
    {
        return client.generateSessionId();
    }
}
