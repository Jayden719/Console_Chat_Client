using System.Net.Sockets;
using System.Text;

class Program
{
   

    static void Main(String[] args)
    {
        myClient mc = new myClient();
        mc.Run();
    }

}

 class myClient {

    TcpClient client = null;
    TcpClient clients = null;

    public void Run()
    {
        Console.WriteLine("클라이언트 콘솔창 \n\n");
        Console.WriteLine("서버 연결 하시겠습니까?(Y/N)");
        String key = Console.ReadLine().ToString().ToUpper();

        if (key == "Y")
        {
            Connect();
        }
        else
        {
            Console.WriteLine("프로그램 종료");
            return;
        }
        
    }

    private void SendMsg()
    {
        Console.WriteLine("메세지를 입력해주세요");
        String msg = Console.ReadLine();
        byte[] byteData = new byte[msg.Length];
        byteData = Encoding.Default.GetBytes(msg);

        client.GetStream().Write(byteData, 0, byteData.Length);
        clients.GetStream().Write(byteData, 0, byteData.Length);
        Console.WriteLine("전송성공");
        SendMsg();
    }

    private void Connect()
    {
        client = new TcpClient();
        client.Connect("127.0.0.1", 9999);
        Console.WriteLine("서버연결 성공...");

        clients = new TcpClient();
        clients.Connect("127.0.0.2", 9999);
        Console.WriteLine("서버연결 성공...");

        Console.WriteLine("메세지 보내시겠습니까? (Y/N)");
        String mkey = Console.ReadLine().ToString().ToUpper();

        if (mkey == "Y")
        {
            SendMsg();
        }
        else
        {
            return;
        }


    }
}