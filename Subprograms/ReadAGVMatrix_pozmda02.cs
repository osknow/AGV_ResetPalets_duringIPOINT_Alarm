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
    public class ReadAGVMatrix_pozmda02
    {

        public static async Task<List<AGV_Matrix>> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://pozmda02.duni.org/api/AGV/AGV_MachineActiveMatrixListAll";
                    return await client.GetFromJsonAsync<List<AGV_Matrix>>(url);
                    //To POST Deserialization.
                    //HttpResponseMessage  = await client.GetAsync($"{subtaskContext.Subtask.BaseUrl}/api/RareBackgroundTask/{(int)subtaskContext.Subtask.Type}");
                    //response.EnsureSuccessStatusCode(); 
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd podczas odczytania konfiguracji Matrix.");
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
