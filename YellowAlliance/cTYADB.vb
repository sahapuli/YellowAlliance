'   Class Name:      cTYADB 
'   Author:          Keith Moore     
'   Date:            November 2016 
'   Description:     The object provides connection services to The Yellow Alliance Website Database. 
'                    The database is a MYSql database  
'   Change history:

'Imports System.Data.Odbc
Imports MySql.Data.MySqlClient

Public Class cTYADB
    ' Public cn As OdbcConnection
    ' Public dr As OdbcDataReader
    ' Public cmd As OdbcCommand

    Public cn As MySqlConnection
    Public dr As MySqlDataReader
    Public cmd As MySqlCommand



    'Public Shared logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Function GetConnection() As MySqlConnection
        Dim sConn As String

        'Build connection string
        'Hosted MySQL database 
        'sConn = "DSN=YellowAllianceDB;UID=kmoore503;Pwd=pass@word1#" & ";"
        'Local Access Data base
        'sConn = "DSN=TheYellowAlliance" & ";"
        'sConn = "DSN=TheOrangeAlliance" & ";"
        sConn = "server=50.62.209.111; user id=TOAuser; password=17Frog01;database=TOAmaster_FTCdetails;pooling=False"
        If cn Is Nothing Then
            Try
                cn = New MySqlConnection(sConn)
                cn.Open()
            Catch o As MYSQLException
                'logger.Error("cFFWebDB:GetConnection - " & o.Message.ToString)
                Throw New Exception(o.Message.ToString)
            End Try
        End If

        'Return to caller 
        Return cn
    End Function
    Public Sub CloseConnection()
        If (cn IsNot Nothing) Then
            If cn.State = ConnectionState.Open Then
                cn.Close()
                cn = Nothing
            End If
        End If

    End Sub
    Public Sub CloseDataReader()
        If dr.IsClosed Then
        Else
            dr.Close()
            dr = Nothing
        End If
        'Go close database connection 
        CloseConnection()
    End Sub
    Public Function ExecNonQuery(strSQL As String) As Long
        'Dim cmd As OdbcCommand
        Dim lRetCode As Long = 0

        'Go get a connection to database 
        cn = GetConnection()
        'Execute SQL Command  
        Try
            cmd = New MySqlCommand(strSQL, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch o As MYSQLException
            lRetCode = o.ErrorCode
            Throw New Exception(o.Message.ToString)
        Finally
            'Go close database connection 
            CloseConnection()
        End Try

        Return lRetCode
    End Function

    Public Function ExecDRQuery(strSQL As String) As MySqlDataReader
        'Dim cmd As OdbcCommand

        Dim lRetCode As Long = 0

        'Go get a connection to database 
        cn = GetConnection()
        'Execute SQL Command  
        Try
            cmd = New MySqlCommand(strSQL, cn)
            dr = cmd.ExecuteReader()
            'cmd.Dispose()
        Catch o As mysqlException
            'logger.Error("Error cFFWebDB:ExecDRQuery - " & o.Message.ToString)
            lRetCode = o.ErrorCode
            Throw New Exception(o.Message.ToString)
        Finally
            'CloseConnection()
        End Try

        Return dr
    End Function

    Public Function ExecSVQuery(strSQL As String) As Object
        'Dim cmd As OdbcCommand
        Dim oRetData As Object

        'Go get a connection to database 
        cn = GetConnection()
        'Execute SQL Command  
        Try
            cmd = New MySqlCommand(strSQL, cn)
            oRetData = cmd.ExecuteScalar()
            cmd.Dispose()
        Catch o As mysqlException
            Throw New Exception(o.Message.ToString)
        Finally
            'Go close database connection 
            CloseConnection()
        End Try

        Return oRetData
    End Function

End Class
