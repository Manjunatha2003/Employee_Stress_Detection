using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using finalyearProject.DLTableAdapters;

namespace finalyearProject
{
    public class BLL
    {
        //common class which contains class members and functionalities

        tblAdminTableAdapter adminObj = new tblAdminTableAdapter();
        tblEmpsTableAdapter EmpObj = new tblEmpsTableAdapter();
        tblQueriesTableAdapter queryObj = new tblQueriesTableAdapter();
        tblSolutionTableAdapter solutionObj = new tblSolutionTableAdapter();

        //admin login
        public bool CheckAdminLogin(string adminId, string pwd)
        {
            int cnt = int.Parse(adminObj.CheckAdminLogin(adminId, pwd).ToString());

            if (cnt == 1)

                return true;

            else

                return false;
        }

        //admin update password
        public void UpdateAdminPassword(string pwd, string adminId)
        {
            adminObj.UpdateAdminPassword(pwd, adminId);
        }

        //update stduent password
        public void UpdateEmpPassword(string pwd, string EmpId)
        {
            EmpObj.UpdateEmpPassword(pwd, EmpId);
        }

        //get admin details
        public DataTable GetAdminById(string adminId)
        {
            return adminObj.GetAdminById(adminId);
        }


        //check Emp EmpId
        public bool CheckEmpId(string EmpId)
        {
            int cnt = int.Parse(EmpObj.CheckEmpId(EmpId).ToString());

            if (cnt == 1)

                return false;

            else

                return true;
        }

        //Emp login
        public bool CheckEmpLogin(string EmpId, string pwd)
        {
            int cnt = int.Parse(EmpObj.CheckEmpLogin(EmpId, pwd).ToString());

            if (cnt == 1)

                return true;

            else

                return false;
        }

        //insert Emp
        public void InsertEmp(string EmpId, string pwd, string name, string mobile,
            string emailId, string deptName, string desig)
        {
            EmpObj.InsertEmp(EmpId, pwd, name, mobile, emailId, deptName, desig);
        }

        //update Emp
        public void UpdateEmp(string EmpId, string pwd, string name, string mobile,
           string emailId, string deptName, string desig)
        {
            EmpObj.UpdateEmp(EmpId, pwd, name, mobile, emailId, deptName, desig, EmpId);
        }

        //delete Emp
        public void DeleteEmp(string EmpId)
        {
            EmpObj.DeleteEmp(EmpId);
        }

        //get Emp by EmpId
        public DataTable GetEmpById(string EmpId)
        {
            return EmpObj.GetEmpById(EmpId);
        }

        //function to get all Emps
        public DataTable GetAllEmps()
        {
            return EmpObj.GetData();
        }



        //function to retrive all queries
        public DataTable GetAllQueries()
        {
            return queryObj.GetData();
        }

        //function to retrive pending queries
        public DataTable GetNewQueries()
        {
            return queryObj.GetNewQueries();
        }

        //function to retrive answered queries
        public DataTable GetOldQueries()
        {
            return queryObj.GetOldQueries();
        }

        //function to get query by Id
        public DataTable GetQueryById(int id)
        {
            return queryObj.GetQueryById(id);
        }

        //function to insert new query
        public void InsertNewQuery(string EmpId, string query, DateTime date)
        {
            queryObj.InsertQuery(EmpId, query, date);
        }

        //function to send reply
        public void SendReply(string reply, DateTime date, int Id)
        {
            queryObj.SendReply(reply, date, Id);
        }

        //function to delete the Emp queries
        public void DeleteQueriesByEmpId(string EmpId)
        {
            queryObj.DeleteQueriesByEmpId(EmpId);
        }

        //function to get queries by EmpId
        public DataTable GetQueriesByEmpId(string EmpId)
        {
            return queryObj.GetQueriesByEmpId(EmpId);
        }

        //function to retrive pending queries
        public DataTable GetNewQueriesByEmpId(string EmpId)
        {
            return queryObj.GetNewQueriesByEmpId(EmpId);
        }

        //function to retrive answered queries
        public DataTable GetOldQueriesByEmpId(string EmpId)
        {
            return queryObj.GetOldQueriesByEmpId(EmpId);
        }

        public void InsertSolution(string level, string solution)
        {
            solutionObj.InsertSolution(level, solution);
        }

        public void UpdateSolution(string level, string solution, int Id)
        {
            solutionObj.UpdateSolution(level, solution, Id);
        }

        public void DeleteSolution(int solutionId)
        {
            solutionObj.DeleteSolution(solutionId);
        }

        public DataTable GetSolutionById(int Id)
        {
            return solutionObj.GetSolutionById(Id);
        }

        public DataTable GetSolution()
        {
            return solutionObj.GetData();
        }

        //update Emp
        public void UpdateProfile(string name, string mobile,
           string emailId, string empId)
        {
            EmpObj.UpdateProfile(name, mobile, emailId, empId);
        }
              
    }
}