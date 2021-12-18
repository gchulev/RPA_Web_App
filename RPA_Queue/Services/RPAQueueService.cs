using RPA_Queue.Data;
using RPA_Queue.Models;
using RPA_Queue.Services.Interfaces;
using RPA_Queue.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RPA_Queue.Services
{
    public class RPAQueueService : IRPAQueueService
    {
        private readonly RPAQueueDBContext _db;
        public RPAQueueService(RPAQueueDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Takes a ViewModel, maps it to a Model, saves the Model to the DB and retruns the ViewModel.
        /// </summary>
        /// <param name="viewModelObj"></param>
        /// <returns></returns>
        public RPAQueueViewModel AddToDb(RPAQueueViewModel viewModelObj)
        {
            RPAQueueModel modelObj = MapModels(viewModelObj);

            if (modelObj == null)
            {
                return null;
            }
            
            _db.RPAQueue.Add(modelObj);
            _db.SaveChanges();

            return viewModelObj;
        }

        /// <summary>
        /// Receives 'id' parameter and find Model object in the database then converts the Model object to ViewModel object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> RPAQueueViewModel object </returns>
        public RPAQueueViewModel GetItemByIdFromDb(int? id)
        {
            if (id == 0 || id == null)
            {
                return null;
            }

            RPAQueueModel obj = _db.RPAQueue.Find(id);

            if (obj == null)
            {
                return null;
            }

            RPAQueueViewModel viewModelObj = MapModels(obj);

            return viewModelObj;
        }

        /// <summary>
        /// Received 'id' parameter and finds the Model object in the database, then removes it and saves changes to the DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RPAQueueViewModel DeleteFromDb(int? id)
        {
            if (id == 0 || id == null)
            {
                return null;
            }

            RPAQueueModel modelObj = _db.RPAQueue.Find(id);

            if (modelObj == null)
            {
                return null;
            }

            _db.RPAQueue.Remove(modelObj);
            _db.SaveChanges();

            RPAQueueViewModel viewModelObj = MapModels(modelObj);

            return viewModelObj;
        }

        /// <summary>
        /// This method takes Model object and updates the DB with that object.
        /// Then returns ViewModel object.
        /// </summary>
        /// <param name="modelObj"></param>
        /// <returns></returns>
        public RPAQueueViewModel UpdateDb(RPAQueueModel modelObj)
        {
            if (modelObj == null)
            {
                return null;
            }

            _db.RPAQueue.Update(modelObj);
            _db.SaveChanges();

            RPAQueueViewModel viewModelObj = MapModels(modelObj);

            return viewModelObj;
        }

        /// <summary>
        /// Maps Model to ViewModel and returns List of ViewModel.
        /// </summary>
        /// <returns> List<RPAQueueViewModel> object </returns>
        public List<RPAQueueViewModel> MapModels()
        {
            //Mapping from Model to ViewModel
            List<RPAQueueViewModel> viewModelsObj = new();

            foreach (RPAQueueModel item in _db.RPAQueue)
            {
                RPAQueueViewModel vmObj = new()
                {
                    Id = item.Id,
                    ProjectName = item.ProjectName,
                    Group = item.Group,
                    Department = item.Department,
                    CostCenter = item.CostCenter,
                    ProcessOwner = item.ProcessOwner,
                    Account = item.Account,
                    LicenseType = item.LicenseType,
                    Note = item.Note,
                    DevelopmentStatus = item.DevelopmentStatus,
                    Schedule = item.Schedule,
                    RunningTimes = item.RunningTimes,
                    UsedApps = item.UsedApps,
                    DevelopedOn = item.DevelopedOn,
                };

                viewModelsObj.Add(vmObj);
            }
            return viewModelsObj;
        }

        /// <summary>
        /// Maps ViewModel to Model and returns the Model. Accepts RPAQueueViewModel type object.
        /// </summary>
        /// <param name="viewModelObj"></param>
        /// <returns></returns>
        public RPAQueueModel MapModels(RPAQueueViewModel viewModelObj)
        {
            //Mapping from ViewModel to Model
            RPAQueueModel model = new();
            
            model.Id = viewModelObj.Id;
            model.ProjectName = viewModelObj.ProjectName;
            model.Group = viewModelObj.Group;
            model.Department = viewModelObj.Department;
            model.CostCenter = viewModelObj.CostCenter;
            model.ProcessOwner = viewModelObj.ProcessOwner;
            model.Account = viewModelObj.Account;
            model.LicenseType = viewModelObj.LicenseType;
            model.Note = viewModelObj.Note;
            model.DevelopmentStatus = viewModelObj.DevelopmentStatus;
            model.Schedule = viewModelObj.Schedule;
            model.RunningTimes = viewModelObj.RunningTimes;
            model.UsedApps = viewModelObj.UsedApps;
            model.DevelopedOn = viewModelObj.DevelopedOn;

            return model;
        }

        /// <summary>
        /// Maps Model to ViewModel and returns ViewModel. Accepts RPAQueueModel type parameter.
        /// </summary>
        /// <param name="modelObj"></param>
        /// <returns></returns>
        public RPAQueueViewModel MapModels(RPAQueueModel modelObj)
        {
            RPAQueueViewModel viewModelObj = new();

            viewModelObj.Id = modelObj.Id;
            viewModelObj.ProjectName = modelObj.ProjectName;
            viewModelObj.Group = modelObj.Group;
            viewModelObj.Department = modelObj.Department;
            viewModelObj.CostCenter = modelObj.CostCenter;
            viewModelObj.ProcessOwner = modelObj.ProcessOwner;
            viewModelObj.Account = modelObj.Account;
            viewModelObj.LicenseType = modelObj.LicenseType;
            viewModelObj.Note = modelObj.Note;
            viewModelObj.DevelopmentStatus = modelObj.DevelopmentStatus;
            viewModelObj.Schedule = modelObj.Schedule;
            viewModelObj.RunningTimes = modelObj.RunningTimes;
            viewModelObj.UsedApps = modelObj.UsedApps;
            viewModelObj.DevelopedOn = modelObj.DevelopedOn;

            return viewModelObj;
        }
    }
}
