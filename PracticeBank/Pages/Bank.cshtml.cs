using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticeBank.BankAppDatas;

namespace PracticeBank.Pages
{
    public class BankModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public BankModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class SupplierViewModel
        {
            public int Id { get; set; }
            public string NationalID { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public string City { get; set; }
        }

        public List<SupplierViewModel> Suppliers { get; set; }
    = new List<SupplierViewModel>();

        public void OnGet()
        {
            Suppliers = _dbContext.Customers.Select(s => new SupplierViewModel
            {
                //kundnummer och personnummer, namn, adress, city
                Id = s.CustomerId,
                NationalID = s.NationalId,
                Name = s.Givenname,
                Adress = s.Streetaddress,
                City = s.City
            }).ToList();
        }

    }
}
