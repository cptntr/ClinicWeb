using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Entities;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class PatientsRepository : IPatientsRepository
    {
        public IEnumerable<PatientsEntity> ReadAll()
        {
            List<PatientsEntity> patients = new List<PatientsEntity>();

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
                            PatientsEntity _patient = new PatientsEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                Removed = _dataReader.GetBoolean("removed"),
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
        public PatientsEntity ReadOne(int _id)
        {
            PatientsEntity patient = new PatientsEntity();

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
                            PatientsEntity _patient = new PatientsEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                Removed = _dataReader.GetBoolean("removed"),
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
        public IEnumerable<PatientsEntity> Search(string _search)
        {
            List<PatientsEntity> patients = new List<PatientsEntity>();
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
                            PatientsEntity _patient = new PatientsEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdPerson = _dataReader.GetInt32("id_person"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                Removed = _dataReader.GetBoolean("removed"),
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
        public PatientsEntity Insert(PatientsEntity _patient)
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
        public PatientsEntity Update(int _id, PatientsEntity _patient)
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

