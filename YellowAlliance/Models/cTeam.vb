'----------------------------------------------------------------------
'Class Name:    cTeam 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the events table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cTeam
    ' Locale Variables 
    Private m_TeamID As Integer
    Private m_TeamNumber As Integer
    Private m_TeamNameLong As String
    Private m_TeamNameShort As String
    Private m_City As String
    Private m_StateProv As String
    Private m_LeagueID As Integer
    Private m_RegionID As String
    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property TeamID As Integer
        Get
            Return m_TeamID
        End Get
        Set(value As Integer)
            m_TeamID = value
        End Set
    End Property

    Public Property TeamNumber As Integer
        Get
            Return m_TeamNumber
        End Get
        Set(value As Integer)
            m_TeamNumber = value
        End Set
    End Property

    Public Property TeamNameLong As String
        Get
            Return m_TeamNameLong
        End Get
        Set(value As String)
            m_TeamNameLong = value
        End Set
    End Property
    Public Property TeamNameShort As String
        Get
            Return m_TeamNameShort
        End Get
        Set(value As String)
            m_TeamNameShort = value
        End Set
    End Property
    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
        End Set
    End Property
    Public Property StateProv As String
        Get
            Return m_StateProv
        End Get
        Set(value As String)
            m_StateProv = value
        End Set
    End Property

    Public Property LeagueID As Integer
        Get
            Return m_LeagueID
        End Get
        Set(value As Integer)
            m_LeagueID = value
        End Set
    End Property

    Public Property RegionID As String
        Get
            Return m_RegionID
        End Get
        Set(value As String)
            m_RegionID = value
        End Set
    End Property
End Class
