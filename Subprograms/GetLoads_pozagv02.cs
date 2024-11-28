﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AGV_ResetPalletsDuringIPOINT_Alarm.Models;

namespace AGV_ResetPalletsDuringIPOINT_Alarm.SubPrograms
{
    class GetLoads_pozagv02
    {
        public static async Task<PalletLoad> Get(int id)
        {
            var url = "https://pozagv02.duni.org:1234/api/locations/" + id + "/loads";


            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("ApiKey", "C1XUN3agvZ9P2ER");
                    client.DefaultRequestHeaders.Add("Content", "application/json");
                    return await client.GetFromJsonAsync<PalletLoad>(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd podczas pobrania danych o punkcie {id}.");
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
