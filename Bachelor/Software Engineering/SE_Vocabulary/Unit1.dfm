object Form1: TForm1
  Left = 722
  Top = 312
  Width = 553
  Height = 420
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = #1058#1077#1088#1084#1080#1085#1086#1083#1086#1075#1080#1095#1077#1085' '#1088#1077#1095#1085#1080#1082' - Delphi'
  Color = clMoneyGreen
  Constraints.MaxHeight = 420
  Constraints.MaxWidth = 553
  Constraints.MinHeight = 420
  Constraints.MinWidth = 553
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label3: TLabel
    Left = 16
    Top = 352
    Width = 66
    Height = 16
    Caption = #1041#1088#1086#1081' '#1076#1091#1084#1080':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 88
    Top = 352
    Width = 4
    Height = 16
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 16
    Top = 16
    Width = 241
    Height = 26
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    MaxLength = 255
    ParentFont = False
    TabOrder = 0
    OnKeyPress = Edit1KeyPress
  end
  object Button1: TButton
    Left = 280
    Top = 16
    Width = 129
    Height = 25
    Caption = #1058#1098#1088#1089#1077#1085#1077' '#1085#1072' '#1082#1086#1084#1072#1085#1076#1072
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 432
    Top = 16
    Width = 89
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1103#1085#1077
    TabOrder = 2
    OnClick = Button2Click
  end
  object Panel1: TPanel
    Left = 16
    Top = 64
    Width = 505
    Height = 264
    BevelOuter = bvNone
    Color = clInactiveBorder
    TabOrder = 3
    object Label1: TLabel
      Left = 16
      Top = 16
      Width = 64
      Height = 18
      Caption = #1050#1086#1084#1072#1085#1076#1072':'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label2: TLabel
      Left = 90
      Top = 16
      Width = 4
      Height = 18
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -15
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Button4: TButton
      Left = 144
      Top = 226
      Width = 113
      Height = 25
      Caption = #1047#1072#1087#1080#1096#1080' '#1087#1088#1086#1084#1077#1085#1080#1090#1077
      TabOrder = 0
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 272
      Top = 226
      Width = 113
      Height = 25
      Caption = #1048#1079#1090#1088#1080#1081' '#1082#1086#1084#1072#1085#1076#1072#1090#1072
      TabOrder = 1
      OnClick = Button5Click
    end
    object RichEdit1: TRichEdit
      Left = 16
      Top = 40
      Width = 473
      Height = 177
      BevelInner = bvNone
      BevelOuter = bvRaised
      BevelKind = bkFlat
      BorderStyle = bsNone
      MaxLength = 255
      TabOrder = 2
    end
    object Button6: TButton
      Left = 400
      Top = 226
      Width = 90
      Height = 25
      Caption = #1042#1098#1079#1089#1090#1072#1085#1086#1074#1080
      TabOrder = 3
      OnClick = Button6Click
    end
  end
  object Button3: TButton
    Left = 390
    Top = 344
    Width = 131
    Height = 25
    Caption = #1048#1079#1093#1086#1076' '#1086#1090' '#1087#1088#1086#1075#1088#1072#1084#1072#1090#1072
    TabOrder = 4
    OnClick = Button3Click
  end
end
