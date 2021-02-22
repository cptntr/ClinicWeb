using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Entities;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        public IEnumerable<SpecialtiesEntity> ReadAll()
        {
            List<SpecialtiesEntity> specialties = new List<SpecialtiesEntity>();
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
                            SpecialtiesEntity _specialty = new SpecialtiesEntity
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
        public IEnumerable<SpecialtiesEntity> ReadAllForDoctor(int _id_doctor)
        {
            List<SpecialtiesEntity> specialties = new List<SpecialtiesEntity>();
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
                            SpecialtiesEntity _specialty = new SpecialtiesEntity
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
        public IEnumerable<SpecialtiesEntity> ReadAllExceptDoctor(int _id_doctor)
        {
            List<SpecialtiesEntity> specialties = new List<SpecialtiesEntity>();
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
                            SpecialtiesEntity _specialty = new SpecialtiesEntity
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
        public SpecialtiesEntity ReadOneById(int _id)
        {
            SpecialtiesEntity _specialty = new SpecialtiesEntity();
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
        public SpecialtiesEntity Insert(SpecialtiesEntity _specialty)
        {
            string _procedure = "CEX_Specialties";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_name", _specialty.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _specialty;
        }
        //---------------------------------------------------------------------
        public SpecialtiesEntity Update(int _id, SpecialtiesEntity _specialty)
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

