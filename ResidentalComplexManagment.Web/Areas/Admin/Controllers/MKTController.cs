﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Web.Areas.Admin.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MKTController : BaseAdminController
    {
        private readonly IMTK _mtkService;
        private readonly IBuilding _buildingServie;

        public MKTController(IMTK mtkService, IBuilding buildingServie)
        {
            _mtkService = mtkService;
            _buildingServie = buildingServie;
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

        [HttpGet]
        public async Task<IActionResult> Get(string id,string search="", int page = 1, int size = 30)
        {
            var mtk=  await _mtkService.GetById(id);
            if (mtk == null) return NotFound();         
            var buildings = await _buildingServie.GetBuildingsByMtk(id, search, page, size);
            var model = new MtkGetVM()
            {
                Buildings = buildings,
                MTK = mtk,
                FilterParameter =search,
            };
            return View(model);
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
