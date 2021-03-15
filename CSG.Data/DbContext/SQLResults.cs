using System;
using System.Data;
using System.Text;

namespace CSG.Data.DbContext
{
    public class SQLResults
    {
        #region Properties

        public string SqlErrorMessage { get; set; }

        public string SqlErrorNumber { get; set; }

        public string SqlErrorSeverity { get; set; }

        public string SqlErrorState { get; set; }

        public string SqlErrorProcedure { get; set; }

        public string SqlErrorLine { get; set; }

        public string SqlSource { get; set; }

        public bool IsSuccessfull { get; private set; }

        public Exception Exception { get; set; }

        public object Result { get; set; } = new object();

        #endregion

        #region Private Readonly Fields

        private readonly DataTable _dt;

        #endregion

        #region Constructor

        public SQLResults(DataTable dt)
        {
            IsSuccessfull = !dt.HasErrors;
            Exception = null;
            _dt = dt;
        }

        public SQLResults(Exception ex)
        {
            if (ex == null)
            {
                IsSuccessfull = true;
            }
            else
            {
                IsSuccessfull = false;
                Exception = ex;
            }
        }

        public SQLResults(string errMessage, string errNr, string errSeverity,
                          string errState, string errProcedure, string errLine, string src)
        {
            if (string.IsNullOrEmpty(errMessage)
                && string.IsNullOrEmpty(errNr)
                && string.IsNullOrEmpty(errSeverity)
                && string.IsNullOrEmpty(errState)
                && string.IsNullOrEmpty(errProcedure)
                && string.IsNullOrEmpty(errLine))
            {
                IsSuccessfull = true;
                SqlSource = src;
            }
            else
            {
                IsSuccessfull = false;
                SqlErrorMessage = errMessage;
                SqlErrorNumber = errNr;
                SqlErrorSeverity = errSeverity;
                SqlErrorState = errState;
                SqlErrorProcedure = errProcedure;
                SqlErrorLine = errLine;
                SqlSource = src;
            }
        }

        public DataTable GetResults()
        {
            return _dt;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (IsSuccessfull && !string.IsNullOrEmpty(SqlSource))
            {
                return string.Format("{0} completed successfully", SqlSource);
            }
            else if (!IsSuccessfull && !string.IsNullOrEmpty(SqlSource) && !string.IsNullOrEmpty(SqlErrorMessage) &&
                    !string.IsNullOrEmpty(SqlErrorNumber) && !string.IsNullOrEmpty(SqlErrorSeverity) &&
                    !string.IsNullOrEmpty(SqlErrorState) && !string.IsNullOrEmpty(SqlErrorProcedure) &&
                    !string.IsNullOrEmpty(SqlErrorLine))
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format("The following error ocurred in {0}", SqlSource));
                sb.AppendLine(string.Format("Error Message - {0}", SqlErrorMessage));
                sb.AppendLine(string.Format("Error Number - {0}", SqlErrorNumber));
                sb.AppendLine(string.Format("Error Severity - {0}", SqlErrorSeverity));
                sb.AppendLine(string.Format("Error State - {0}", SqlErrorState));
                sb.AppendLine(string.Format("Error Procedure - {0}", SqlErrorProcedure));
                sb.AppendLine(string.Format("Error Line - {0}", SqlErrorLine));

                return sb.ToString();
            }
            else
            {
                return string.Format("Stored Procedure ran successfull");
            }
        }

        #endregion
    }
}
