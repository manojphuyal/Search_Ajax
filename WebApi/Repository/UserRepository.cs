using WebApi.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{
    public class UserRepository
    {

        DBConnection db = new DBConnection();
        public UserModel LoginCheck(string username, string password)
        {
            try

            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@u", username);
                param.Add("@p", password);
                var data = SqlMapper.Query<UserModel>(db.con, "userlogin", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }


        public void Add(UserModel obj)
        {
            try
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@u", obj.Username);
                param.Add("@p", obj.Password);
                param.Add("@fn", obj.Full_Name);
                param.Add("@e", obj.Email);
                param.Add("@r", obj.Role_ID);
                param.Add("@ci", obj.Country_ID);
                param.Add("@si", obj.State_ID);
                db.con.Execute("insertuser", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }



        public void Edit(UserModel obj)        // to edit user
        {
            try
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", obj.Login_ID);
                param.Add("@un", obj.Username);
                param.Add("@p", obj.Password);
                param.Add("@fn", obj.Full_Name);
                param.Add("@e", obj.Email);
                param.Add("@ri", obj.Role_ID);
                param.Add("@ci", obj.Country_ID);
                param.Add("@si", obj.State_ID);
                db.con.Execute("updateuser", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }




        public void Delete(int?id)                   //to delete user
        {
            try
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id",id);
                db.con.Execute("deleteuser", param, commandType: CommandType.StoredProcedure);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }







        public List<UserModel> getAllRoles()
        {
            db.connection();
            db.con.Open();
            var rol = SqlMapper.Query<UserModel>(db.con, "getAllRoles", commandType: CommandType.StoredProcedure).ToList();
            return rol;
        }


        public UserModel getbyUserID(int? id)
        {
            try
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                var usrid = SqlMapper.Query<UserModel>(db.con, "getbyUserID", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return usrid;
            }

            //dai kata k bhoyo??? bhayena ta edit ma...... edit vayena?ah dai, proc ma thapya chau param xaina
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }

        }
        public List<UserModel> getallUserAndRole()
        {
            try
            {
                db.connection();
                db.con.Open();
                List<UserModel> usrid = SqlMapper.Query<UserModel>(db.con, "getallUserAndRole").ToList();
                return usrid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }
        public List<UserModel> List()
        {
            db.connection();
            db.con.Open();
            try
            {
                var SidList = SqlMapper.Query<UserModel>(db.con, "getallUserAndRole").ToList();
                return SidList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public UserModel User_Exist(string username)
        {
            db.connection();
            db.con.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@username", username);
            var usrid = SqlMapper.Query<UserModel>(db.con, "userExist", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return usrid;
        }

        public List<UserModel> search_list(string s)
        {
            try
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@fullname", s);
                var SidList = SqlMapper.Query<UserModel>(db.con, "user_search", param,commandType:CommandType.StoredProcedure).ToList();
                return SidList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        //for cascade model
            public List<UserModel> DropdownCountry()
            {
                db.connection();
                db.con.Open();
                var CList = SqlMapper.Query<UserModel>(db.con, "getAllCountry", commandType: CommandType.StoredProcedure).ToList();
                return CList;
            }



            public List<UserModel> DropdownState(int? id)
            {
                db.connection();
                db.con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Country_ID", id);
                var CList = SqlMapper.Query<UserModel>(db.con, "getStateByConutryId", param, commandType: CommandType.StoredProcedure).ToList();
                return CList;
            }



        }
}