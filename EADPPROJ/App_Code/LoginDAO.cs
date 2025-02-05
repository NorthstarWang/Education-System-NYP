﻿using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class LoginDAO
    {
        public LoginDAO()
        {

        }

        Database data = new Database();
        Record record = new Record();

        public DataSet SelectAdminByIdentification(string username, string password)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Admin WHERE (username = @Username) AND (password = @Password)", prams, "tb_Admin");
        }

        public DataSet SelectTeacherByIdentification(string username, string password)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Teacher WHERE (nric = @NRIC) AND (password = @Password)", prams, "tb_Teacher");

        }

        public DataSet SelectStudentByIdentification(string username, string password)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Student WHERE (adminNo = @AdminNo) AND (password = @Password)", prams, "tb_Student");
        }

        public DataSet SelectInvitationByUsername(string username)
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
            };
            return data.RunProcReturn("SELECT * FROM tb_Invitation WHERE (Username = @username)", prams, "tb_Invitation");
        }

        public DataSet SelectInvitationByCode(string code)
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Code",  SqlDbType.VarChar, 50,code),
            };
            return data.RunProcReturn("SELECT * FROM tb_Invitation WHERE (Code = @Code)", prams, "tb_Invitation");
        }

        public void UpdateInvitationInviteByByUsername(string username, string invite)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, username),
                data.MakeInParam("@InviteBy",  SqlDbType.VarChar, 50, invite)
                };
            data.RunProc("UPDATE tb_Invitation SET InviteBy = (@InviteBy) WHERE (Username = @Username)", prams);
        }


    }
}