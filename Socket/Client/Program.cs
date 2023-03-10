using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client {
    internal class Program {
        static void Main(string[] args) {
            using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.31.3.19"), 20000);

                // 클라이언트 소켓에 ip주소, port번호 할당
                clientSocket.Connect(endPoint);

                while (true) {
                    string str = Console.ReadLine();
                    if (str == "exit") {
                        return;
                    }

                    // 직렬화
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    clientSocket.Send(buffer);


                    byte[] buffer2 = new byte[256];
                    int bytesRead = clientSocket.Receive(buffer2);

                    // 반환 값이 1 미만 (받은 내용 없을 경우 연결종료)
                    if (bytesRead < 1) {
                        Console.WriteLine("서버의 연결종료");
                    }

                    // 역직렬화
                    string str2 = Encoding.UTF8.GetString(buffer2);
                    Console.WriteLine("받음 : " + str2);
                }
            }
        }
    }
}