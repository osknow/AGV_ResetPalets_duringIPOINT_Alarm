using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGV_ResetPalletsDuringIPOINT_Alarm.Models;
using AGV_ResetPalletsDuringIPOINT_Alarm.Subprograms;
using AGV_ResetPalletsDuringIPOINT_Alarm.SubPrograms;

namespace AGV_ResetPalletsDuringIPOINT_Alarm
{
    class Program
    {
        static async Task Main(string[] args)
        {
#if !DEBUG
      
            Console.SetOut(new MyLoger("W:\\BackgroundTasks\\AGV_ResetPalets\\logs"));
#endif
            Console.WriteLine("OK");
            // Misje AGV
            List<GetMissions> missionsList = await GetMissions_pozagv02.Get();
            // Maszyny biorące udział w pracy AGV
            List<AGV_Matrix> machinesList = await ReadAGVMatrix_pozmda02.Get();
            // Pobranie listy zadań przekierowanych do serwisu z uwagi na awarię IPOINTA
            List<GetIpointAlarmTask> ipointFailureTask = await GetIpointFailureTask_pozmda02.Get();
            // Tylko maszyny biorąće udział w pracy AGV
            List<AGV_Matrix> machinesListCurrentActive = machinesList.FindAll(x => x.active == true && x.pickActive == true);
            // Wyjściowy obiekt
            List<AGV_Matrix> OutMachinesListCurrentActive = machinesListCurrentActive;
            //
            AGV_Matrix tempItem = new AGV_Matrix();
            //
            // LOGIKA
            //
            PalletLoad pallet = new PalletLoad();
            int id = 0;
            //
            foreach (var item in ipointFailureTask)
            {
                //
                if( ! (item.name.Contains("AUTO")) &&  ! (item.details == ""))
                {
                    //
                    id = Convert.ToInt32(item.details);
                    pallet = await  GetLoads_pozagv02.Get(id);
                    //
                    if(! (pallet.Loads.Count == 0))
                    {
                        ResourseAtLocation_pozagv02.SetPallet(id, pallet.Loads[0].TypeId, 0,pallet.Loads[0].ShelfId);
                        Console.WriteLine($"Skasowano paletę z miejsca: {id} na pozycji: {pallet.Loads[0].ShelfId} o typie: {pallet.Loads[0].TypeId}");
                    }
                }


            }


        }
    }
}
