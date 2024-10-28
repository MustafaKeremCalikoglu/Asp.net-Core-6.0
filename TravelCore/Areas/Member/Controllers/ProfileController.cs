using AutoMapper;
using DTOLayer.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelCore.Areas.Member.Models;

namespace TravelCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]


    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserUpdateDTOs userEditViewModel = new AppUserUpdateDTOs();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.imageurl = values.ImageUrl;

            return View(userEditViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(AppUserUpdateDTOs p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); // Giriş yapan kullanıcıyı bul

            if (p.Image != null) // Yeni resim yüklendiyse
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/userimages", imagename);

                await using var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);

                user.ImageUrl = "/userimages/" + imagename; // Resim URL'sini güncelle
            }

            // Model doğrulama
            if (ModelState.IsValid)
            {
                // Şifre güncelleme işlemi
                if (!string.IsNullOrEmpty(p.password) && !string.IsNullOrEmpty(p.oldPassword))
                {
                    // Eski şifreyi doğrula
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, p.oldPassword);
                    if (!passwordCheck) // Eski şifre yanlışsa
                    {
                        ModelState.AddModelError("oldPassword", "Eski şifre yanlış."); // Hata mesajını ekle
                        return View(p); // Hata varsa mevcut sayfayı yeniden yükle
                    }

                    // Eski şifre doğruysa yeni şifreyi değiştir
                    var passwordResult = await _userManager.ChangePasswordAsync(user, p.oldPassword, p.password);
                    if (!passwordResult.Succeeded) // Şifre kurallara uymuyorsa
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description); // Hata mesajlarını ekrana yazdır
                        }
                        return View(p); // Hata varsa mevcut sayfayı yeniden yükle
                    }
                }

                // Kullanıcı bilgilerini güncelle
                user.PhoneNumber = p.phonenumber;
                user.Name = p.name;
                user.Surname = p.surname;

                var result = await _userManager.UpdateAsync(user); // Kullanıcıyı güncelle

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login"); // Başarılıysa giriş sayfasına yönlendir
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description); // Diğer hataları göster
                    }
                }
            }

            return View(p); // Model geçersizse veya hata varsa mevcut sayfayı yeniden yükle
        }





    }
}
