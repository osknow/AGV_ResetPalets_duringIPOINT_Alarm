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
    class GetIpointFailureTask_pozmda02
    {
        public static async Task<List<GetIpointAlarmTask>> Get()
        {
            string HttpSerwerURI = "https://pozmda02.duni.org/api/DuniTasks/IpointFailureTasks/2";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetFromJsonAsync<List<GetIpointAlarmTask>>(HttpSerwerURI);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
