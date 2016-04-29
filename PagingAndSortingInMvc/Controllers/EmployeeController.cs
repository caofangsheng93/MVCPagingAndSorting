using PagedList;
using PagingAndSortingInMvc.Entities;
using PagingAndSortingInMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagingAndSortingInMvc.Controllers
{
    public class EmployeeController : Controller
    {

        #region 列表分页展示
        /// <summary>
        /// 列表分页展示
        /// </summary>
        /// <param name="sortOrder">按照什么排序</param>
        /// <param name="currentSort">当前排序是</param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public ActionResult Index(string sortOrder, string currentSort, int? page)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            int pageSize = 1;  //每页10条
            int pageIndex = 1; //当前页默认设置为1
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;   //判断可控对象是否有值
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;   //如果sortOrder为空，就设置为Name，下面设置的时候，默认按照名称排序
            ViewBag.CurrentSort = sortOrder;
            IPagedList<EmployeeMaster> employees = null;

            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(currentSort))
                    {
                        employees = db.Employees.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);  //降序OrderByDescending
                    }
                    else
                    {
                        employees = db.Employees.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                case "PhoneNumber":
                    if (sortOrder.Equals(currentSort))
                    {

                        employees = db.Employees.OrderByDescending(m => m.PhoneNumber).ToPagedList(pageIndex, pageSize);
                    }
                    else
                    {
                        employees = db.Employees.OrderBy(m => m.PhoneNumber).ToPagedList(pageIndex, pageSize);
                    }

                    break;

                case "Email":
                    if (sortOrder.Equals(currentSort))
                    {
                        employees = db.Employees.OrderByDescending(m => m.Email).ToPagedList(pageIndex, pageSize);
                    }
                    else
                    {
                        employees = db.Employees.OrderBy(m => m.Email).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                case "Salary":
                    if (sortOrder.Equals(currentSort))
                    {
                        employees = db.Employees.OrderByDescending(m => m.Salary).ToPagedList(pageIndex, pageSize);
                    }
                    else
                    {
                        employees = db.Employees.OrderBy(m => m.Salary).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                default:
                    if (sortOrder.Equals(currentSort))
                    {
                        employees = db.Employees.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);  //降序OrderByDescending
                    }
                    else
                    {
                        employees = db.Employees.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    }

                    break;
            }



            return View(employees);
        } 
        #endregion


        /// <summary>
        /// 添加的思路：首先一个空白的表单，让用户输入，然后点击点击，就Post提交到服务器
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]    //防止跨站点攻击需要加的特性标识ValidateAntiForgeryToken
        public ActionResult Add(EmployeeMaster model)
        {
            model.ID = Guid.NewGuid().ToString();

            ApplicationDbContext db = new ApplicationDbContext();
            db.Employees.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}