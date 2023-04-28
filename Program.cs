using System.Net;
using System.Net.NetworkInformation;

UriBuilder uriBuilder1 = new UriBuilder("http", "nke.ru", 80, "sveden/common/");
Uri url1 = uriBuilder1.Uri;
Console.WriteLine(url1);

UriBuilder uriBuilder2 = new UriBuilder();
uriBuilder2.Scheme =
uriBuilder2.Host =
uriBuilder2.Port =
uriBuilder2.Path =
uriBuilder2.Query =
uriBuilder2.Fragment =
Uri url2 = uriBuilder2.Uri;
Console.WriteLine(url2);

using System.Net;

var googleEntry = await
Dns.GetHostEntryAsync("google.com");
Console.WriteLine(googleEntry.HostName);
foreach (var ip in googleEntry.AddressList)
{
    Console.WriteLine(ip);
}

using System.Net.NetworkInformation;

var adapters = NetworkInterface.GetAllNetworkInterfaces();
Console.WriteLine($"������� {adapters.Length} ���������");
foreach (NetworkInterface adapter in adapters)
{
Console.WriteLine();
    Console.WriteLine($"ID ����������: {adapter.Id}");
    Console.WriteLine($"��� ����������: {adapter.Name}");
    Console.WriteLine($"��������: {adapter.Description}");
    Console.WriteLine($"��� ����������: {adapter.NetworkInterfaceType}");
    Console.WriteLine($"���������� �����: {adapter.GetPhysicalAddress()}");
    Console.WriteLine($"������: {adapter.OperationalStatus}");
    Console.WriteLine($"��������: {adapter.Speed}");
    
    IPInterfaceStatistics stats = adapter.GetIPStatistics();
    Console.WriteLine($"��������: {stats.BytesReceived}");
    Console.WriteLine($"����������: {stats.BytesSent}");
}

using System.Net.NetworkInformation;

var ipProps = IPGlobalProperties.GetIPGlobalProperties();
var tcpConnections = ipProps.GetActiveTcpConnections();

Console.WriteLine($"{tcpConnections.Length} �������� TCP-�����������");
Console.WriteLine();
foreach (var connection in tcpConnections)
{
    Console.WriteLine($"��������� �����: {connection.LocalEndPoint.Address}:{connection.LocalEndPoint.Port}");
    Console.WriteLine($"����� ��������� �����: {connection.RemoteEndPoint.Address}:{connection.RemoteEndPoint.Port}");
    Console.WriteLine($"��������� �����������: {connection.State}");
}

using System.Net.NetworkInformation;

var ipProps = IPGlobalProperties.GetIPGlobalProperties();
var ipStats = ipProps.GetIPv4GlobalStatistics();
Console.WriteLine($"�������� ������: {ipStats.ReceivedPackets}");
Console.WriteLine($"��������� ������: {ipStats.OutputPacketRequests}");
Console.WriteLine($"��������� �������� �������: {ipStats.ReceivedPacketsDiscarded}");
Console.WriteLine($"��������� ��������� �������: {ipStats.OutputPacketsDiscarded}");
Console.WriteLine($"������ ������������: {ipStats.PacketFragmentFailures}");
Console.WriteLine($"������ �������������� �������: {ipStats.PacketReassemblyFailures}");
