
using System;

using GloNetworking;

#nullable enable

// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

public partial class KoreEventDriver
{
    public void StartNetworking()
    {

    }

    public void StopNetworking()
    {

    }

    // Usage: KoreEventDriver.NetworkConnect("TcpClient", "TcpClient", "127.0.0.1", 12345);
    public void NetworkConnect(string connName, string connType, string ipAddrStr, int port) => KoreSimFactory.Instance.NetworkHub.createConnection(connName, connType, ipAddrStr, port);

    public void NetworkDisconnect(string connName) => KoreSimFactory.Instance.NetworkHub.endConnection(connName);

    public string ReportLocalIP() => KoreSimFactory.Instance.NetworkHub.localIPAddrStr();

    // Usage: KoreEventDriver.NetworkReport
    public string NetworkReport() => KoreSimFactory.Instance.NetworkHub.Report();

    public void NetworkInjectIncoming(string message) => KoreSimFactory.Instance.NetworkHub.InjectIncomingMessage(message);

    public bool HasIncomingMessage() => KoreSimFactory.Instance.NetworkHub.HasIncomingMessage();

    public GloMessageText? GetIncomingMessage() => KoreSimFactory.Instance.NetworkHub.GetIncomingMessage();

}