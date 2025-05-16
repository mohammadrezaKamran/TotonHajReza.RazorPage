using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Services.UserAddress;

namespace TotonHajReza.RazorPage.Pages.Profile.Addresses
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
     private readonly IUserAddressService _userAddressService;

        public IndexModel(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        #region Properties
        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Shire { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string City { get; set; }

        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PostalCode { get; set; }

        [Display(Name = "آدرس پستی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string PostalAddress { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^([0-9]{11})$", ErrorMessage = "شماره موبایل معتبر نیست")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Family { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(10, ErrorMessage = "کدملی نامعتبر است")]
        [MinLength(10, ErrorMessage = "کدملی نامعتبر است")]
        public string NationalCode { get; set; }

        #endregion

        public async Task OnGet(long id)
        {
            var result = await _userAddressService.GetUserAddress();
            if (result != null)
            {
                Name = result.Name;
                Family=result.Family;
                PhoneNumber = result.PhoneNumber;
                Shire=result.Shire;
                City=result.City;
                PostalCode=result.PostalCode;
                PostalAddress=result.PostalAddress;
                NationalCode = result.NationalCode;

            }          
        }

        public async Task<IActionResult> OnPost(long id)
        {
         
            if (id != 0)
            {
                var Editresult = await _userAddressService.EditUserAddress(new Models.UserAddress.EditUserAddressCommand()
                {
                    Id=id,
                    Name = Name,
                    Family = Family,
                    Shire = Shire,
                    City = City,
                    PostalAddress = PostalAddress,
                    PostalCode = PostalCode,
                    NationalCode = NationalCode,
                    PhoneNumber = PhoneNumber,

                });
                return RedirectAndShowAlert(Editresult, Page());
            }
            var result = await _userAddressService.CreateUserAddress(new Models.UserAddress.CreateUserAddressCommand()
                {

                    Name = Name,
                    Family = Family,
                    Shire = Shire,
                    City = City,
                    PostalAddress = PostalAddress,
                    PostalCode = PostalCode,
                    NationalCode = NationalCode,
                    PhoneNumber = PhoneNumber,

                });
  
            return RedirectAndShowAlert(result, Redirect("/Profile"));
        }
    }
}
