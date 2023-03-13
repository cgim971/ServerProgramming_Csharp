using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client {
    internal class Program {
        static async Task Main(string[] args) {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.31.3.19"), 20000);

                // 클라이언트 소켓에 ip주소, port번호 할당
                await socket.ConnectAsync(endPoint);

                while (true) {
                    string str = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    await socket.SendAsync(buffer, SocketFlags.None);
                }
            }
        }
    }
}