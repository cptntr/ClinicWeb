using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Entities;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        public IEnumerable<DepartmentsEntity> ReadAll()
        {
            List<DepartmentsEntity> departments = new List<DepartmentsEntity>();
            string _procedure = "READ_Departments";

            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            DepartmentsEntity _department = new DepartmentsEntity()
                            {
                                Id = _dataReader.GetInt32("id"),
                                Name = _dataReader.GetString("name")
                            };

                            departments.Add(_department);
                        }
                        _dataReader.Close();
                        //_transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    //_transaction.Rollback();
                }
            }
            return departments;
        }
        //-----------------------------------------------------------
        public DepartmentsEntity ReadOne(int _id)
        {
            DepartmentsEntity departments = new DepartmentsEntity();
            string _procedure = "READ_Departments_one";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            DepartmentsEntity _department = new DepartmentsEntity()
                            {
                                Id = _dataReader.GetInt32("id"),
                                Name = _dataReader.GetString("name")
                            };

                            departments = _department;
                        }
                        _dataReader.Close();
                        //_transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    //_transaction.Rollback();
                }
            }
            return departments;
        }
        //-----------------------------------------------------------
        public DepartmentsEntity Insert(DepartmentsEntity _department)
        {
            string _procedure = "CRT_Departments";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_depname", _department.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _department;
        }
        //-----------------------------------------------------------
        public DepartmentsEntity Update(int _id, DepartmentsEntity _department)
        {
            string _procedure = "UPD_Departments";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _department.Id));
            _command.Parameters.Add(new SqlParameter("@_depname", _department.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _department;
        }
        //-----------------------------------------------------------
        public void Delete(int _id)
        {
            string _procedure = "DEL_Departments";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
        }
    }
}
