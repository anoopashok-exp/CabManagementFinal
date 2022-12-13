namespace CabManagement.Areas.Accounts.Controllers  //cp frm MvApp
{
    [Area("Accounts")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly UserManager<Booking> _userManager;
        //private readonly SignInManager<Booking> _signinManager;


        public HomeController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        //[Route("[area]/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // [Route("[area]/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid details.");
                return View(model);
            }

            var res = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (res.Succeeded)
            {
                // return RedirectToAction("Index", "Home", new {Area=""});
                return RedirectToAction(nameof(Bookings));
            }
            ModelState.AddModelError("", "Invalid email / password");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = Guid.NewGuid().ToString().Replace("-", ""),
            };
            var role = Convert.ToString(model.Roles);
            var res = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, role);

            if (res.Succeeded)
            {
                if (role == "Driver")
                {
                    return RedirectToAction("Create", "DriverViewModels", new { Area = "Driver", id = user.Id });
                }

                else
                // await _userManager.AddToRoleAsync(user, "User");             (mine)
                {
                    return RedirectToAction(nameof(Login));
                }
            }

            foreach (var error in res.Errors) //for showing specific error message in register page //
            {
                ModelState.AddModelError("", error.Description);

            }
            return View(model);
        }

        //            ModelState.AddModelError("", "An error occurred.");
        //            return View(model);


        //___________________frm amtr

        [HttpGet]
        public IActionResult Bookings()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Bookings(BookingViewModel model)
        {

            //if (model.PickUp == model.Destination)
            //{
            //    ModelState.AddModelError(nameof(model.Destination), "PickUp Location & Destination can't be the same.");
            //}
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            db.Bookings.Add(new Booking()
            {
                PickUp = model.PickUp,
                Destination = model.Destination,
                Time = model.Time

            });

            await db.SaveChangesAsync();
            //return RedirectToAction(nameof(Payment));
            return RedirectToAction("Payment", "Home", new { Area = "Accounts" });

        }


        //---------------------------------

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }


        //-----------------------------------------
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //___________________________________________


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> GenerateData()
        {
            await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });
            await _roleManager.CreateAsync(new IdentityRole() { Name = "Driver" });

            var users = await _userManager.GetUsersInRoleAsync("Admin");
            if (users.Count == 0)
            {
                var appUser = new ApplicationUser()
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@admin.com",
                    UserName = "admin",
                };
                var res = await _userManager.CreateAsync(appUser, "Pass@123");
                await _userManager.AddToRoleAsync(appUser, "Admin");
            }
            return Ok("Data generated");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var signeduser = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByEmailAsync(signeduser.Email);
            return View(new EditViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var signeduser = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByEmailAsync(signeduser.Email);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Edit));
        }
        public async Task<IActionResult> Delete()
        {
            var signeduser = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByEmailAsync(signeduser.Email);
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(user);
            return Redirect("accounts/home/edit");
        }
    }
}

//------------------------------------------------------------------
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace CabManagement.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class HomeController : Controller
//    {
//        private readonly ApplicationDbContext _db;

//        public HomeController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        public IActionResult Index()
//        {
//            return View(_db.Bookings.ToList());
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        //public async Task<IActionResult> Create(RegisterViewModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //        return View(model);

//        //    _db.Bookings.Add(new Booking()
//        //    {
//        //        Title = model.Title,
//        //        Director = model.Director,
//        //        Language = model.Language,
//        //        ReleaseDate = model.ReleaseDate,
//        //        Summary = model.Summary,
//        //    });
//        //    await _db.SaveChangesAsync();
//        //    return RedirectToAction(nameof(Index));
//        //}

//        [HttpGet]
//        public async Task<IActionResult> Edit(int id)
//        {
//            var movie = await _db.ApplicationUsers.FindAsync(id);
//            if (movie == null)
//                return NotFound();

//            return View(new RegistrationViewModel()
//            {
//                Title = movie.Title,
//                Director = movie.Director,
//                Language = movie.Language,
//                ReleaseDate = movie.ReleaseDate,
//                Summary = movie.Summary
//            });
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(int id, BookingViewModel model)
//        {
//            var book = await _db.Bookings.FindAsync(id);
//            if (book == null)
//                return NotFound();

//            if (!ModelState.IsValid)
//                return View(model);

//            book.FirstName = model.FirstName;
//            book.LastName = model.LastName;
//            book.PickUp = model.PickUp;
//            book.Destination = model.Destination;
//            book.Time = model.;
//            await _db.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var movie = await _db.Movies.FindAsync(id);
//            if (movie == null)
//                return NotFound();

//            _db.Movies.Remove(movie);
//            await _db.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
