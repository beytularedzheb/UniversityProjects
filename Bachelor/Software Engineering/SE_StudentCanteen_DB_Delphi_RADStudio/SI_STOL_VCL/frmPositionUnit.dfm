object frmPositions: TfrmPositions
  Left = 0
  Top = 0
  Caption = #1044#1083#1098#1078#1085#1086#1089#1090#1080
  ClientHeight = 355
  ClientWidth = 647
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object grboxAdd: TGroupBox
    Left = 8
    Top = 8
    Width = 345
    Height = 169
    Caption = #1044#1086#1073#1072#1074#1103#1085#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090
    Color = clBtnFace
    ParentBackground = False
    ParentColor = False
    TabOrder = 0
    object btnAdd: TSpeedButton
      Left = 152
      Top = 108
      Width = 153
      Height = 33
      Caption = #1044#1086#1073#1072#1074#1080
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      OnClick = btnAddClick
    end
    object btnClearAddForm: TSpeedButton
      Left = 32
      Top = 108
      Width = 98
      Height = 33
      Caption = #1048#1079#1095#1080#1089#1090#1080
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      OnClick = btnClearAddFormClick
    end
    object lbleditPosition: TLabeledEdit
      Left = 32
      Top = 53
      Width = 161
      Height = 27
      EditLabel.Width = 102
      EditLabel.Height = 16
      EditLabel.Caption = #1048#1084#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090
      EditLabel.Font.Charset = DEFAULT_CHARSET
      EditLabel.Font.Color = clWindowText
      EditLabel.Font.Height = -13
      EditLabel.Font.Name = 'Tahoma'
      EditLabel.Font.Style = []
      EditLabel.ParentFont = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
  end
  object grboxSearch: TGroupBox
    Left = 8
    Top = 183
    Width = 625
    Height = 162
    Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090
    TabOrder = 1
    object btnSearch: TSpeedButton
      Left = 480
      Top = 40
      Width = 129
      Height = 27
      Caption = #1058#1098#1088#1089#1080
      OnClick = btnSearchClick
    end
    object btnDelete: TSpeedButton
      Left = 527
      Top = 80
      Width = 81
      Height = 65
      Caption = #1048#1079#1090#1088#1080#1081
      Visible = False
      OnClick = btnDeleteClick
    end
    object lbleditSearch: TLabeledEdit
      Left = 17
      Top = 40
      Width = 447
      Height = 27
      EditLabel.Width = 191
      EditLabel.Height = 16
      EditLabel.Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090' '#1087#1086' '#1085#1086#1084#1077#1088':'
      EditLabel.Font.Charset = DEFAULT_CHARSET
      EditLabel.Font.Color = clWindowText
      EditLabel.Font.Height = -13
      EditLabel.Font.Name = 'Tahoma'
      EditLabel.Font.Style = []
      EditLabel.ParentFont = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      NumbersOnly = True
      ParentFont = False
      TabOrder = 0
      OnKeyPress = lbleditSearchKeyPress
    end
    object DBGrid1: TDBGrid
      Left = 17
      Top = 80
      Width = 504
      Height = 65
      DataSource = DataSource1
      TabOrder = 1
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
    end
  end
  object gboxEdit: TGroupBox
    Left = 359
    Top = 8
    Width = 274
    Height = 169
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1072#1085#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090
    TabOrder = 2
    Visible = False
    object btnUpdate: TSpeedButton
      Left = 15
      Top = 108
      Width = 146
      Height = 33
      Caption = #1047#1072#1087#1072#1079#1080' '#1087#1088#1086#1084#1077#1085#1080#1090#1077
      OnClick = btnUpdateClick
    end
    object btnClearEditPanel: TSpeedButton
      Left = 167
      Top = 108
      Width = 81
      Height = 33
      Caption = #1048#1079#1095#1080#1089#1090#1080
      OnClick = btnClearEditPanelClick
    end
    object lbleditEditPosition: TLabeledEdit
      Left = 16
      Top = 53
      Width = 233
      Height = 21
      EditLabel.Width = 115
      EditLabel.Height = 13
      EditLabel.Caption = #1053#1086#1074#1086' '#1080#1084#1077' '#1085#1072' '#1076#1083#1098#1078#1085#1086#1089#1090
      TabOrder = 0
    end
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=C:\Stol.mdb'
      'DriverID=MSAcc')
    LoginPrompt = False
    Left = 296
    Top = 32
  end
  object FDQuery1: TFDQuery
    Connection = FDConnection1
    Left = 288
    Top = 88
  end
  object FDQuery2: TFDQuery
    Connection = FDConnection1
    Left = 328
    Top = 136
  end
  object DataSource1: TDataSource
    DataSet = FDQuery2
    Left = 328
    Top = 88
  end
  object FDGUIxWaitCursor1: TFDGUIxWaitCursor
    Provider = 'Forms'
    Left = 336
    Top = 200
  end
end
