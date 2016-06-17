using NFeDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NFeDownloader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
                
            }

            return View(new NFe());
        }

        [HttpPost]
        public ActionResult Index(NFe nfe)
        {
            string address = "https://www.fsist.com.br/imprimir/xmls/" + nfe.Numero + ".pdf";
            using (System.Net.WebClient wc = new WebClient())
            {
                try
                {
                    wc.DownloadFile(address, "C:\\Temp\\Arquivo.pdf");

                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", new { errorMessage = e.Message });

                }
                
            }

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return File("C:\\Temp\\Arquivo.pdf", "application/pdf");
            
        }

    }

}