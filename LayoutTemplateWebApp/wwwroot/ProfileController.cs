using Microsoft.AspNetCore.Mvc;

public class ProfileController : Controller
{
    public ActionResult Index()
    {
        // Carga la foto de perfil del usuario
        // ...
        return View();
    }

    public ActionResult ChangeProfileImage()
    {
        ViewBag.Images = Directory.GetFiles("wwwroot/images", "*.png");
        return View();
    }

    public ActionResult UpdateProfileImage(string imageName)
    {
        // Actualiza la foto de perfil del usuario
        // ...

        return RedirectToAction("Index");

    }
    

}

