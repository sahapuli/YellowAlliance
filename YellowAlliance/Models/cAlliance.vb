'----------------------------------------------------------------------
'Class Name:    cAlliance 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Alliance table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cAlliance
    ' Locale Variables 
    Private m_EventID As String
    Private m_AllianceNumber As Integer
    Private m_AlliancePick As Integer
    Private m_TeamID As Integer

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property EventID As String
        Get
            Return m_EventID
        End Get
        Set(value As String)
            m_EventID = value
        End Set
    End Property

    Public Property AllianceNumber As Integer
        Get
            Return m_AllianceNumber
        End Get
        Set(value As Integer)
            m_AllianceNumber = value
        End Set
    End Property
    Public Property AlliancePick As Integer
        Get
            Return m_AlliancePick
        End Get
        Set(value As Integer)
            m_AlliancePick = value
        End Set
    End Property
    Public Property TeamID As Integer
        Get
            Return m_TeamID
        End Get
        Set(value As Integer)
            m_TeamID = value
        End Set
    End Property

End Class
