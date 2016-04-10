object frmAbout: TfrmAbout
  Left = 521
  Top = 380
  Width = 455
  Height = 250
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = 'About'
  Color = clBtnFace
  Constraints.MaxHeight = 250
  Constraints.MaxWidth = 455
  Constraints.MinHeight = 250
  Constraints.MinWidth = 455
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object lblUniName: TLabel
    Left = 88
    Top = 120
    Width = 280
    Height = 19
    Caption = #1056#1091#1089#1077#1085#1089#1082#1080' '#1091#1085#1080#1074#1077#1088#1089#1080#1090#1077#1090' "'#1040#1085#1075#1077#1083' '#1050#1098#1085#1095#1077#1074'"'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lblAppName: TLabel
    Left = 24
    Top = 24
    Width = 400
    Height = 75
    Alignment = taCenter
    Caption = 
      #1050#1086#1085#1074#1077#1088#1090#1086#1088' '#1085#1072' '#1076#1077#1089#1077#1090#1080#1095#1085#1080' '#1095#1080#1089#1083#1072' '#1074' '#1096#1077#1089#1090#1085#1072#1076#1077#1089#1077#1090#1080#1095#1085#1072' '#1073#1088#1086#1081#1085#1072' '#1089#1080#1089#1090#1077#1084#1072' '#1080' ' +
      #1086#1073#1088#1072#1090#1085#1086
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object btnClose: TButton
    Left = 184
    Top = 160
    Width = 75
    Height = 25
    Caption = 'Close'
    TabOrder = 0
    OnClick = btnCloseClick
  end
end
