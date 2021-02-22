using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Models;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        public IEnumerable<SpecialtiesModel> ReadAll()
        {
            List<SpecialtiesModel> specialties = new List<SpecialtiesModel>();
            const string _procedure = "READ_Specialties";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            SpecialtiesModel _specialty = new SpecialtiesModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                Name = _dataReader.GetString("name"),
                            };

                            specialties.Add(_specialty);
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
            return specialties;
        }
        //---------------------------------------------------------------------
        public IEnumerable<SpecialtiesModel> ReadAllForDoctor(int _id_doctor)
        {
            List<SpecialtiesModel> specialties = new List<SpecialtiesModel>();
            string _procedure = "READ_Specialties_doc";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _id_doctor));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            SpecialtiesModel _specialty = new SpecialtiesModel
                            {
                                Id = _dataReader.GetInt32("id_specialty"),
                                Name = _dataReader.GetString("name"),
                            };

                            specialties.Add(_specialty);
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
            return specialties;
        }
        //---------------------------------------------------------------------
        public IEnumerable<SpecialtiesModel> ReadAllExceptDoctor(int _id_doctor)
        {
            List<SpecialtiesModel> specialties = new List<SpecialtiesModel>();
            string _procedure = "READ_Specialties_exept_doc";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _id_doctor));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            SpecialtiesModel _specialty = new SpecialtiesModel
                            {
                                Id = _dataReader.GetInt32("id_specialty"),
                                Name = _dataReader.GetString("name"),
                            };

                            specialties.Add(_specialty);
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
            return specialties;
        }
        //---------------------------------------------------------------------
        public SpecialtiesModel ReadOneById(int _id)
        {
            SpecialtiesModel _specialty = new SpecialtiesModel();
            const string _procedure = "READ_Specialties_one";
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
                            _specialty.Id = _dataReader.GetInt32("id");
                            _specialty.Name = _dataReader.GetString("name");
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
            return _specialty;
        }

        //---------------------------------------------------------------------
        public SpecialtiesModel Insert(SpecialtiesModel _specialty)
        {
            string _procedure = "CEX_Specialties";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_name", _specialty.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _specialty;
        }
        //---------------------------------------------------------------------
        public SpecialtiesModel Update(int _id, SpecialtiesModel _specialty)
        {
            string _procedure = "UPD_Specialties";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));
            _command.Parameters.Add(new SqlParameter("@_name", _specialty.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _specialty;
        }
        //---------------------------------------------------------------------
        public void Delete(int _id)
        {
            string _procedure = "DEL_Specialties";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
        }
    }
}

