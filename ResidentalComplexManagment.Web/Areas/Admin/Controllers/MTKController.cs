﻿using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    public class MTKController : BaseAdminController
    {
        private readonly IMTK _mtkService;

        public MTKController(IMTK mtkService)
        {
            _mtkService = mtkService;
        }

        public async Task<IActionResult> Index()
        {
            var mtkList =await _mtkService.GetList();
            var model = new MtkIndexVM()
            {
                MKTs = mtkList,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MTKDTO model)
        {
            await _mtkService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var mkt=await _mtkService.GetById(id);
            return View(mkt);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MTKDTO model)
        {
            await _mtkService.Update(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _mtkService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}