using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSG.Repositories.Repos
{
    public class BaseRepo
    {
        #region ClassEntity Constants

        protected const string CLASSID = "ClassId";
        protected const string CLASSNAME = "ClassName";
        protected const string DESCRIPTION = "Description";

        #endregion

        #region ClassRepo Stored Procedures

        protected const string SP_GETCLASS = "sp_GetClass";
        protected const string SP_INSERTCLASS = "sp_InsertClass";
        protected const string SP_DELETEALLCLASSES = "sp_DeleteAllClasses";
        protected const string SP_DELETECLASSEBYID = "sp_DeleteClassById";

        #endregion

        #region TeacherEntity Constants

        protected const string TEACHERID = "TeacherId";

        #endregion

        #region TeacherRepo Stored Procedures

        protected const string SP_GETTEACHER = "sp_GetTeacher";
        protected const string SP_INSERTTEACHER = "sp_InsertTeacher";
        protected const string SP_DELETEALLTEACHERS = "sp_DeleteAllTeachers";
        protected const string SP_DELETETEACHERBYID = "sp_DeleteTeacherById";

        #endregion

        #region StudentEntityConstants

        protected const string STUDENTID = "StudentId";

        #endregion

        #region StudentRepo Stored Procedures

        protected const string SP_GETSTUDENTS = "sp_GetStudents";
        protected const string SP_INSERTSTUDENT = "sp_InsertStudent";
        protected const string SP_DELETEALLSTUDENTS = "sp_DeleteAllStudents";
        protected const string SP_DELETESTUDENTBYID = "sp_DeleteStudentById";
        #endregion

        #region Registration Constants

        protected const string REGID = "RegId";
        protected const string ATTENDANCESTATUSID = "AttendanceStatusId";
        protected const string GRADE = "Grade";
        protected const string ATTENDANCEDATE = "AttendanceDate";

        #endregion

        #region User/Login Constants

        protected const string USERID = "UserId";
        protected const string ROLE = "Role";

        protected const string LOGINID = "LoginId";
        protected const string LOGINTIME = "LoginTime";
        protected const string LOGOUTTIME = "LogoutTime";

        #endregion

        #region User/Login Stored Procedures

        protected const string SP_GETALLUSERS = "sp_GetUsers";
        protected const string SP_INSERTUSER = "sp_InsertUser";
        protected const string SP_GETLOGINS = "sp_GetLogins";
        protected const string SP_INSERTLOGIN = "sp_InsertLogin";

        #endregion

        #region Registration Stored Procedures

        protected const string SP_GETREGISTRATIONS = "sp_GetRegistrations";
        protected const string SP_INSERTREGISTRATIONS = "sp_InsertRegistration";
        protected const string SP_DELETEALLREGISTRATIONS = "sp_DeleteAllRegistrations";
        protected const string SP_DELETEREGISTRATIONBYID = "sp_DeleteRegistrationById";

        #endregion

        protected const string NAME = "Name";
        protected const string SURNAME = "Surname";
        protected const string DATEREGISTERED = "DateRegistered";
        protected List<SqlParameter> BuildIdSqlParameterList<T>(string paramName, T paramVal)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@classId", paramVal)
            };

            return paramList;
        }
    }
}
