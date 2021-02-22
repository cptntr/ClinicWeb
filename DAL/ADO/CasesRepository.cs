using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Models;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class CasesRepository : ICasesRepository
    {
        public IEnumerable<CasesModel> Read()
        {
            List<CasesModel> cases = new List<CasesModel>();
            const string _procedure = "READ_Cases";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            CasesModel _case = new CasesModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                IdPatient = _dataReader.GetInt32("id_patient"),
                                Created = _dataReader.GetDateTime("created"),
                                Closed = _dataReader.GetDateTime("closed"),
                                Conclusion = _dataReader.GetString("conclusion"),
                            };
                            _case.Patient = new PatientsRepository().ReadOne(_case.IdPatient);
                            _case.Doctor = new DoctorsRepository().ReadOne(_case.IdPatient);

                            cases.Add(_case);
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
            return cases;
        }
        //---------------------------------------------------------------------
        public CasesModel ReadOne(int _id_case)
        {
            CasesModel case_ = new CasesModel();
            const string _procedure = "READ_Cases_one";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_case", _id_case));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            CasesModel _case = new CasesModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                IdPatient = _dataReader.GetInt32("id_patient"),
                                Created = _dataReader.GetDateTime("created"),
                                Closed = _dataReader.GetDateTime("closed"),
                                Conclusion = _dataReader.GetString("conclusion"),
                            };
                            _case.Patient = new PatientsRepository().ReadOne(_case.IdPatient);
                            _case.Doctor = new DoctorsRepository().ReadOne(_case.IdPatient);

                            case_ = _case;
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
            return case_;
        }
        //---------------------------------------------------------------------
        public IEnumerable<CasesModel> Search(string _search)
        {
            List<CasesModel> cases = new List<CasesModel>();
            const string _procedure = "SRCH_Cases";
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
                            CasesModel _case = new CasesModel
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                IdPatient = _dataReader.GetInt32("id_patient"),
                                Created = _dataReader.GetDateTime("created"),
                                Closed = _dataReader.GetDateTime("closed"),
                                Conclusion = _dataReader.GetString("conclusion"),
                            };
                            _case.Patient = new PatientsRepository().ReadOne(_case.IdPatient);
                            _case.Doctor = new DoctorsRepository().ReadOne(_case.IdPatient);

                            cases.Add(_case);
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
            return cases;
        }
        //---------------------------------------------------------------------
        public CasesModel Insert(CasesModel _case)
        {
            string _procedure = "CRT_Cases";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_patient", _case.IdPatient));
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _case.IdDoctor));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _case;
        }
        //---------------------------------------------------------------------
        public CasesModel Update(int _id, CasesModel _case)
        {
            string _procedure = "UPD_Cases";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));
            _command.Parameters.Add(new SqlParameter("@_id_patient", _case.IdPatient));
            _command.Parameters.Add(new SqlParameter("@_closed", _case.Closed));
            _command.Parameters.Add(new SqlParameter("@_conclusion", _case.Conclusion));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _case;
        }
        //---------------------------------------------------------------------
        public void Delete(int _id)
        {
            string _procedure = "DEL_Cases";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
        }
    }
}

