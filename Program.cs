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
Console.WriteLine($"Найдено {adapters.Length} устройств");
foreach (NetworkInterface adapter in adapters)
{
Console.WriteLine();
    Console.WriteLine($"ID устройства: {adapter.Id}");
    Console.WriteLine($"Имя устройства: {adapter.Name}");
    Console.WriteLine($"Описание: {adapter.Description}");
    Console.WriteLine($"Тип интерфейса: {adapter.NetworkInterfaceType}");
    Console.WriteLine($"Физический адрес: {adapter.GetPhysicalAddress()}");
    Console.WriteLine($"Статус: {adapter.OperationalStatus}");
    Console.WriteLine($"Скорость: {adapter.Speed}");
    
    IPInterfaceStatistics stats = adapter.GetIPStatistics();
    Console.WriteLine($"Получено: {stats.BytesReceived}");
    Console.WriteLine($"Отправлено: {stats.BytesSent}");
}

using System.Net.NetworkInformation;

var ipProps = IPGlobalProperties.GetIPGlobalProperties();
var tcpConnections = ipProps.GetActiveTcpConnections();

Console.WriteLine($"{tcpConnections.Length} активных TCP-подключений");
Console.WriteLine();
foreach (var connection in tcpConnections)
{
    Console.WriteLine($"Локальный адрес: {connection.LocalEndPoint.Address}:{connection.LocalEndPoint.Port}");
    Console.WriteLine($"Адрес удалённого хоста: {connection.RemoteEndPoint.Address}:{connection.RemoteEndPoint.Port}");
    Console.WriteLine($"Состояние подключения: {connection.State}");
}

using System.Net.NetworkInformation;

var ipProps = IPGlobalProperties.GetIPGlobalProperties();
var ipStats = ipProps.GetIPv4GlobalStatistics();
Console.WriteLine($"Входящие пакеты: {ipStats.ReceivedPackets}");
Console.WriteLine($"Исходящие пакеты: {ipStats.OutputPacketRequests}");
Console.WriteLine($"Отброшено входящих пакетов: {ipStats.ReceivedPacketsDiscarded}");
Console.WriteLine($"Отброшено исходящих пакетов: {ipStats.OutputPacketsDiscarded}");
Console.WriteLine($"Ошибки фрагментации: {ipStats.PacketFragmentFailures}");
Console.WriteLine($"Ошибки восстановления пакетов: {ipStats.PacketReassemblyFailures}");
