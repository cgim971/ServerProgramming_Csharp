using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server {
    internal class Program {
        static void Main(string[] args) {
            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("172.31.3.19"), 20000);
                // 서버 소켓에 ip주소, port번호 할당
                serverSocket.Bind(endPoint);

                // 클라이언트들의 연결 요청을 대기하는 상태로 설정
                // 백로그큐 = 클라이언트들의 연결 요청 대기실
                // 20은 백로그큐의 사이즈
                serverSocket.Listen(1000);

                using (Socket clientSocket = serverSocket.Accept()) {
                    Console.WriteLine("연결됨 : " + clientSocket.RemoteEndPoint);

                    byte[] buffer = new byte[256];

                    while (true) {
                        int totalByte = clientSocket.Receive(buffer);

                        // 반환 값이 1 미만 (받은 내용 없을 경우 연결종료)
                        if (totalByte < 1) {
                            Console.WriteLine("클라이언트 연결종료");
                        }

                        // 역직렬화
                        string str = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine(str);

                        clientSocket.Send(buffer);
                    }
                }
            }

        }
    }
}