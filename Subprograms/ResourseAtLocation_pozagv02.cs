using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AGV_ResetPalletsDuringIPOINT_Alarm.Models;

namespace AGV_ResetPalletsDuringIPOINT_Alarm.Subprograms
{
    class ResourseAtLocation_pozagv02
    {
        public static async Task SetPallet(int id, int type, int count,int shelf)
        {
            using (var client = new HttpClient())
            {
                #region shelfId

                #endregion
                try
                {
                    var url = "https://pozagv02.duni.org:1234/api/ResourceAtLocation";
                    client.DefaultRequestHeaders.Add("ApiKey", "C1XUN3agvZ9P2ER");
                    client.DefaultRequestHeaders.Add("Content", "application/json");
                    //
                    var data_pallet = new ResourceAtLocation()
                    {
                        symbolicPointId = id,
                        resourceType = type,
                        amount = count,
                        shelfId = shelf
                    };


                    DateTime localDate = DateTime.Now;

                    var response = await client.PostAsJsonAsync(url, data_pallet);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd podczas zapisu  danych palety w punkcie  {id}.");
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
