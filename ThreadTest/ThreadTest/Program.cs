namespace ThreadTest {
    internal class Program {
        static void Main(string[] args) {
            int num = 0;
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 1000000; i++) {
                    num++;
                    // A1 : 메모리에서 0을 가져오고
                    // A2 : 1을 더하고
                    // A3 : 메모리에 1을 저장
                }
            });
            t1.Start();

            Thread t2 = new Thread(() => {
                for (int i = 0; i < 1000000; i++) {
                    num++;
                    // B1 : 메모리에서 0을 가져오고
                    // B2 : 1을 더하고
                    // B3 : 메모리에 1을 저장
                }
            });
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(num);
        }
    }
}