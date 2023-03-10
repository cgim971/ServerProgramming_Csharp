﻿using System.Net;
using System.Text;


namespace Serialize {
    internal class Program {
        static void Main(string[] args) {

            //int num = 1234;

            //// 직렬화
            //byte[] buffer = BitConverter.GetBytes(num);
            //Console.WriteLine(buffer.Length);

            //// 직렬화된 데이터 살펴보기
            //string hex = BitConverter.ToString(buffer);
            //Console.WriteLine(hex);

            //// 역직렬화
            //int num2 = BitConverter.ToInt32(buffer, 0);
            //Console.WriteLine(num2);

            // 리틀엔디안 -> 빅엔디안 변환
            int num3 = IPAddress.HostToNetworkOrder(1234);
            byte[] buffer2 = BitConverter.GetBytes(num3);
            Console.WriteLine(BitConverter.ToString(buffer2));

            // 빅엔디안 -> 리틀엔디안 역직렬화
            int num4 = BitConverter.ToInt32(buffer2);
            int num5 = IPAddress.NetworkToHostOrder(num4);
            Console.WriteLine(num5);

        }
    }
}