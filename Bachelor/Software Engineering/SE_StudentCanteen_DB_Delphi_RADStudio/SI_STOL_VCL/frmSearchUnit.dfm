object frmSearch: TfrmSearch
  Left = 0
  Top = 0
  Caption = #1058#1098#1088#1089#1072#1095#1082#1072
  ClientHeight = 365
  ClientWidth = 991
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
  object btnSearch: TSpeedButton
    Left = 8
    Top = 296
    Width = 161
    Height = 49
    Caption = #1058#1098#1088#1089#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    OnClick = btnSearchClick
  end
  object DBGrid1: TDBGrid
    Left = 175
    Top = 14
    Width = 808
    Height = 260
    BorderStyle = bsNone
    DataSource = DataSource1
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ReadOnly = True
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object gboxSearch: TGroupBox
    Left = 8
    Top = 8
    Width = 161
    Height = 267
    Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072
    TabOrder = 1
    object rbtnOrder: TRadioButton
      Left = 24
      Top = 40
      Width = 113
      Height = 17
      Caption = #1055#1086#1088#1098#1095#1082#1072
      Checked = True
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      TabStop = True
      OnClick = rbtnOrderClick
    end
    object rbtnDish: TRadioButton
      Left = 24
      Top = 80
      Width = 113
      Height = 17
      Caption = #1071#1089#1090#1080#1077
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      OnClick = rbtnDishClick
    end
    object rbtnStudent: TRadioButton
      Left = 24
      Top = 120
      Width = 113
      Height = 17
      Caption = #1057#1090#1091#1076#1077#1085#1090
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
      OnClick = rbtnStudentClick
    end
    object rbtnWorker: TRadioButton
      Left = 24
      Top = 161
      Width = 113
      Height = 17
      Caption = #1057#1083#1091#1078#1080#1090#1077#1083
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
      OnClick = rbtnWorkerClick
    end
    object rbtnPosition: TRadioButton
      Left = 24
      Top = 200
      Width = 113
      Height = 17
      Caption = #1044#1083#1098#1078#1085#1086#1089#1090
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
      TabOrder = 4
      OnClick = rbtnPositionClick
    end
  end
  object editSearch: TEdit
    Left = 175
    Top = 296
    Width = 808
    Height = 50
    BevelKind = bkFlat
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -35
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    OnKeyPress = editSearchKeyPress
  end
  object DataSource1: TDataSource
    DataSet = FDQuery1
    Left = 272
    Top = 96
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=C:\Stol.mdb'
      'DriverID=MSAcc')
    Left = 352
    Top = 104
  end
  object FDGUIxWaitCursor1: TFDGUIxWaitCursor
    Provider = 'Forms'
    Left = 504
    Top = 104
  end
  object FDQuery1: TFDQuery
    Connection = FDConnection1
    Left = 432
    Top = 88
  end
end
