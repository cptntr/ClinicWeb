using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Entities;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class CasesRepository : ICasesRepository
    {
        public IEnumerable<CasesEntity> Read()
        {
            List<CasesEntity> cases = new List<CasesEntity>();
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
                            CasesEntity _case = new CasesEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                IdPatient = _dataReader.GetInt32("id_patient"),
                                Created = _dataReader.GetDateTime("created"),
                                isclosed = string.IsNullOrEmpty(_dataReader.GetString("isclosed")) ? false : true,
                                Conclusion = _dataReader.GetString("conclusion"),
                            };
                            if(!_case.isclosed) _case.Closed = _dataReader.GetDateTime("closed");

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
        public CasesEntity ReadOne(int _id_case)
        {
            CasesEntity case_ = new CasesEntity();
            const string _procedure = "READ_Cases_one";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id_case));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            CasesEntity _case = new CasesEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                IdDoctor = _dataReader.GetInt32("id_doctor"),
                                IdPatient = _dataReader.GetInt32("id_patient"),
                                Created = _dataReader.GetDateTime("created"),
                                isclosed = string.IsNullOrEmpty(_dataReader.GetString("isclosed")) ? false : true,
                                Conclusion = _dataReader.GetString("conclusion"),
                            };
                            if (!_case.isclosed) _case.Closed = _dataReader.GetDateTime("closed");

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
        public IEnumerable<CasesEntity> Search(string _search)
        {
            List<CasesEntity> cases = new List<CasesEntity>();
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
                            CasesEntity _case = new CasesEntity
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
        public CasesEntity Insert(CasesEntity _case)
        {
            string _procedure = "CRT_Cases";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id_patient", _case.IdPatient));
            _command.Parameters.Add(new SqlParameter("@_id_doctor", _case.IdDoctor));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return _case;
        }
        //---------------------------------------------------------------------
        public CasesEntity Update(int _id, CasesEntity _case)
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
        public CasesEntity UpdateCloseCase(int _id)
        {
            string _procedure = "UPD_Cases_close_case";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));
            _command.Parameters.Add(new SqlParameter("@_closed", DateTime.Now));

            new ConnectionManager().ExecuteNonQuery(_connection, _command, _transaction);
            return this.ReadOne(_id);
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

