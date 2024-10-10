using System.Net.Sockets;
using System.Text;
using System.Web;

namespace Pretpark
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), 5000);
            server.Start();
            var teller = 0;
            while (true)
            {
                using Socket connectie = server.AcceptSocket();
                using Stream request = new NetworkStream(connectie);
                using StreamReader requestLezer = new StreamReader(request);
                
                string[]? regel1 = requestLezer.ReadLine()?.Split(" ");
                if (regel1 == null) return;
                
                (string methode, string url, string httpversie) = (regel1[0], regel1[1], regel1[2]);
                string? regel = requestLezer.ReadLine();
                int contentLength = 0;
                while (!string.IsNullOrEmpty(regel) && !requestLezer.EndOfStream)
                {
                    string[] stukjes = regel.Split(":");
                    (string header, string waarde) = (stukjes[0], stukjes[1]);
                    if (header.ToLower() == "content-length")
                        contentLength = int.Parse(waarde);
                    regel = requestLezer.ReadLine();
                }
                
                if (contentLength > 0)
                {
                    char[] bytes = new char[(int)contentLength];
                    requestLezer.Read(bytes, 0, (int)contentLength);
                }

                var content = "";
                


                if (url.Equals("/"))
                {
                    content = System.IO.File.ReadAllText("index.html");
                                    
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }
                else if (url.Contains("/teller"))
                {
                    teller++;
                    content = "Teller= "+ teller;
                                    
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }
                else if (url.Contains("/add"))
                {
                    Uri myUri = new Uri("http://localhost:5000" + url);
                    var a = Int32.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("a"));
                    var b = Int32.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("b"));
                    var som = a + b;
                    content = "Som: " + som;
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }
                else if (url.Contains("/mijnteller"))
                {
                    var myUri = new Uri("http://localhost:5000" + url);
                    var t = 0;
                    if (url.Contains("?t="))
                    {
                        t = int.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("t"));
                    }
                    
                    
                    content = "De teller= " + t + "Klik <a href='mijnteller?t=" + (t+1) + "'>hier</a> om de teller te verhogen";
                                    
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }
                else if (url.Contains("/contact"))
                {
                    content = System.IO.File.ReadAllText("contact.html");
                                    
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }
                else
                {
                    content = "404 page not found...";
                    connectie.Send(System.Text.Encoding.ASCII.GetBytes(
                        $"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nContent-Length: {content.Length}\r\n\r\n{content}"));
                }


            }
        }

    }
    
}