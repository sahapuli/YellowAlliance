'----------------------------------------------------------------------
'Class Name:    cAward 
'Author:        Keith Moore     
'Date:          January 2017 
'Purpose:       This object provides data services for the awards table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cAward
    ' Locale Variables 
    Private m_AwardID As Integer
    Private m_Name As String
    Private m_Description As String
    Private m_Team1 As String
    Private m_Team2 As String
    Private m_Team3 As String
    Private m_Team1No As Long
    Private m_Team2No As Long
    Private m_Team3No As Long
    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property AwardID As Integer
        Get
            Return m_AwardID
        End Get
        Set(value As Integer)
            m_AwardID = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property

    Public Property Team1 As String
        Get
            Return m_Team1
        End Get
        Set(value As String)
            m_Team1 = value
        End Set
    End Property
    Public Property Team2 As String
        Get
            Return m_Team2
        End Get
        Set(value As String)
            m_Team2 = value
        End Set
    End Property
    Public Property Team3 As String
        Get
            Return m_Team3
        End Get
        Set(value As String)
            m_Team3 = value
        End Set
    End Property
    Public Property Team1No As Long
        Get
            Return m_Team1No
        End Get
        Set(value As Long)
            m_Team1No = value
        End Set
    End Property
    Public Property Team2No As Long
        Get
            Return m_Team2No
        End Get
        Set(value As Long)
            m_Team2No = value
        End Set
    End Property
    Public Property Team3No As Long
        Get
            Return m_Team3No
        End Get
        Set(value As Long)
            m_Team3No = value
        End Set
    End Property

End Class
