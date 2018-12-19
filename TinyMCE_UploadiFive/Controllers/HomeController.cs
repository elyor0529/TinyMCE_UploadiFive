using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyMCE_UploadiFive.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    [ValidateInput(false)]
    [ValidateAntiForgeryToken]
    public ActionResult Index(FormCollection form)
    {
      TempData["content"] = form["content"];

      return RedirectToAction("Index");
    }

    [HttpPost]
    public ContentResult Upload(IList<HttpPostedFileBase> files)
    {
      var fileName = "";
      var path = "~/upload/";

      foreach (var file in files)
      {
        if (file == null)
          continue;

        fileName = Path.GetFileName(file.FileName);
        file.SaveAs(Server.MapPath(path) + fileName);
      }

      return Content(Url.Content(path + fileName));
    }

  }
}