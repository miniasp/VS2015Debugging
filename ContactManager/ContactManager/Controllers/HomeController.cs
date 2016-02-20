using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;
using ContactManager.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private ContactManagerContext db = new ContactManagerContext();

        #region 樣板產生

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Name,Address,City,State,Zip,Email,Twitter,Self")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Home/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Name,Address,City,State,Zip,Email,Twitter,Self")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        public ActionResult Threads()
        {
            new 不同優先權的執行緒Helper().模擬不同執行緒的執行();
            return RedirectToAction("Index");
        }

        public ActionResult CPUs()
        {
            int 行的數量 = 1800;
            int 列的數量 = 2000;
            int 行的數量2 = 300;
            double[,] m1 = 矩陣相乘之非同步平行計算Helper.進行矩陣值的初始化工作(列的數量, 行的數量);
            double[,] m2 = 矩陣相乘之非同步平行計算Helper.進行矩陣值的初始化工作(行的數量, 行的數量2);
            double[,] result = new double[列的數量, 行的數量2];

            矩陣相乘之非同步平行計算Helper.矩陣相乘之非同步平行計算(m1, m2, result);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AsyncAbor()
        {
            try
            {
                await 非同步下載異常Helper.非同步異常模擬();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Sync()
        {
            try
            {
                await 非同步下載異常Helper.非同步異常模擬();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult MemoryLeak()
        {
            // 由於 settingsHelper 是一個靜態類別，他的 OnCurrencyChanged 是個靜態事件
            // 每次執行新增委派都會加入 HomeController 的 "委派方法" method
            // 此舉會導致 HomeController 因為被 settingsHelper.OnCurrencyChanged 參考而無法回收(Dispose)
            // 因此每次執行 MemoryLeak 都會累積 HomeController 的物件實體，導致記憶體洩漏！
            settingsHelper.OnCurrencyChanged += 委派方法;

            settingsHelper.ChangeCurrency();
            return RedirectToAction("Index");
        }

        List<string> fooListStrs = new List<string>();
        public void 委派方法()
        {
            RandomStringHelper fooRandomStringHelper = new RandomStringHelper();
            for (int i = 0; i < 1500; i++)
            {
                fooListStrs.Add(fooRandomStringHelper.RandomString(5000));
            }
        }

        public async Task<ActionResult> StepPerfTip()
        {
            string ServerUrl = "http://photoimageserver.azurewebsites.net";
            var client = new HttpClient();
            var response = await client.GetStringAsync(ServerUrl + "/api/Images");
            dynamic[] pictureList = JsonConvert.DeserializeObject<dynamic[]>(response);

            return RedirectToAction("Index");
        }

    }
}
