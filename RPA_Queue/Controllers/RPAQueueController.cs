using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPA_Queue.Models;
using RPA_Queue.Services.Interfaces;
using RPA_Queue.ViewModels;
using System.Collections.Generic;

namespace RPA_Queue.Controllers
{
    public class RPAQueueController : Controller
    {
        private readonly IRPAQueueService _rPAQueueService;
        public RPAQueueController(IRPAQueueService rPAQueueService)
        {
            _rPAQueueService = rPAQueueService;
        }
        public IActionResult Index()
        {
            List<RPAQueueViewModel> viewModel = _rPAQueueService.MapModels();
            
            // Returning empty ViewModel to the screen if our ViewModel is null
            if (viewModel == null)
            {
                RPAQueueViewModel emptyModel = new();
                List<RPAQueueViewModel> EmptyViewModel = new();
                EmptyViewModel.Add(emptyModel);

                return View(EmptyViewModel);
            }
            
            return View(viewModel);
        }

        //GET Create()
        [HttpGet]
        public IActionResult Create()
        {
            RPAQueueViewModel viewModelObj = new();

            if (ModelState.IsValid)
            {
                return View(viewModelObj);
            }

            ErrorViewModel error = new()
            {
                ErrorMessage = "You can't submit empty data!"
            };

            return View("Error", error);
        }

        //POST Create()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RPAQueueViewModel queueObj)
        {
            // Checking if ViewModel [Required] properties for validation are valid.
            if (ModelState.IsValid)
            {
                _rPAQueueService.AddToDb(queueObj);

                return RedirectToAction("Index");
            }

            ErrorViewModel error = new()
            {
                ErrorMessage = "You cannot submit empty data!"
            };
            return View("Error", error);
        }

        //POST Delete()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            _rPAQueueService.DeleteFromDb(id);

            return RedirectToAction("Index");
        }

        //GET Delete()
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            RPAQueueViewModel viewModelObj = _rPAQueueService.GetItemByIdFromDb(id);

            if (viewModelObj == null)
            {
                ErrorViewModel error = new()
                {
                    ErrorMessage = "Entry cannot be deleted. Database cannot be updated, Model or ViewModel object is null."
                };

                return RedirectToAction("Error", error);
            }
            return View(viewModelObj);
        }

        //GET Edit()
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            RPAQueueViewModel viewModelObj =_rPAQueueService.GetItemByIdFromDb(id);

            if (viewModelObj != null)
            {
                return View(viewModelObj);
            }

            ErrorViewModel error = new()
            {
                ErrorMessage = "Cannot edit this item. Model Object is null. No data has been passed to the object." + 
                               " Please check if the database is not empty or if there is an issue with the Model Object or the ViewModel Object!"
            };
            
            return View("Error", error);
        }

        //POST Update()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(RPAQueueModel modelObj)
        {
            
            RPAQueueViewModel viewModelObj = _rPAQueueService.MapModels(modelObj);

            if (string.IsNullOrWhiteSpace(viewModelObj.ProcessOwner) || string.IsNullOrWhiteSpace(viewModelObj.ProjectName))
            {
                ErrorViewModel error = new() { ErrorMessage = "Process Owner and Project Name fileds are mandatory. Please go back and fill them!"};

                return RedirectToAction("Error", error);
            }

            _rPAQueueService.UpdateDb(modelObj);

            return RedirectToAction("Index");
        }

        // Error action
        [HttpGet]
        public IActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }
    }
}
