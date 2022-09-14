using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Protocols.FTP;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri host = new Uri("ftp://127.0.0.1");
            Console.WriteLine($"AP:{host.AbsolutePath}, RP:{host.LocalPath}, AU:{host.AbsoluteUri}, OS:{host.OriginalString}");
            Console.WriteLine($"Fragment:{host.Fragment}, host:{host.Host}, authority:{host.Authority}, port:{host.Port}");
            /*
            FTPManager.SkipCertificateValidation = true;
            var client = FTPManager.CreateClient(host, "test");
            try
            {
                var directoryList = FTPManager.ListDirectory(client);
                foreach (var item in directoryList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                //client.UploadFile(@"E:\u.txt","/u.txt");
                //client.DownloadFile(@"E:\d.txt", "/d.txt");
                var s1 = FTPManager.UploadFile(client, @"E:\u.txt", "/");
                Console.WriteLine($"Uploading file complete, status {s1}");
                var s2 = FTPManager.DownloadFile(client,"/d.txt", @"E:\");
                Console.WriteLine($"Dowloading file complete, status {s2}");

                var s3 = FTPManager.UploadDirectoryAsync(client, @"E:\test", "/test");
                s3.Wait();
                var r3 = s3.Result.All((r) => { return r.IsSuccess == true; }) ? "Success" : "Fail";
                Console.WriteLine($"Uploading dir complete, status {r3}");

                var s4 = FTPManager.DownloadDirectoryAsync(client, "/test2", @"E:\test2");
                s4.Wait();
                var r4 = s4.Result.All((r) => { return r.IsSuccess == true; }) ? "Success" : "Fail";
                Console.WriteLine($"Dowloading dir complete, status {r4}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            client.Disconnect();
            */

            Console.ReadKey();
        }
    }
}
