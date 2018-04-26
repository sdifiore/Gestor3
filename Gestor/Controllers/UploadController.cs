using Gestor.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Gestor.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult UploadFile()
        {
            ViewBag.retorno = "UploadFile";
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.CustosCargos(path);
                    System.IO.File.Delete(path);
                }

                ViewBag.Message = Global.AtualizacaoOk;
                return View();
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.UploadFile: {ex.Message}");
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "UploadFile";
                return View();
            }
        }

        [HttpGet]
        public ViewResult DespFixas()
        {
            ViewBag.retorno = "DespFixas";
            return View("UploadFile");
        }

        [HttpPost]
        public ViewResult DespFixas(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.DespFixas(path);
                    System.IO.File.Delete(path);
                }

                ViewBag.Message = Global.AtualizacaoOk;
                ViewBag.retorno = "DespFixas";
                return View("UploadFile");
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.DespFixas: {ex.Message}");
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "DespFixas";
                return View("UploadFile");
            }
        }

        [HttpGet]
        public ViewResult FatHist()
        {
            ViewBag.retorno = "FatHist";
            return View("UploadFile");
        }

        [HttpPost]
        public ActionResult FatHist(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.FatHist(path);
                    System.IO.File.Delete(path);
                }

                ViewBag.Message = Global.AtualizacaoOk;
                ViewBag.retorno = "FatHist";
                return View("UploadFile");
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.FatHist: {ex.Message}");
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "FatHist";
                return View("UploadFile");
    }
}
    }
}