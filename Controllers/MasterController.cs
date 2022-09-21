using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ShaniTest_Project.Models;

namespace ShaniTest_Project.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeRegistration()
        {
            return View();
        }

        public JsonResult InsertUpdateData(string ID, string Name, string Mobile, string Email ,string DOB ,string Password ,string Designation)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            try
            {
                if (Name.Trim() == "")
                {
                    Dic["Message"] = "Please Enter Name";
                    Dic["Focus"] = "txtname";
                }
                else if (Mobile.Trim() == "")
                {
                    Dic["Message"] = "Please Enter Mobile NO";
                    Dic["Focus"] = "txtmobile";
                }
                else if (Email.Trim() == "")
                {
                    Dic["Message"] = "Please Enter Email";
                    Dic["Focus"] = "txtemail";
                }
                else if (DOB.Trim() == "")
                {
                    Dic["Message"] = "Please Select  DOB";
                    Dic["Focus"] = "txtdob";
                }
                else if (Password.Trim() == "")
                {
                    Dic["Message"] = "Please Enter Password";
                    Dic["Focus"] = "txtpassword";
                }
                else if (Designation.Trim() == "" || Designation.Trim()=="" )
                {
                    Dic["Message"] = "Please Select Designation";
                    Dic["Focus"] = "txtdesign";
                }
                else
                {
                    string[,] Param = new string[,]
                    {
                    {"@ID",ID },
                    {"@Name",Name },
                    {"@Mobile",Mobile },
                    {"@Email",Email },
                    {"@DOB",DOB },
                    {"@Password",Password },
                    {"@Designation",Designation },
                    };
                    DataTable dt = CommonMethod.ExecuteQuery("InsertUpdateEmploye", Param);
                    if (dt.Rows.Count > 0)
                    {
                        Dic["Message"] = dt.Rows[0]["Msg"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }


        public JsonResult ShowData( )
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            try
            {
                
                DataTable dt = CommonMethod.ExecuteQuery("USP_ShowData");
                if (dt.Rows.Count > 0)
                {
                    Dic["Grid"] = CommonMethod.DataBind(dt);
                }
            }
            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }

        public JsonResult EditRegistratinData(string ID)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            try
            {
                string[,] Param = new string[,]
                {
                    {"@ID" ,ID }
                };

                DataTable dt = CommonMethod.ExecuteQuery("USP_ShowData",Param);
                if (dt.Rows.Count > 0)
                {
                    Dic["ID"] = dt.Rows[0]["ID"].ToString();
                    Dic["Name"] = dt.Rows[0]["Name"].ToString();
                    Dic["Mobile"] = dt.Rows[0]["Mobile"].ToString();
                    Dic["Email"] = dt.Rows[0]["Email"].ToString();
                    Dic["DOB"] = dt.Rows[0]["DOB"].ToString();
                    Dic["Password"] = dt.Rows[0]["Password"].ToString();
                    Dic["Designation"] = dt.Rows[0]["Designation"].ToString();
                }
            }
            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }

        public JsonResult DeleteRegistration(string ID)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            try
            {
                string[,] Param = new string[,]
                {
                    {"@ID" ,ID }
                };

                DataTable dt = CommonMethod.ExecuteQuery("Usp_DeleteRecord", Param);
                if (dt.Rows.Count > 0)
                {
                    Dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }


    }

}