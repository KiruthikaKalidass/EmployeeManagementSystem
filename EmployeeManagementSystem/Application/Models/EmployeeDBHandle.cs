using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Application.Models
{
    public class EmployeeDBHandle
    {
        
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW RECORD *********************
        public bool AddEmployee(EModel emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", emodel.Id);
            cmd.Parameters.AddWithValue("@EmployeeName", emodel.EmployeeName);
            cmd.Parameters.AddWithValue("@Address", emodel.Address);
            cmd.Parameters.AddWithValue("@DOB", emodel.DOB);
            cmd.Parameters.AddWithValue("DOJ", emodel.DOJ);
            cmd.Parameters.AddWithValue("BloodGroup", emodel.BloodGroup);
            cmd.Parameters.AddWithValue("qualification", emodel.Qualification);
            cmd.Parameters.AddWithValue("Designation", emodel.Designation);
            cmd.Parameters.AddWithValue("PhoneNumber", emodel.PhoneNumber);
            cmd.Parameters.AddWithValue("Email", emodel.Email);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW  DETAILS ********************
        public List<EModel> GetEmployee()
        {
            Connection();
            List<EModel> emplist = new List<EModel>();

            SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(
                    new EModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        EmployeeName=Convert.ToString(dr["EmployeeName"]),
                        Address=Convert.ToString(dr["Address"]),
                        DOB =Convert.ToDateTime(dr["DOB"]),
                        DOJ=Convert.ToDateTime(dr["DOJ"]),
                        BloodGroup=Convert.ToString(dr["BloodGroup"]),
                        Qualification=Convert.ToString(dr["Qualification"]),
                        Designation=Convert.ToString(dr["Designation"]),
                        PhoneNumber=Convert.ToInt32(dr["PhoneNumber"]),
                        Email=Convert.ToString(dr["Email"])



                    });
            }
            return emplist;
        }

        // ***************** UPDATE DETAILS *********************
        public bool UpdateDetails(EModel emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", emodel.Id);
            cmd.Parameters.AddWithValue("@EmployeeName", emodel.EmployeeName);
            cmd.Parameters.AddWithValue("@Address", emodel.Address);
            cmd.Parameters.AddWithValue("@DOB", emodel.DOB);
            cmd.Parameters.AddWithValue("@DOJ", emodel.DOJ);
            cmd.Parameters.AddWithValue("@BloodGroup", emodel.BloodGroup);
            cmd.Parameters.AddWithValue("@qualification", emodel.Qualification);
            cmd.Parameters.AddWithValue("@Designation", emodel.Designation);
            cmd.Parameters.AddWithValue("@PhoneNumber", emodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", emodel.Email);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Search(EModel emodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("SearchEmployeesDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", emodel.Id);
            cmd.Parameters.AddWithValue("@EmployeeName", emodel.EmployeeName);
            cmd.Parameters.AddWithValue("@Address", emodel.Address);
            cmd.Parameters.AddWithValue("@DOB", emodel.DOB);
            cmd.Parameters.AddWithValue("@DOJ", emodel.DOJ);
            cmd.Parameters.AddWithValue("@BloodGroup", emodel.BloodGroup);
            cmd.Parameters.AddWithValue("@qualification", emodel.Qualification);
            cmd.Parameters.AddWithValue("@Designation", emodel.Designation);
            cmd.Parameters.AddWithValue("@PhoneNumber", emodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", emodel.Email);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE  DETAILS *******************
        public bool DeleteEmployees(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployees", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}

   