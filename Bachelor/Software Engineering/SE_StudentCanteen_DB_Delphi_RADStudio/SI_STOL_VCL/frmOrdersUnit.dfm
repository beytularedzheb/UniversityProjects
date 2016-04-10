object frmOrders: TfrmOrders
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = #1055#1086#1088#1098#1095#1082#1080
  ClientHeight = 394
  ClientWidth = 645
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object grboxAdd: TGroupBox
    Left = 8
    Top = 8
    Width = 345
    Height = 209
    Caption = #1044#1086#1073#1072#1074#1103#1085#1077' '#1085#1072' '#1087#1086#1088#1098#1095#1082#1072
    Color = clBtnFace
    ParentBackground = False
    ParentColor = False
    TabOrder = 0
    object btnAddOrder: TSpeedButton
      Left = 152
      Top = 156
      Width = 153
      Height = 33
      Caption = #1044#1086#1073#1072#1074#1080
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      OnClick = btnAddOrderClick
    end
    object btnClearOrderForm: TSpeedButton
      Left = 32
      Top = 156
      Width = 98
      Height = 33
      Caption = #1048#1079#1095#1080#1089#1090#1080
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      OnClick = btnClearOrderFormClick
    end
    object lblDish: TLabel
      Left = 32
      Top = 91
      Width = 34
      Height = 16
      Caption = #1071#1089#1090#1080#1077
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object lbleditStudID: TLabeledEdit
      Left = 32
      Top = 53
      Width = 225
      Height = 27
      EditLabel.Width = 183
      EditLabel.Height = 16
      EditLabel.Caption = #1060#1072#1082#1091#1083#1090#1077#1090#1077#1085' '#1085#1086#1084#1077#1088' '#1085#1072' '#1089#1090#1091#1076#1077#1085#1090#1072
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
      MaxLength = 6
      NumbersOnly = True
      ParentFont = False
      TabOrder = 0
    end
    object cboxDishes: TComboBox
      Left = 32
      Top = 113
      Width = 273
      Height = 27
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      Text = 'cboxDishes'
    end
  end
  object grboxSearch: TGroupBox
    Left = 8
    Top = 223
    Width = 625
    Height = 162
    Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072' '#1087#1086#1088#1098#1095#1082#1072
    TabOrder = 1
    object btnSearch: TSpeedButton
      Left = 480
      Top = 40
      Width = 129
      Height = 27
      Caption = #1058#1098#1088#1089#1080
      OnClick = btnSearchClick
    end
    object btnDeleteOrder: TSpeedButton
      Left = 527
      Top = 80
      Width = 81
      Height = 65
      Caption = #1048#1079#1090#1088#1080#1081
      Visible = False
      OnClick = btnDeleteOrderClick
    end
    object lbleditSearch: TLabeledEdit
      Left = 17
      Top = 40
      Width = 447
      Height = 27
      EditLabel.Width = 253
      EditLabel.Height = 16
      EditLabel.Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072' '#1087#1086#1088#1098#1095#1082#1072' '#1087#1086' '#1085#1086#1084#1077#1088' '#1085#1072' '#1092#1072#1082#1090#1091#1088#1072':'
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
    Height = 209
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1072#1085#1077' '#1085#1072' '#1087#1086#1088#1098#1095#1082#1072
    TabOrder = 2
    Visible = False
    object btnUpdateOrder: TSpeedButton
      Left = 15
      Top = 163
      Width = 146
      Height = 33
      Caption = #1047#1072#1087#1072#1079#1080' '#1087#1088#1086#1084#1077#1085#1080#1090#1077
      OnClick = btnUpdateOrderClick
    end
    object lblWorker: TLabel
      Left = 15
      Top = 21
      Width = 98
      Height = 13
      Caption = #1053#1086#1084#1077#1088' '#1085#1072' '#1089#1083#1091#1078#1080#1090#1077#1083
    end
    object lblCboxDish: TLabel
      Left = 15
      Top = 67
      Width = 60
      Height = 13
      Caption = #1071#1089#1090#1080#1077' | '#1050#1086#1076
    end
    object lblStudent: TLabel
      Left = 15
      Top = 113
      Width = 155
      Height = 13
      Caption = #1060#1072#1082#1091#1083#1090#1077#1090#1085' '#1085#1086#1084#1077#1088' '#1085#1072' '#1089#1090#1091#1076#1077#1085#1090#1072
    end
    object btnClearEditPanel: TSpeedButton
      Left = 176
      Top = 163
      Width = 81
      Height = 33
      Caption = #1048#1079#1095#1080#1089#1090#1080
      OnClick = btnClearEditPanelClick
    end
    object cboxStudent: TComboBox
      Left = 15
      Top = 132
      Width = 145
      Height = 21
      Sorted = True
      TabOrder = 0
      Text = 'cboxStudent'
    end
    object cboxEditDish: TComboBox
      Left = 15
      Top = 86
      Width = 145
      Height = 21
      Sorted = True
      TabOrder = 1
      Text = 'ComboBox2'
    end
    object cboxWorker: TComboBox
      Left = 15
      Top = 40
      Width = 145
      Height = 21
      Sorted = True
      TabOrder = 2
      Text = 'cboxWorker'
    end
  end
  object FDQuery1: TFDQuery
    Connection = FDConnection1
    Left = 600
    Top = 16
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=C:\Stol.mdb'
      'DriverID=MSAcc')
    LoginPrompt = False
    Left = 536
    Top = 16
  end
  object FDGUIxWaitCursor1: TFDGUIxWaitCursor
    Provider = 'Forms'
    Left = 536
    Top = 72
  end
  object FDQuery2: TFDQuery
    Connection = FDConnection1
    Left = 599
    Top = 72
  end
  object DataSource1: TDataSource
    DataSet = FDQuery2
    Left = 599
    Top = 136
  end
end
