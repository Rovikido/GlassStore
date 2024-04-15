using GlassStore.Server.Domain.Models;
using GlassStore.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//namespace GlassStore.Server.Controllers
//{
//    public class Glasses : Controller
//    {
//        // GET: Glasses
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: Glasses/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Glasses/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Glasses/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Glasses/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Glasses/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Glasses/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Glasses/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}


//using AngularApp.Server.Domain.Models;
//using AngularApp.Server.Repositories.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlassStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlassesController : ControllerBase
    {
        private readonly iBaseRepository<Glass> _data;

        public GlassesController(iBaseRepository<Glass> data)
        {
            _data = data;
        }



        // GET: api/<Glass>
        [HttpGet]
        public async Task<DataList<Glass>> Get()
        {
            DataList<Glass> data = new DataList<Glass>();
            data.data = await _data.GetAllAsync();
            data.listSize = data.data.Count();
            return data;

        }


        //GET api/<Glass>/5
        [HttpGet("{id}")]
        public async Task<Glass> Get(string id)
        {
            Glass data = await _data.GetByIdAsync(id);
            return data;

        }

        ////GET api/<Glass>/5
        //[HttpGet("{to}")]
        //public async Task<DataList<Glass>> Get(int to)
        //{
        //    DataList<Glass> data = await _data.GetFirstAsync(to);
        //    return data;

        //}

        // GET api/<Movie>/5
        [HttpGet("getslice/{from}/{to}")]
        public async Task<ActionResult<DataList<Glass>>> GetSlice(int from, int to)
        {
            DataList<Glass> data = await _data.GetSliceAsync(from, to);
            return Ok(data);
        }

        // GET api/<Movie>/5
        //[HttpGet("{id}")]
        //public async Task<Movie> Get(string id)
        //{
        //    Movie data = await _data.GetMovieByIdAsync(id);
        //    return data;
        //}


        // DELETE api/<Movie>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _data.DeleteAsync(id);
        }

        //// POST api/<Movie>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Movie>/5
        //[HttpPut("{id}")]
        //public void Put(string id, [FromBody] string value)
        //{
        //}
    }
}
