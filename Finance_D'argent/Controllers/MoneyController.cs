using Microsoft.AspNetCore.Mvc;
using Finance_D_argent.Data;
using Microsoft.AspNetCore.Identity;
using Finance_D_argent.Models;


namespace Finance_D_argent.Controllers
{
    public class MoneyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public MoneyController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(AccountsviewModel account)
        {
            account.UserName = _userManager.GetUserAsync(User).Result.CustomUsername;
            var accountList = _db.Accounts.ToList();
            var errorList = _db.errorTables.ToList();
            foreach (var item in accountList)
            {
                if (item.AccountNumber.Equals(account.AccountNumber))
                {
                    ModelState.AddModelError("", errorList[9].Message);
                    return View(account);
                }
                if (item.AccountName.ToLower().Equals(account.AccountName))
                {
                    ModelState.AddModelError("", errorList[1].Message);
                    return View(account);
                }
                if (item.Order.Equals(account.Order))
                {
                    ModelState.AddModelError("", errorList[10].Message);
                    return View(account);
                }
            }
            if (account.ChartsOfAccounts && !account.Active)
            {
                ModelState.AddModelError("", errorList[11].Message);
                return View(account);
            }
            if(account.Order <= 0)
            {
                ModelState.AddModelError("", errorList[12].Message);
                return View(account);
            }
            if(account.InitialBalance < 0)
            {
                ModelState.AddModelError("", errorList[13].Message);
                return View(account);
            }
            var temp = account.AccountNumber.ToString();
            string zero = null;

            if(account.AccountNumber <= 9)
            {
                zero = "0";
            }

            if(account.Category == "Asset")
            {
                account.Statement = "Balance sheet";
                account.NormalSide = "Left";
                if (account.Contra)
                {
                    account.NormalSide = "Right";
                }
                temp = "1" + zero + temp;
                account.AccountNumber = int.Parse(temp);
            }
            else if(account.Category == "Income Statement")
            {
                account.Statement = "Balance sheet";
                account.NormalSide = "Left";
                if (account.Contra)
                {
                    account.NormalSide = "Right";
                }
                temp = "5" + zero + temp;
                account.AccountNumber = int.Parse(temp);
            }
            else if (account.Category == "Liability")
            {
                account.Statement = "Balance Sheet";
                account.NormalSide = "Right";
                if (account.Contra)
                {
                    account.NormalSide = "Left";
                }
                temp = "2" + zero + temp;
                account.AccountNumber = int.Parse(temp);
            }
            else if (account.Category == "Equity")
            {
                account.Statement = "Balance Sheet";
                account.NormalSide = "Right";
                if (account.Contra)
                {
                    account.NormalSide = "Left";
                }
                temp = "3" + zero + temp;
                account.AccountNumber = int.Parse(temp);
            }
            else if (account.Category == "Revenue")
            {
                account.Statement = "Income Statement";
                account.NormalSide = "Right";
                if (account.Contra)
                {
                    account.NormalSide = "Left";
                }
                temp = "4" + zero + temp;
                account.AccountNumber = int.Parse(temp);
            }
            account.DateCreatedOn = DateTime.Now;
            account.InitialBalance = account.InitialBalance;


            _db.Accounts.Add(account);
            await _db.SaveChangesAsync();
            return RedirectToAction("Accounts", "Money");
        }


        [HttpGet]
        public IActionResult Accounts()
        {
            var sortList = _db.Accounts.ToList();
            return View(sortList);

        }


        [HttpPost]
        public IActionResult Accounts(DateTime dateSearch1,
            DateTime dateSearch2, float balanceSearch1, float balanceSearch2)
        {
            var sortList = SearchResult(dateSearch1, dateSearch2, balanceSearch1, balanceSearch2);

            return View(sortList);

        }


        [HttpGet]
        public IActionResult EditAccount(double? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var objFromDb = _db.Accounts.FirstOrDefault(u => u.AccountNumber == id);

            if (objFromDb == null)
            {
                return NotFound();
            }

            return View(objFromDb);
        }


        [HttpPost]
        public IActionResult EditAccount(AccountsviewModel obj)
        {

            if (ModelState.IsValid)
            {


                var accountlist = _db.Accounts.ToList();
                var objFromDb = _db.Accounts.FirstOrDefault(u => u.AccountNumber == obj.AccountNumber);
                var errorList = _db.errorTables.ToList();

                foreach (var item in accountlist)
                {

                    if ((item.AccountName.Equals(obj.AccountName)) && (!item.AccountName.Equals(objFromDb.AccountName)))
                    {
                        ModelState.AddModelError("", errorList[1].Message);
                        return View(obj);
                    }

                    if ((item.Order.Equals(obj.Order)) && (!item.Order.Equals(objFromDb.Order)))
                    {
                        ModelState.AddModelError("", errorList[10].Message);
                        return View(obj);
                    }

                }
                if (obj.ChartsOfAccounts && !objFromDb.Active)
                {
                    ModelState.AddModelError("", errorList[11].Message);
                    return View(obj);
                }


                if (obj.Category == "Asset")
                {
                    obj.Statement = "Balance Sheet";
                    obj.NormalSide = "Left";
                    if (obj.Contra)
                    {
                        obj.NormalSide = "Right";
                    }
                }
                else if (obj.Category == "Expenses")
                {
                    obj.Statement = "Income Statement";
                    obj.NormalSide = "Left";
                    if (obj.Contra)
                    {
                        obj.NormalSide = "Right";
                    }

                }
                else if (obj.Category == "Liability")
                {
                    obj.Statement = "Balance Sheet";
                    obj.NormalSide = "Right";
                    if (obj.Contra)
                    {
                        obj.NormalSide = "Left";
                    }

                }
                else if (obj.Category == "Equity")
                {
                    obj.Statement = "Balance Sheet";
                    obj.NormalSide = "Right";
                    if (obj.Contra)
                    {
                        obj.NormalSide = "Left";
                    }
                }
                else if (obj.Category == "Revenue")
                {
                    obj.Statement = "Income Statement";
                    obj.NormalSide = "Right";
                    if (obj.Contra)
                    {
                        obj.NormalSide = "Left";
                    }
                }
                _db.SaveChanges();
                TempData[SD.Success] = "Account has been edited successfully.";
                return RedirectToAction("Accounts", "Money");
            }
            return View(obj);
        }


