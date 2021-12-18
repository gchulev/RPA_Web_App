using RPA_Queue.Models;
using RPA_Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA_Queue.Services.Interfaces
{
    public interface IRPAQueueService
    {
        RPAQueueViewModel AddToDb(RPAQueueViewModel obj);
        RPAQueueViewModel UpdateDb(RPAQueueModel obj);
        RPAQueueViewModel DeleteFromDb(int? id);
        RPAQueueViewModel GetItemByIdFromDb(int? id);
        List<RPAQueueViewModel> MapModels();
        RPAQueueModel MapModels(RPAQueueViewModel viewModelObj);
        RPAQueueViewModel MapModels(RPAQueueModel modelObj);
    }
}
