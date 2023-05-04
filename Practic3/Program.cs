public TcpClient ();
public TcpClient (System.Net.Sockets.AddressFamily family);
public TcpClient (string hostname, int port);
public TcpClient (System.Net.IPEndPoint localEP);

public Task ConnectAsync (System.Net.IPEndPoint, remoteEP);
public Task ConnectAsync (string host, int port);
public Task ConnectAsync (System.Net.IPAddress address, int port);

using System.Net.Sockets;

using TcpClient tcpClient = new TcpClient();
try
{
    await tcpClient.ConnectAsync("www.google.com", 80);
    Console.WriteLine("Подключение установлено");
}
catch (SocketException ex)
{
    Console.WriteLine(ex.Message);
}

using System.Net.Sockets;

TcpClient tcpClient = new TcpClient();

await tcpClient.ConnectAsync("www.google.com", 80);
Console.WriteLine("Подключение установлено");

tcpClient.Close();
Console.WriteLine(tcpClient.Connected);

using System.Net.Sockets;

using TcpClient tcpClient = new TcpClient();
await tcpClient.ConnectAsync("www.google.com", 80);
NetworkStream stream = tcpClient.GetStream();

public ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
public Task WriteAsync(byte[] buffer, int offset, int count);

using System.Net.Sockets;
using System.Text;
 
using TcpClient tcpClient = new TcpClient();
var server = "www.google.com";
await tcpClient.ConnectAsync(server, 80);
NetworkStream stream = tcpClient.GetStream();

var requestMessage = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";
var requestData = Encoding.UTF8.GetBytes(requestMessage);
await stream.WriteAsync(requestData);

using System.Net.Sockets;
using System.Text;
 
using TcpClient tcpClient = new TcpClient();
var server = "www.google.com";
await tcpClient.ConnectAsync(server, 80);
var stream = tcpClient.GetStream();

var requestMessage = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";
var requestData = Encoding.UTF8.GetBytes(requestMessage);
await stream.WriteAsync(requestData);

var responseData = new byte[512];
var response = new StringBuilder();
int bytes;
do
{
    bytes = await stream.ReadAsync(responseData);
    response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
}
while (bytes > 0);

Console.WriteLine(response);

do
{
    bytes = await stream.ReadAsync(responseData);
    response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
}
while (bytes > 0);

do
{
    bytes = await stream.ReadAsync(responseData);
    response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
}
while (tcpClient.Available > 0);

do
{
    bytes = await stream.ReadAsync(responseData);
    response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
}
while (stream.DataAvailable);

