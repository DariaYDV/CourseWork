using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComputersCA
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62494/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;


                Console.WriteLine("POST");
                Computers newComputers = new Computers()
                {
                    Index = 41,
                    Model = "Asus",
                    Price = 12300.0,
                    CPU = "Intel",
                    RAM = 4
                };

                response = await client.PostAsJsonAsync("api/computers", newComputers);
                if (response.IsSuccessStatusCode)
                {
                    Uri computerUrl = response.Headers.Location;
                    Console.WriteLine(computerUrl);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", newComputers.Index, newComputers.Model,
                        newComputers.Price, newComputers.CPU, newComputers.RAM);

                    Console.WriteLine("Change Price (PUT)");
                    newComputers.Price = 7999.9;
                    response = await client.PutAsJsonAsync(computerUrl, newComputers);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", newComputers.Index, newComputers.Model,
                        newComputers.Price, newComputers.CPU, newComputers.RAM);

                    Console.WriteLine("DELETE");
                    response = await client.DeleteAsync(computerUrl);


                }





                Console.WriteLine("GET");
                response = await client.GetAsync("api/computers/10");
                if (response.IsSuccessStatusCode)
                {
                    Computers computers = await response.Content.ReadAsAsync<Computers>();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", computers.Index, computers.Model,
                        computers.Price, computers.CPU, computers.RAM);
                }

                Console.WriteLine("Get all");
                response = await client.GetAsync("api/computers");
                if (response.IsSuccessStatusCode)
                {
                    List<Computers> computers = await response.Content.ReadAsAsync<List<Computers>>();
                    for (int i = 0; i < computers.Count; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", computers[i].Index, computers[i].Model,
                        computers[i].Price, computers[i].CPU, computers[i].RAM);
                    }

                }
                Console.ReadLine();
            }

        }

    }
}

