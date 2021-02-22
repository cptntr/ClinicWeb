using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Models;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class PatientsRepository : IPatientsRepository
    {
        public IEnumerable<PatientsModel> Read()
        {
            List<PatientsModel> patients = new List<PatientsModel>();

            const string _procedure = "READ_Patients";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            PatientsModel _patient = new PatientsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_patient"),
                            };
                            _patient.Doctor = new DoctorsRepository().ReadOne(_patient.IdDoctor);
                            _patient.Person = new PersonsRepository().ReadOne(_patient.IdPerson);

                            patients.Add(_patient);
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
            return patients;
        }
        //---------------------------------------------------------------------
        public PatientsModel ReadOne(int _id)
        {
            PatientsModel patient = new PatientsModel();

            const string _procedure = "READ_Patients_one";
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
                            PatientsModel _patient = new PatientsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                            };
                            _patient.Doctor = new DoctorsRepository().ReadOne(_patient.IdDoctor);
                            _patient.Person = new PersonsRepository().ReadOne(_patient.IdPerson);

                            patient = _patient;
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
            return patient;
        }
        //---------------------------------------------------------------------
        public IEnumerable<PatientsModel> Search(string _search)
        {
            List<PatientsModel> patients = new List<PatientsModel>();
            const string _procedure = "SRCH_Patients";
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
                            PatientsModel _patient = new PatientsModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_patient"),
                            };
                            _patient.Doctor = new DoctorsRepository().ReadOne(_patient.IdDoctor);
                            _patient.Person = new PersonsRepository().ReadOne(_patient.IdPerson);

                            patients.Add(_patient);
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
            return patients;
        }
        //---------------------------------------------------------------------
        public PatientsModel Insert(PatientsModel _patient)
        {
            string _procedure = "CRT_Patients";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_name", _patient.Person.Name));
            _command.Parameters.Add(new SqlParameter("@_surname", _patient.Person.Surname));
            _command.Parameters.Add(new SqlParameter("@_address", _patient.Person.Address));
            _command.Parameters.Add(new SqlParameter("@_phone", _patient.Person.Phone));
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _patient.IdDoctor));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _patient;
        }
        //---------------------------------------------------------------------
        public PatientsModel Update(int _id, PatientsModel _patient)
        {
            string _procedure = "UPD_Patients";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));
            _command.Parameters.Add(new SqlParameter("@_name", _patient.Person.Name));
            _command.Parameters.Add(new SqlParameter("@_surname", _patient.Person.Surname));
            _command.Parameters.Add(new SqlParameter("@_address", _patient.Person.Address));
            _command.Parameters.Add(new SqlParameter("@_phone", _patient.Person.Phone));
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _patient.IdDoctor));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _patient;
        }
        //---------------------------------------------------------------------
        public void Delete(int _id)
        {
            string _procedure = "DEL_Patients";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
        }
    }
}

