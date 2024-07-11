using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PorbarWebApp.Data;
using PorbarWebApp.Data.Enums;
using PorbarWebApp.Dtos.Account;
using PorbarWebApp.Interfaces;
using PorbarWebApp.Models;
using PorbarWebApp.Services;

namespace PorbarWebApp.Controllers
{
    [AllowAnonymous]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailService _mailService;

        public AccountsController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context,
            IMailService mailService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if(_signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View(registerDto);

            var user = await _userManager.FindByEmailAsync(registerDto.EmailAddress);
            if (user != null)
            {
                return View(registerDto);
            }

            var newUser = new User()
            {
                Email = registerDto.EmailAddress,
                UserName = registerDto.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (newUserResponse.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                _mailService.SendEmailConfirmation(newUser, Request.Scheme, Request.Host.ToString(),Url.Action("ConfirmEmail", new { userId = newUser.Id, code = code }));
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return RedirectToAction("Index", "Home");
            }

            return View(registerDto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var user = await _userManager.FindByEmailAsync(loginDto.EmailAddress);

            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //Password is incorrect
                return View(loginDto);
            }
            //User not found
            return View(loginDto);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("The Link is Not Valid");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("The Link is Not Valid");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            var status = result.Succeeded ? "Thank you For confirming your email, have a good day" : "The Link is Not Valid";
            return Ok(status);
        }

    }
}
