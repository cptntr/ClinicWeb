using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Models;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class DoctorsRepository : IDoctorsRepository
    {
        public IEnumerable<DoctorsModel> Read()
        {
            List<DoctorsModel> doctors = new List<DoctorsModel>();
            const string _procedure = "READ_Doctors";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            DoctorsModel _doctor = new DoctorsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDepartment = _dataReader.GetInt32("id_department"),
                                Removed = _dataReader.GetBoolean("removed"),
                            };
                            _doctor.Person = new PersonsRepository().ReadOne(_doctor.IdPerson);
                            _doctor.Department = new DepartmentsRepository().ReadOne(_doctor.IdDepartment);
                            _doctor.Specialties =
                                new SpecialtiesRepository().ReadAllForDoctor(_doctor.Id);

                            doctors.Add(_doctor);
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
            return doctors;
        }
        //---------------------------------------------------------------------
        public DoctorsModel ReadOne(int _id_doctor)
        {
            DoctorsModel doctor = new DoctorsModel();
            const string _procedure = "READ_Doctors_one";
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
                            DoctorsModel _doctor = new DoctorsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                Removed = _dataReader.GetBoolean("removed"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDepartment = _dataReader.GetInt32("id_department"),
                            };
                            _doctor.Person = new PersonsRepository().ReadOne(_doctor.IdPerson);
                            _doctor.Department = new DepartmentsRepository().ReadOne(_doctor.IdDepartment);
                            _doctor.Specialties =
                                new SpecialtiesRepository().ReadAllForDoctor(_doctor.Id);

                            doctor = _doctor;
                        }
                        _dataReader.Close();
                        ////_transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    ////_transaction.Rollback();
                }
            }
            return doctor;
        }
        //---------------------------------------------------------------------
        public IEnumerable<DoctorsModel> Search(string _search)
        {
            List<DoctorsModel> doctors = new List<DoctorsModel>();
            const string _procedure = "SRCH_Doctors";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_search", _search));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            DoctorsModel _doctor = new DoctorsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                Removed = _dataReader.GetBoolean("removed"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDepartment = _dataReader.GetInt32("id_department"),
                            };
                            _doctor.Person = new PersonsRepository().ReadOne(_doctor.IdPerson);
                            _doctor.Department = new DepartmentsRepository().ReadOne(_doctor.IdDepartment);
                            _doctor.Specialties =
                                new SpecialtiesRepository().ReadAllForDoctor(_doctor.Id);

                            doctors.Add(_doctor);
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
            return doctors;
        }
        //---------------------------------------------------------------------
        public DoctorsModel Insert(DoctorsModel _doctor)
        {
            string _procedure = "CRT_Doctors";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_name", _doctor.Person.Name));
            _command.Parameters.Add(new SqlParameter("@_surname", _doctor.Person.Surname));
            _command.Parameters.Add(new SqlParameter("@_address", _doctor.Person.Address));
            _command.Parameters.Add(new SqlParameter("@_phone", _doctor.Person.Phone));
            _command.Parameters.Add(new SqlParameter("@_depname", _doctor.Department.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _doctor;
        }
        //---------------------------------------------------------------------
        public void InsertSpecialty(int _doctor_id, int _specialty_id)
        {
            string _procedure = "UPD_Doctors_add_specialty";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _doctor_id));
            _command.Parameters.Add(new SqlParameter("@_id_specialty", _specialty_id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            //return _doctor;
        }
        //---------------------------------------------------------------------
        public void DeleteSpecialty(int _doctor_id, int _specialty_id)
        {
            string _procedure = "UPD_Doctors_del_specialty";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _doctor_id));
            _command.Parameters.Add(new SqlParameter("@_id_specialty", _specialty_id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            //return _doctor;
        }
        //---------------------------------------------------------------------
        public DoctorsModel Update(int _id, DoctorsModel _doctor)
        {
            string _procedure = "UPD_Doctors";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));
            _command.Parameters.Add(new SqlParameter("@_name", _doctor.Person.Name));
            _command.Parameters.Add(new SqlParameter("@_surname", _doctor.Person.Surname));
            _command.Parameters.Add(new SqlParameter("@_address", _doctor.Person.Address));
            _command.Parameters.Add(new SqlParameter("@_phone", _doctor.Person.Phone));
            _command.Parameters.Add(new SqlParameter("@_depname", _doctor.Department.Name));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _doctor;
        }
        //---------------------------------------------------------------------
        public void Delete(int _id)
        {
            string _procedure = "DEL_Doctors";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
        }
    }
}

