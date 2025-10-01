using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowITEquip.Models
{
    public static class Repository
    {
        private static readonly List<EquipmentRequest> requests = new();
        private static int newId = 1;
        public static IEnumerable<EquipmentRequest> Requests => requests;

        public static void AddRequest(EquipmentRequest request)
        {
            request.Id = newId++;
            requests.Add(request);
        }
    }
}