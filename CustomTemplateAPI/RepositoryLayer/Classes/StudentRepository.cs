using CustomTemplateAPI.RepositoryLayer.Interfaces;
using CustomTemplateAPI.Models;
using Dapper;
using DataAccessApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CustomTemplateAPI.RepositoryLayer.Classes
{
    public class StudentRepository : RepositoryBase, IStudentRepository
    {
        private readonly ISqlDataAccess sqlDataAccess;
        public StudentRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
            Connection = new SqlConnection("Server = DESKTOP-AKASH\\SQLEXPRESS; Database =TestDB;Trusted_Connection=True;");
            Connection.Open();
            sqlDataAccess = new SqlDataAccess(Connection, Transaction);
        }

        public async Task<IEnumerable<object>> GetAllStudents()
        {
            try
            {
                dynamic students = await sqlDataAccess.GetAll("GetAllStudents", new object { });
                foreach (dynamic item in students)
                {
                    int stdid = item.StudentID;
                }
                return students;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> SaveStudent(Student student)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentID", student.StudentID,DbType.Int32);
                parameters.Add("@Name", student.Name, DbType.String);
                parameters.Add("@IsActive", student.IsActive);
                parameters.Add("@ReturnValue",0,DbType.Int32, ParameterDirection.ReturnValue);

                await sqlDataAccess.ExecuteWithReturnValue("InsStudent", parameters);
                int stdid = parameters.Get<int>("@ReturnValue");
                return stdid;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