        public IEnumerable<AccountsviewModel> SearchResult(DateTime date1, DateTime date2, float balance1, float balance2)
        {
            var list = _db.Accounts.ToList();
            
            List<AccountsviewModel> resultList = new List<AccountsviewModel>();
            if (date1.ToString() != "1/1/0001 12:00:00 AM")
            {
                if (date2.ToString() == "1/1/0001 12:00:00 AM")
                {
                    date2 = DateTime.Now;
                }
                foreach (var item in list)
                {
                    if (date1.Date <=item.DateCreatedOn.Date && item.DateCreatedOn <= date2.Date)
                    {
                        resultList.Add(item);
                    }
                }
            }
            if ((balance1 > 0) &&(balance2 == 0))
            {
                foreach (var item in list)
                {
                    if(balance1 <= item.InitialBalance)
                    {
                        resultList.Add(item);
                    }
                }
            }
            if ((balance1 == 0) && (balance2 > 0))
            {
                foreach (var item in list)
                {
                    if (item.InitialBalance <= balance2)
                    {
                        resultList.Add(item);
                    }
                }
            }
            if ((balance1 > 0) && (balance2 > 0))
            {
                foreach (var item in list)
                {
                    if ((balance1 <= item.InitialBalance) && (item.InitialBalance) <= balance2)
                    {
                        resultList.Add(item);
                    }
                }
            }
            return resultList;
        }

        public IEnumerable<Journal_Accounts> SearchResult(DateTime date1, DateTime date2)
        {
            List<Journal_Accounts> activeList = new List<Journal_Accounts>();
            List<Journal_Accounts> resultList = new List<Journal_Accounts>();

            var jaList = _db.Journal_Accounts.ToList();
            var jList = _db.journalizes.ToList();
            foreach (var j in jaList)
            {
                activeList.Add(j);
            }
            if (date1.ToString() != "1/1/0001 12:00:00 AM")
            {
                if(date2.ToString() == "1/1/0001 12:00:00 AM")
                {
                    date2 = DateTime.Now;
                }
                foreach (var item in activeList)
                {
                    if(date1.Date <=item.CreatedOn.Date && item.CreatedOn.Date <= date2.Date)
                    {
                        resultList.Add(item);
                    }
                }
            }
            return resultList;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var accountList= _db.Accounts.ToList();
            return Json(new {data = accountList});
        }


        public IActionResult JournalIndex()
        {
            var sortList = _db.Journal_Accounts.ToList();
            return View(sortList);
        }

        [HttpGet]

        public IActionResult AccountLedger(int? id)
        {
            var sortList = _db.Journal_Accounts.ToList();
            var jList = _db.journalizes.ToList();

            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.IsApproved == true)
                    {
                        s.IsApproved = true;
                        s.Description = j.Description;
                        s.Type = j.Type;
                    }
                }
            }

            if (id == null)
            {
                return NotFound();
            }

            var accountmatch = _db.Accounts.FirstOrDefault(u => u.AccountNumber == id);
            List<Journal_Accounts> ja = new List<Journal_Accounts>();
            foreach (var item in sortList)
            {
                if (item.IsApproved)
                {
                    ja.Add(item);
                }
            }

            AccountLedger account_ledger = new AccountLedger
            {
                account = accountmatch,
                Journal_Accounts = ja
            };
            return View(account_ledger);

        }

        [HttpPost]
        public IActionResult AccountLedger(DateTime dateSearch1,
           DateTime dateSearch2, double LedgerID)
        {
            List<Journal_Accounts> approved_results = new List<Journal_Accounts>();
            var sortList = _db.Journal_Accounts.ToList();
            var jList = _db.journalizes.ToList();
            AccountLedger account_ledger = new AccountLedger();
            var accounts = _db.Accounts.ToList();
            int counter = 0;

            //selects the account for the ledger
            foreach (var item in accounts)
            {
                if (item.AccountNumber == LedgerID)
                {
                    account_ledger.account = item;
                    break;
                }
            }
            //determines original length of list before filtering
            foreach (var s in sortList)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.IsApproved == true && s.AccountName1 == account_ledger.account.AccountName)
                    {
                        counter++;
                    }
                    if (s.JournalId == j.JournalId && j.IsApproved == true && s.AccountName2 == account_ledger.account.AccountName)
                    {
                        counter++;
                    }
                }
            }

            //returns search results
            var searchresult = SearchResult(dateSearch1, dateSearch2);
            foreach (var s in searchresult)
            {
                foreach (var j in jList)
                {
                    if (s.JournalId == j.JournalId && j.IsApproved == true && s.AccountName1 == account_ledger.account.AccountName)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                        approved_results.Add(s);
                    }
                    if (s.JournalId == j.JournalId && j.IsApproved == true && s.AccountName2 == account_ledger.account.AccountName)
                    {
                        s.Description = j.Description;
                        s.Type = j.Type;
                        approved_results.Add(s);
                    }
                }
            }
            account_ledger.Journal_Accounts = approved_results;
            ViewBag.Search1 = dateSearch1;
            ViewBag.Search2 = dateSearch2;
            ViewBag.Counter = counter;
            return View(account_ledger);
        }
    }
}



